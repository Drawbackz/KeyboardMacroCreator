using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using KeyboardMacroCreator.KeyboardData;
using KeyboardMacroCreator.KeyboardData.Keys.InputProvider;
using KeyboardMacroCreator.KeyboardData.Keys.OutputProvider;
using KeyboardMacroCreator.MacroData;
using KeyboardMacroCreator.MacroData.Player;
using KeyboardMacroCreator.MacroData.Recorder;
using KeyboardMacroCreator.Properties;
using Newtonsoft.Json;

namespace KeyboardMacroCreator
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ResetFormMacro();

            Keyboard.Keys.Listen = true;
            Keyboard.Keys.OnKeyCombinationPressed += KeyboardKeyCombinationPressed;

            _savePath = Path.Combine(Application.CommonAppDataPath, "macros.json");
            LoadSettings();
            LoadMacros();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        #region Events

        public static event Action OnFormMacroUpdated;
        public static event Action OnSavedMacrosUpdated;
        public static event Action OnSelectedKeyboardMacroUpdated;

        #endregion

        #region Private Variables

        public enum MacroRecordingChannelSelection
        {
            Off,
            On
        }

        private static string _savePath;

        #endregion

        #region Event Triggering Public Variables

        private static IKeyboard _keyboard = new Keyboard();

        public static IKeyboard Keyboard
        {
            get => _keyboard;
            set => _keyboard = new Keyboard();
        }

        private static KeyboardMacro _formMacro = new KeyboardMacro();

        public static KeyboardMacro FormMacro
        {
            get => _formMacro;
            set
            {
                _formMacro = value;
                _formMacro.OnValueChanged += OnFormMacroUpdated;
                OnFormMacroUpdated?.Invoke();
            }
        }

        private static KeyboardMacro _selectedKeyboardMacro;

        public static KeyboardMacro SelectedKeyboardMacro
        {
            get => _selectedKeyboardMacro;
            set
            {
                _selectedKeyboardMacro = value;
                FormMacro = _selectedKeyboardMacro;
                OnSelectedKeyboardMacroUpdated?.Invoke();
            }
        }

        #endregion

        #region Public Variables

        public static string LastError { get; private set; }
        public static bool IgnoreMacroShortCuts { get; set; }
        public static MacroRecordingChannelSelection MacroRecordingChannel { get; set; }

        public static readonly IKeyboardMacroPlayer KeyboardMacroPlayer = new KeyboardMacroPlayer();

        public static readonly IKeyboardMacroRecorder KeyboardMacroRecorder =
            new KeyboardMacroRecorder {Keyboard = Keyboard};

        public static List<KeyboardMacro> SavedMacros = new List<KeyboardMacro>();

        #endregion

        #region Private Functions

        private static void KeyboardKeyCombinationPressed(KeyCombination keyCombo)
        {
            new Thread(() => { ProcessKeyCombination(keyCombo); }).Start();
        }

        private static void ProcessKeyCombination(KeyCombination keyCombo)
        {
            if (keyCombo.Equals(KeyboardMacroPlayer.CurrentMacro?.StopLoopShortcutKeys))
                KeyboardMacroPlayer.CancelPlayback();
            else if (!keyCombo.Equals(KeyboardMacroPlayer.CurrentMacro?.ShortcutKeys))
                foreach (var keyboardMacro in SavedMacros)
                    if (!KeyboardMacroPlayer.IsPlaying && keyCombo.Equals(keyboardMacro.ShortcutKeys))
                    {
                        KeyboardMacroPlayer.PlayMacro(keyboardMacro);
                        break;
                    }
        }

        public static void SaveSettings()
        {
            Settings.Default.keyboardInputProvider = (int) Keyboard.Keys.KeyboardKeyEventProviderType;
            Settings.Default.keyboardOutputProvider = (int) FormMacro.OutputType;
            Settings.Default.Save();
        }

        private static void LoadSettings()
        {
            Keyboard.Keys.SetInputProvider((KeyboardInputProviderType) Settings.Default.keyboardInputProvider);
            FormMacro.OutputType = (KeyboardOutputProviderType) Settings.Default.keyboardOutputProvider;
        }

        private static void SaveMacros()
        {
            File.WriteAllText(_savePath, JsonConvert.SerializeObject(SavedMacros));
            OnSavedMacrosUpdated?.Invoke();
        }

        private static void LoadMacros()
        {
            if (File.Exists(_savePath))
                SavedMacros = JsonConvert.DeserializeObject<List<KeyboardMacro>>(File.ReadAllText(_savePath));
            OnSavedMacrosUpdated?.Invoke();
        }

        #endregion

        #region Public Functions

        public static bool AddMacro()
        {
            if (!FormMacro.IsValid)
            {
                LastError = FormMacro.LastError;
                return false;
            }
            var success = true;

            try
            {
                SavedMacros.Add(FormMacro);
                SaveMacros();
            }
            catch (Exception e)
            {
                LastError = e.Message;
                success = false;
            }
            if (success)
                FormMacro = new KeyboardMacro();
            return success;
        }

        public static void RemoveSelectedMacro()
        {
            SavedMacros.Remove(SelectedKeyboardMacro);
            SaveMacros();
            OnSavedMacrosUpdated?.Invoke();
        }

        public static void ResetFormMacro()
        {
            FormMacro = new KeyboardMacro();
            FormMacro.OnValueChanged += () => { OnFormMacroUpdated?.Invoke(); };
            OnFormMacroUpdated?.Invoke();
        }

        public static void StartRecordingOnMacro()
        {
            MacroRecordingChannel = MacroRecordingChannelSelection.On;
            KeyboardMacroRecorder.StartRecording();
        }

        public static void StopRecordingOnMacro()
        {
            if (!KeyboardMacroRecorder.IsRecording)
                throw new ApplicationException("A macro is not recording");
            FormMacro.OnMacro = KeyboardMacroRecorder.CompleteRecording();
        }

        public static void StartRecordingOffMacro()
        {
            MacroRecordingChannel = MacroRecordingChannelSelection.Off;
            KeyboardMacroRecorder.StartRecording();
        }

        public static void StopRecordingOffMacro()
        {
            if (!KeyboardMacroRecorder.IsRecording)
                throw new ApplicationException("A macro is not recording");
            FormMacro.OffMacro = KeyboardMacroRecorder.CompleteRecording();
        }

        public static void RefreshUI()
        {
            OnFormMacroUpdated?.Invoke();
            OnSavedMacrosUpdated?.Invoke();
            OnSelectedKeyboardMacroUpdated?.Invoke();
        }

        #endregion
    }
}
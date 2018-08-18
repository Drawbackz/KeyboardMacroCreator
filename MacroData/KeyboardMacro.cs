using System;
using KeyboardMacroCreator.KeyboardData;
using KeyboardMacroCreator.KeyboardData.Keys.OutputProvider;
using KeyboardMacroCreator.MacroData.Recorder;
using Newtonsoft.Json;

namespace KeyboardMacroCreator.MacroData
{
    public class KeyboardMacro
    {
        private bool _canToggle;
        private bool _isInfinite;

        private int _loopCount;

        private string _name;

        private KeyboardMacroRecording _offMacro = new KeyboardMacroRecording();

        private KeyboardMacroRecording _onMacro = new KeyboardMacroRecording();

        private KeyboardOutputProviderType _outputType;

        private MacroPlaybackSpeed _playbackSpeed = MacroPlaybackSpeed.Original;

        private KeyboardMacroPushMethod _pushMethod = KeyboardMacroPushMethod.PressHold;

        private KeyCombination _shortcutKeys = new KeyCombination();
        private KeyCombination _stopLoopShortcutKeys = new KeyCombination();

        public KeyboardMacro()
        {
            OnValueChanged?.Invoke();
        }

        [JsonIgnore]
        public string LastError { get; private set; }

        [JsonIgnore]
        public bool Enabled { get; set; }

        [JsonIgnore]
        public bool IsToggledOn { get; set; }

        public MacroPlaybackSpeed PlaybackSpeed
        {
            get => _playbackSpeed;
            set
            {
                _playbackSpeed = value;
                OnValueChanged?.Invoke();
            }
        }

        public KeyboardMacroPushMethod PushMethod
        {
            get => _pushMethod;
            set
            {
                _pushMethod = value;
                OnValueChanged?.Invoke();
            }
        }

        public KeyboardOutputProviderType OutputType
        {
            get => _outputType;
            set
            {
                _outputType = value;
                OnValueChanged?.Invoke();
            }
        }

        public bool CanToggle
        {
            get => _canToggle;
            set
            {
                _canToggle = value;
                OnValueChanged?.Invoke();
            }
        }

        public bool IsInfinite
        {
            get => _isInfinite;
            set
            {
                _isInfinite = value;
                OnValueChanged?.Invoke();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnValueChanged?.Invoke();
            }
        }

        public int LoopCount
        {
            get => _loopCount;
            set
            {
                _loopCount = value;
                OnValueChanged?.Invoke();
            }
        }

        public KeyCombination ShortcutKeys
        {
            get => _shortcutKeys;
            set
            {
                _shortcutKeys = value;
                OnValueChanged?.Invoke();
            }
        }

        public KeyCombination StopLoopShortcutKeys
        {
            get => _stopLoopShortcutKeys;
            set
            {
                _stopLoopShortcutKeys = value;
                OnValueChanged?.Invoke();
            }
        }

        public KeyboardMacroRecording OnMacro
        {
            get => _onMacro;
            set
            {
                _onMacro = value;
                OnValueChanged?.Invoke();
            }
        }

        public KeyboardMacroRecording OffMacro
        {
            get => _offMacro;
            set
            {
                _offMacro = value;
                OnValueChanged?.Invoke();
            }
        }

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                if (ShortcutKeys.Count < 1)
                {
                    LastError = "Invalid Macro Shortcut";
                    return false;
                }
                if (OnMacro.Count < 1)
                {
                    LastError = "Invalid On Macro IsRecording";
                    return false;
                }
                if (CanToggle && OffMacro.Count < 1)
                {
                    LastError = "Invalid Off Macro IsRecording";
                    return false;
                }
                if (IsInfinite && StopLoopShortcutKeys.Count < 1)
                {
                    LastError = "Inifite Loop Macro Requires Stop Shortcut";
                    return false;
                }
                return true;
            }
        }

        public event Action OnValueChanged;
    }
}
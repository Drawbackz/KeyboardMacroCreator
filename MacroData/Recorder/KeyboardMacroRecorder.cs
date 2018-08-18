using System;
using System.Diagnostics;
using KeyboardMacroCreator.KeyboardData;
using KeyboardMacroCreator.KeyboardData.Keys;

namespace KeyboardMacroCreator.MacroData.Recorder
{
    public class KeyboardMacroRecorder : IKeyboardMacroRecorder
    {
        private readonly Stopwatch _idleTimeStopwatch = new Stopwatch();

        private bool _isIdle;

        private bool _isRecording;

        private IKeyboard _keyboard;
        private KeyboardMacroRecording _macroRecording;
        public event Action OnIsRecordingUpdated;

        public IKeyboard Keyboard
        {
            get => _keyboard;
            set
            {
                if (_keyboard != null)
                    _keyboard.Keys.OnKeyPressed -= Keys_OnKeyPressed;
                _keyboard = value;
                _keyboard.Keys.OnKeyPressed += Keys_OnKeyPressed;
            }
        }

        public bool IsRecording
        {
            get => _isRecording;
            private set
            {
                _isRecording = value;
                OnIsRecordingUpdated?.Invoke();
            }
        }

        public void StartRecording()
        {
            if (IsRecording)
                throw new Exception("A recording is already in progress");
            IsRecording = true;
            _macroRecording = new KeyboardMacroRecording();
            StartIdle();
        }

        public KeyboardMacroRecording CompleteRecording()
        {
            StopIdle();
            IsRecording = false;
            return _macroRecording;
        }

        private void Keys_OnKeyPressed(KeyboardKey key)
        {
            if (!IsRecording) return;

            StopIdle();
            if (key.State == KeyboardKeyState.Up)
                key.State = key.State;
            _macroRecording.AddKey(new MacroKey {KeyboardKey = key});
            StartIdle();
        }

        private void StartIdle()
        {
            if (_isIdle) return;
            _isIdle = true;
            _idleTimeStopwatch.Reset();
            _idleTimeStopwatch.Start();
        }

        private void StopIdle()
        {
            if (_isIdle)
            {
                var time = _idleTimeStopwatch.ElapsedMilliseconds;
                _macroRecording.Add(MacroKey.CreateMacroPauseKey(time));
                _idleTimeStopwatch.Stop();
                _isIdle = false;
            }
        }
    }
}
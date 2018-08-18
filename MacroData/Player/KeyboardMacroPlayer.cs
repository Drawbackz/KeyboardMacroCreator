using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KeyboardMacroCreator.KeyboardData;
using KeyboardMacroCreator.KeyboardData.Keys.OutputProvider;
using KeyboardMacroCreator.MacroData.Recorder;

namespace KeyboardMacroCreator.MacroData.Player
{
    public class KeyboardMacroPlayer : IKeyboardMacroPlayer
    {
        private readonly Dictionary<KeyboardOutputProviderType, IKeyboardOutputProvider> _keyboardOutputProviders =
            new Dictionary<KeyboardOutputProviderType, IKeyboardOutputProvider>();

        private bool _isPlaying;

        private bool _playbackCancelled;

        public KeyboardMacroPlayer()
        {
            _keyboardOutputProviders.Add(KeyboardOutputProviderType.WindowHook, new WindowSimulatorOutputProvider());
        }

        public KeyboardMacro CurrentMacro { get; private set; }
        public event Action OnIsPlayingUpdated;

        public bool IsPlaying
        {
            get => _isPlaying;
            private set
            {
                _isPlaying = value;
                OnIsPlayingUpdated?.Invoke();
            }
        }

        public async Task PlayMacro(KeyboardMacro macro)
        {
            if (IsPlaying) throw new Exception("Already playing a macro");
            var playbackLoopCount = 0;
            do
            {
                IsPlaying = true;
                CurrentMacro = macro;
                var outputProvider = _keyboardOutputProviders[macro.OutputType];

                KeyboardMacroRecording macroRecording;
                if (macro.CanToggle)
                {
                    macroRecording = macro.IsToggledOn ? macro.OffMacro : macro.OnMacro;
                    macro.IsToggledOn = !macro.IsToggledOn;
                }
                else
                {
                    macroRecording = macro.OnMacro;
                }
                foreach (var macroItem in macroRecording)
                {
                    if (_playbackCancelled) break;
                    if (macroItem.IsMacroPause)
                    {
                        var delayTime = (int) macroItem.MacroPauseLength;
                        if (delayTime < 1) delayTime = 1;
                        switch (macro.PlaybackSpeed)
                        {
                            case MacroPlaybackSpeed.Fast:
                                delayTime = delayTime / 2;
                                break;
                            case MacroPlaybackSpeed.Faster:
                                delayTime = delayTime / 4;
                                break;
                            case MacroPlaybackSpeed.Fastest:
                                delayTime = delayTime / 8;
                                break;
                            case MacroPlaybackSpeed.RandomFast:
                                delayTime = delayTime / (new Random().Next(9) + 1);
                                break;
                            case MacroPlaybackSpeed.RandomSlow:
                                delayTime = delayTime * (new Random().Next(2) + 1);
                                break;
                        }
                        await Task.Delay(delayTime);
                        continue;
                    }
                    switch (macroItem.KeyboardKey.State)
                    {
                        case KeyboardKeyState.Up:
                            if (macro.PushMethod == KeyboardMacroPushMethod.PressHold)
                                outputProvider.KeyUp(macroItem.KeyboardKey.Value);
                            break;
                        case KeyboardKeyState.Down:
                            if (macro.PushMethod == KeyboardMacroPushMethod.PressHold)
                                outputProvider.KeyDown(macroItem.KeyboardKey.Value);
                            else
                                outputProvider.KeyPress(macroItem.KeyboardKey.Value);
                            break;
                    }
                    if (_playbackCancelled) break;
                }
                playbackLoopCount++;
                if (_playbackCancelled) break;
            } while (macro.IsInfinite || playbackLoopCount < macro.LoopCount);
            IsPlaying = false;
            CurrentMacro = null;
            _playbackCancelled = false;
        }

        public void CancelPlayback()
        {
            _playbackCancelled = true;
        }
    }
}
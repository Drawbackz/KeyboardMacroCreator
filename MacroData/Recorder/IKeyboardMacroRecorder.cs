using System;
using KeyboardMacroCreator.KeyboardData;

namespace KeyboardMacroCreator.MacroData.Recorder
{
    public interface IKeyboardMacroRecorder
    {
        IKeyboard Keyboard { get; set; }
        bool IsRecording { get; }
        event Action OnIsRecordingUpdated;

        void StartRecording();
        KeyboardMacroRecording CompleteRecording();
    }
}
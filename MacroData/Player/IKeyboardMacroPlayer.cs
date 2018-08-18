using System;
using System.Threading.Tasks;

namespace KeyboardMacroCreator.MacroData.Player
{
    public interface IKeyboardMacroPlayer
    {
        bool IsPlaying { get; }
        KeyboardMacro CurrentMacro { get; }
        event Action OnIsPlayingUpdated;
        Task PlayMacro(KeyboardMacro macro);
        void CancelPlayback();
    }
}
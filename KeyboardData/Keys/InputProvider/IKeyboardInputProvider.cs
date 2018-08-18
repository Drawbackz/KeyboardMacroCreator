using System;

namespace KeyboardMacroCreator.KeyboardData.Keys.InputProvider
{
    public interface IKeyboardInputProvider : IDisposable
    {
        KeyboardInputProviderType Type { get; }

        event Action<KeyboardKey> OnKeyEvent;
    }
}
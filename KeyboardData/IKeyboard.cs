using KeyboardMacroCreator.KeyboardData.Keys;

namespace KeyboardMacroCreator.KeyboardData
{
    public interface IKeyboard
    {
        KeyboardEvents Keys { get; }
    }
}
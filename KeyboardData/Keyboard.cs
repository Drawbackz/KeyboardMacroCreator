using KeyboardMacroCreator.KeyboardData.Keys;

namespace KeyboardMacroCreator.KeyboardData
{
    public class Keyboard : IKeyboard
    {
        public KeyboardEvents Keys { get; } = new KeyboardEvents {Listen = true};
    }
}
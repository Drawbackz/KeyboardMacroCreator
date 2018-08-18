using WindowsInput.Native;
using KeyboardMacroCreator.KeyboardData.Keys;

namespace KeyboardMacroCreator.MacroData
{
    public class MacroKey
    {
        public bool IsMacroPause { get; set; }
        public float MacroPauseLength { get; set; }

        public KeyboardKey KeyboardKey { get; set; }
        public VirtualKeyCode VirtualKeyCode { get; set; }

        public static MacroKey CreateMacroPauseKey(float pauseMilliseconds)
        {
            return new MacroKey {IsMacroPause = true, MacroPauseLength = pauseMilliseconds};
        }
    }
}
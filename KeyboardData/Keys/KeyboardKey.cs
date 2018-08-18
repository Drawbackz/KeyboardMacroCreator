using WindowsInput.Native;

namespace KeyboardMacroCreator.KeyboardData.Keys
{
    public struct KeyboardKey
    {
        public bool IsInjected { get; set; }
        public System.Windows.Forms.Keys Value { get; set; }
        public VirtualKeyCode VirtualKeyCode => (VirtualKeyCode) Value;
        public KeyboardKeyState State { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
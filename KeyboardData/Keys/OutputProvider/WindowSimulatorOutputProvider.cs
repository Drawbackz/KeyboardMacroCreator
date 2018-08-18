using WindowsInput;
using WindowsInput.Native;

namespace KeyboardMacroCreator.KeyboardData.Keys.OutputProvider
{
    public class WindowSimulatorOutputProvider : IKeyboardOutputProvider
    {
        private InputSimulator _inputSimulator = new InputSimulator();

        public void KeyDown(System.Windows.Forms.Keys key)
        {
            _inputSimulator.Keyboard.KeyDown((VirtualKeyCode) key);
        }

        public void KeyUp(System.Windows.Forms.Keys key)
        {
            _inputSimulator.Keyboard.KeyUp((VirtualKeyCode) key);
        }

        public void KeyPress(System.Windows.Forms.Keys key)
        {
            _inputSimulator.Keyboard.KeyPress((VirtualKeyCode) key);
        }

        public void Dispose()
        {
            _inputSimulator = null;
        }
    }
}
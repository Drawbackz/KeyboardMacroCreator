using System;

namespace KeyboardMacroCreator.KeyboardData.Keys.OutputProvider
{
    public interface IKeyboardOutputProvider : IDisposable
    {
        void KeyDown(System.Windows.Forms.Keys key);
        void KeyUp(System.Windows.Forms.Keys key);
        void KeyPress(System.Windows.Forms.Keys key);
    }
}
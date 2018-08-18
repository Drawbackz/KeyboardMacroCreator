using System.Collections.Generic;
using System.Text;
using KeyboardMacroCreator.KeyboardData.Keys;

namespace KeyboardMacroCreator.KeyboardData
{
    public class KeyCombination : List<System.Windows.Forms.Keys>
    {
        public void AddKey(KeyboardKey key)
        {
            if (Contains(key.Value)) return;
            Add(key.Value);
        }

        public override string ToString()
        {
            var textDisplay = new StringBuilder();
            foreach (var key in this)
                textDisplay.Append($"{key} ");
            return textDisplay.ToString();
        }

        public bool Equals(KeyCombination keyCombo)
        {
            if (keyCombo == null)
                return false;
            for (var i = 0; i < keyCombo.Count; i++)
                if (keyCombo[i].ToString() != this[i].ToString())
                    return false;
            return true;
        }
    }
}
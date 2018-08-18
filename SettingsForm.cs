using System;
using System.Windows.Forms;
using KeyboardMacroCreator.KeyboardData.Keys.InputProvider;
using KeyboardMacroCreator.KeyboardData.Keys.OutputProvider;
using KeyboardMacroCreator.MacroData;

namespace KeyboardMacroCreator
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            foreach (var name in Enum.GetNames(typeof(KeyboardInputProviderType)))
            {
                KeyboardInputProviderComboBox.Items.Add(name);
                KeyboardInputProviderComboBox.SelectedIndex = 0;
            }
            foreach (var name in Enum.GetNames(typeof(KeyboardOutputProviderType)))
            {
                KeyboardOutputTypeComboBox.Items.Add(name);
                KeyboardOutputTypeComboBox.SelectedIndex = 0;
            }
            foreach (var name in Enum.GetNames(typeof(MouseMacroInputType)))
            {
                MouseInputTypeComboBox.Items.Add(name);
                MouseInputTypeComboBox.SelectedIndex = 0;
            }
            foreach (var name in Enum.GetNames(typeof(MouseMacroOutputType)))
            {
                MouseOutputTypeComboBox.Items.Add(name);
                MouseOutputTypeComboBox.SelectedIndex = 0;
            }

            UpdateInputFields();
        }

        private void UpdateInputFields()
        {
            //MouseInputTypeComboBox.SelectedIndex = MouseInputTypeComboBox.Items.IndexOf(Program);
            KeyboardOutputTypeComboBox.SelectedIndex =
                KeyboardOutputTypeComboBox.Items.IndexOf(Program.FormMacro.OutputType.ToString());
            KeyboardInputProviderComboBox.SelectedIndex =
                KeyboardInputProviderComboBox.Items.IndexOf(
                    Program.Keyboard.Keys.KeyboardKeyEventProviderType.ToString());
        }

        private void Save_BTN_Click(object sender, EventArgs e)
        {
            Program.SaveSettings();
            Close();
        }

        private void Cancel_BTN_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
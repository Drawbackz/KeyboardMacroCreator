using System;
using System.Drawing;
using System.Windows.Forms;
using KeyboardMacroCreator.KeyboardData;
using KeyboardMacroCreator.MacroData;

namespace KeyboardMacroCreator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Program.OnFormMacroUpdated += Program_OnFormMacroUpdated;
            Program.OnSavedMacrosUpdated += ProgramOnSavedMacrosUpdated;
            Program.KeyboardMacroPlayer.OnIsPlayingUpdated += Program_OnMacroRunningUpdated;
            Program.KeyboardMacroRecorder.OnIsRecordingUpdated += Program_OnIsRecordingUpdated;
            Program.Keyboard.Keys.OnKeyCombinationPressed += Program_OnKeyCombinationPressed;

            foreach (var name in Enum.GetNames(typeof(MacroPlaybackSpeed)))
            {
                PlaybackSpeedComboBox.Items.Add(name);
                PlaybackSpeedComboBox.SelectedIndex = 0;
            }
            foreach (var name in Enum.GetNames(typeof(KeyboardMacroPushMethod)))
            {
                PushMethodComboBox.Items.Add(name);
                PushMethodComboBox.SelectedIndex = 0;
            }


            Program.RefreshUI();
        }

        private void Program_OnKeyCombinationPressed(KeyCombination keyCombo)
        {
            if (ShortcutFocus_PNL.Focused)
                Program.FormMacro.ShortcutKeys = keyCombo;
            else if (StopLoopShortcutFocus_PNL.Focused)
                Program.FormMacro.StopLoopShortcutKeys = keyCombo;
        }

        private void UpdateTextBoxes()
        {
            var macroShortcutKeys = Program.FormMacro.ShortcutKeys.ToString();
            var stopMacroLoopShortcutKeys = Program.FormMacro.StopLoopShortcutKeys.ToString();
            MacroNameTextBox.Text = Program.FormMacro.Name;
            MacroShortcutTextBox.Text = macroShortcutKeys;
            LoopShortcutTextBox.Text = stopMacroLoopShortcutKeys;
        }

        private void UpdateRecordbuttons()
        {
            if (InvokeRequired)
            {
                MethodInvoker inv = UpdateRecordbuttons;
                Invoke(inv);
                return;
            }

            var canRecord = !Program.KeyboardMacroRecorder.IsRecording && !Program.KeyboardMacroPlayer.IsPlaying;

            StartOnMacroRecordingButton.Enabled = canRecord;
            StopOnMacroRecordingButton.Enabled = Program.KeyboardMacroRecorder.IsRecording &&
                                                 Program.MacroRecordingChannel ==
                                                 Program.MacroRecordingChannelSelection.On;

            StartOffMacroRecordingButton.Enabled = canRecord && Program.FormMacro.CanToggle;
            StopOffMacroRecordingButton.Enabled = Program.KeyboardMacroRecorder.IsRecording &&
                                                  Program.MacroRecordingChannel ==
                                                  Program.MacroRecordingChannelSelection.Off;


            panel1.BackColor = Program.MacroRecordingChannel == Program.MacroRecordingChannelSelection.On &&
                               Program.KeyboardMacroRecorder.IsRecording
                ? Color.Red
                : Program.FormMacro.OnMacro.Count > 0
                    ? Color.LimeGreen
                    : Color.Gray;

            panel2.BackColor = Program.MacroRecordingChannel == Program.MacroRecordingChannelSelection.Off &&
                               Program.KeyboardMacroRecorder.IsRecording
                ? Color.Red
                : Program.FormMacro.OffMacro.Count > 0
                    ? Color.LimeGreen
                    : Color.Gray;
        }

        private void Program_OnMacroRunningUpdated()
        {
            UpdateRecordbuttons();
        }

        private void Program_OnIsRecordingUpdated()
        {
            UpdateRecordbuttons();
        }

        #region Overrides

        protected override bool ProcessTabKey(bool process)
        {
            return false;
        }

        #endregion

        private void MacroNameTextBox_Leave(object sender, EventArgs e)
        {
            Program.FormMacro.Name = MacroNameTextBox.Text;
        }

        private void MacroShortcutTextBox_Enter(object sender, EventArgs e)
        {
            Program.IgnoreMacroShortCuts = true;
        }

        private void MacroShortcutTextBox_Leave(object sender, EventArgs e)
        {
            Program.IgnoreMacroShortCuts = false;
        }

        private void PlaybackSpeedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(PlaybackSpeedComboBox.SelectedItem?.ToString(), out MacroPlaybackSpeed playSpeed))
            {
                if (Program.FormMacro.PlaybackSpeed != playSpeed)
                    Program.FormMacro.PlaybackSpeed = playSpeed;
                if (PlaybackSpeedComboBox.SelectedIndex < 0)
                    PlaybackSpeedComboBox.SelectedIndex = 0;
            }
        }

        private void PushMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Enum.TryParse(PushMethodComboBox.SelectedItem?.ToString(), out KeyboardMacroPushMethod pushMethod))
            {
                if (Program.FormMacro.PushMethod != pushMethod)
                    Program.FormMacro.PushMethod = pushMethod;
                if (PushMethodComboBox.SelectedIndex < 0)
                    PushMethodComboBox.SelectedIndex = 0;
            }
        }


        private void InfiniteLoop_CHK_CheckedChanged(object sender, EventArgs e)
        {
            LoopCount_TB.Enabled = !InfiniteLoop_CHK.Checked;
            LoopShortcutTextBox.Enabled = InfiniteLoop_CHK.Checked;
            Program.FormMacro.IsInfinite = InfiniteLoop_CHK.Checked;
        }

        private void LoopShortcutTextBox_Enter(object sender, EventArgs e)
        {
            StopLoopShortcutFocus_PNL.Focus();
        }

        private void MacroShortcutTextBox_Click(object sender, EventArgs e)
        {
            ShortcutFocus_PNL.Focus();
        }

        private void LoopShortcutTextBox_Click(object sender, EventArgs e)
        {
            StopLoopShortcutFocus_PNL.Focus();
        }

        private void LoopCount_TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void LoopCount_TB_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(LoopCount_TB.Text, out var val))
                Program.FormMacro.LoopCount = val;
        }

        private void showSettingsMenu_BTN_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
        }


        #region Event Handlers

        private void Program_OnFormMacroUpdated()
        {
            UpdateTextBoxes();
            UpdateRecordbuttons();
            ToggleMacro_CHK.Checked = Program.FormMacro.CanToggle;
            InfiniteLoop_CHK.Checked = Program.FormMacro.IsInfinite;
            LoopCount_TB.Text = Program.FormMacro.LoopCount.ToString();
            PlaybackSpeedComboBox.SelectedIndex =
                PlaybackSpeedComboBox.Items.IndexOf(Program.FormMacro.PlaybackSpeed.ToString());
            PushMethodComboBox.SelectedIndex =
                PushMethodComboBox.Items.IndexOf(Program.FormMacro.PushMethod.ToString());
            AddButton.Text = Program.SavedMacros.Contains(Program.FormMacro) ? "Update" : "Add";
        }

        private void ProgramOnSavedMacrosUpdated()
        {
            SavedShortcutsListView.Items.Clear();
            foreach (var keyboardConversion in Program.SavedMacros)
            {
                var lvi = new ListViewItem
                {
                    Tag = keyboardConversion,
                    Text = keyboardConversion.Name
                };
                var shortcut = keyboardConversion.ShortcutKeys.ToString();
                var on = new ListViewItem.ListViewSubItem {Text = keyboardConversion.OnMacro?.ToString()};
                var off = new ListViewItem.ListViewSubItem {Text = keyboardConversion.OffMacro?.ToString()};

                lvi.SubItems.Add(shortcut);
                lvi.SubItems.Add(on);
                lvi.SubItems.Add(off);

                SavedShortcutsListView.Items.Add(lvi);
            }
            AddButton.Text = Program.SavedMacros.Contains(Program.FormMacro) ? "Update" : "Add";
        }

        #endregion


        #region Interface Events

        private void MacroShortcutTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void MacroShortcutTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void MacroShortcutTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void AddMacroButton_Click(object sender, EventArgs e)
        {
            if (Program.SavedMacros.Contains(Program.FormMacro))
                Program.RemoveSelectedMacro();
            if (!Program.AddMacro())
                MessageBox.Show(Program.LastError);
        }

        private void ClearFormButton_Click(object sender, EventArgs e)
        {
            MacroNameTextBox.Text = string.Empty;
            Program.ResetFormMacro();
        }

        private void RemoveSelectedMacroButton_Click(object sender, EventArgs e)
        {
            if (Program.SelectedKeyboardMacro != null)
            {
                Program.RemoveSelectedMacro();
                SavedShortcutsListView.SelectedItems.Clear();
                RemoveButton.Enabled = false;
            }
        }

        private void RecordOnMacroButton_Click(object sender, EventArgs e)
        {
            Program.StartRecordingOnMacro();
            StopOnMacroRecordingButton.Focus();
        }

        private void RecordOffMacroButton_Click(object sender, EventArgs e)
        {
            Program.StartRecordingOffMacro();
            StopOffMacroRecordingButton.Focus();
        }

        private void StopRecordOnMacro_Click(object sender, EventArgs e)
        {
            Program.StopRecordingOnMacro();
        }

        private void StopRecordOffMacro_Click(object sender, EventArgs e)
        {
            Program.StopRecordingOffMacro();
        }

        private void ToggleMacro_CHK_CheckedChanged(object sender, EventArgs e)
        {
            Program.FormMacro.CanToggle = ToggleMacro_CHK.Checked;
            UpdateRecordbuttons();
        }

        private void SavedShortcutsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lvi = (ListView) sender;

            if (lvi.SelectedItems.Count > 0)
            {
                var macro = (KeyboardMacro) lvi.SelectedItems[0].Tag;
                if (macro != null)
                {
                    RemoveButton.Enabled = true;
                    Program.SelectedKeyboardMacro = macro;
                }
            }
        }

        #endregion
    }
}
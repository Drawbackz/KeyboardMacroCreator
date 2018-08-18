namespace KeyboardMacroCreator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SavedShortcutsListView = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TriggerColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MacroShortcutTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.StopLoopShortcutFocus_PNL = new System.Windows.Forms.Panel();
            this.InfiniteLoop_CHK = new System.Windows.Forms.CheckBox();
            this.LoopCount_TB = new System.Windows.Forms.TextBox();
            this.LoopShortcutTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PushMethodComboBox = new System.Windows.Forms.ComboBox();
            this.PlaybackSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ToggleMacro_CHK = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.onMacroTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.StopOnMacroRecordingButton = new System.Windows.Forms.Button();
            this.StartOnMacroRecordingButton = new System.Windows.Forms.Button();
            this.offMacroTab = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StopOffMacroRecordingButton = new System.Windows.Forms.Button();
            this.StartOffMacroRecordingButton = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ClearFormButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ShortcutFocus_PNL = new System.Windows.Forms.Panel();
            this.MacroNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PlayMacro_BTN = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.showSettingsMenu_BTN = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.onMacroTab.SuspendLayout();
            this.offMacroTab.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SavedShortcutsListView
            // 
            this.SavedShortcutsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameHeader,
            this.TriggerColumn});
            this.SavedShortcutsListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.SavedShortcutsListView.FullRowSelect = true;
            this.SavedShortcutsListView.Location = new System.Drawing.Point(3, 16);
            this.SavedShortcutsListView.Name = "SavedShortcutsListView";
            this.SavedShortcutsListView.Size = new System.Drawing.Size(543, 128);
            this.SavedShortcutsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.SavedShortcutsListView.TabIndex = 0;
            this.SavedShortcutsListView.UseCompatibleStateImageBehavior = false;
            this.SavedShortcutsListView.View = System.Windows.Forms.View.Details;
            this.SavedShortcutsListView.SelectedIndexChanged += new System.EventHandler(this.SavedShortcutsListView_SelectedIndexChanged);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            this.nameHeader.Width = 201;
            // 
            // TriggerColumn
            // 
            this.TriggerColumn.Text = "Shortcut";
            this.TriggerColumn.Width = 302;
            // 
            // MacroShortcutTextBox
            // 
            this.MacroShortcutTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MacroShortcutTextBox.Location = new System.Drawing.Point(67, 45);
            this.MacroShortcutTextBox.Name = "MacroShortcutTextBox";
            this.MacroShortcutTextBox.Size = new System.Drawing.Size(470, 20);
            this.MacroShortcutTextBox.TabIndex = 0;
            this.MacroShortcutTextBox.Click += new System.EventHandler(this.MacroShortcutTextBox_Click);
            this.MacroShortcutTextBox.Enter += new System.EventHandler(this.MacroShortcutTextBox_Enter);
            this.MacroShortcutTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MacroShortcutTextBox_KeyDown);
            this.MacroShortcutTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MacroShortcutTextBox_KeyPress);
            this.MacroShortcutTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MacroShortcutTextBox_KeyUp);
            this.MacroShortcutTextBox.Leave += new System.EventHandler(this.MacroShortcutTextBox_Leave);
            // 
            // AddButton
            // 
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddButton.Location = new System.Drawing.Point(0, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(409, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddMacroButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Shortcut:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.panel11);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.panel9);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.panel10);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 363);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Macro Builder";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.StopLoopShortcutFocus_PNL);
            this.groupBox6.Controls.Add(this.InfiniteLoop_CHK);
            this.groupBox6.Controls.Add(this.LoopCount_TB);
            this.groupBox6.Controls.Add(this.LoopShortcutTextBox);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.PushMethodComboBox);
            this.groupBox6.Controls.Add(this.PlaybackSpeedComboBox);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 229);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(543, 104);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Playback Options";
            // 
            // StopLoopShortcutFocus_PNL
            // 
            this.StopLoopShortcutFocus_PNL.Location = new System.Drawing.Point(90, 88);
            this.StopLoopShortcutFocus_PNL.Name = "StopLoopShortcutFocus_PNL";
            this.StopLoopShortcutFocus_PNL.Size = new System.Drawing.Size(22, 10);
            this.StopLoopShortcutFocus_PNL.TabIndex = 29;
            // 
            // InfiniteLoop_CHK
            // 
            this.InfiniteLoop_CHK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.InfiniteLoop_CHK.AutoSize = true;
            this.InfiniteLoop_CHK.Location = new System.Drawing.Point(480, 48);
            this.InfiniteLoop_CHK.Name = "InfiniteLoop_CHK";
            this.InfiniteLoop_CHK.Size = new System.Drawing.Size(57, 17);
            this.InfiniteLoop_CHK.TabIndex = 28;
            this.InfiniteLoop_CHK.Text = "Infinite";
            this.InfiniteLoop_CHK.UseVisualStyleBackColor = true;
            this.InfiniteLoop_CHK.CheckedChanged += new System.EventHandler(this.InfiniteLoop_CHK_CheckedChanged);
            // 
            // LoopCount_TB
            // 
            this.LoopCount_TB.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LoopCount_TB.Location = new System.Drawing.Point(419, 46);
            this.LoopCount_TB.Name = "LoopCount_TB";
            this.LoopCount_TB.Size = new System.Drawing.Size(49, 20);
            this.LoopCount_TB.TabIndex = 27;
            this.LoopCount_TB.TextChanged += new System.EventHandler(this.LoopCount_TB_TextChanged);
            this.LoopCount_TB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoopCount_TB_KeyPress);
            // 
            // LoopShortcutTextBox
            // 
            this.LoopShortcutTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoopShortcutTextBox.Enabled = false;
            this.LoopShortcutTextBox.Location = new System.Drawing.Point(118, 73);
            this.LoopShortcutTextBox.Name = "LoopShortcutTextBox";
            this.LoopShortcutTextBox.Size = new System.Drawing.Size(419, 20);
            this.LoopShortcutTextBox.TabIndex = 25;
            this.LoopShortcutTextBox.Click += new System.EventHandler(this.LoopShortcutTextBox_Click);
            this.LoopShortcutTextBox.Enter += new System.EventHandler(this.LoopShortcutTextBox_Enter);
            this.LoopShortcutTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MacroShortcutTextBox_KeyDown);
            this.LoopShortcutTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MacroShortcutTextBox_KeyPress);
            this.LoopShortcutTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MacroShortcutTextBox_KeyUp);
            this.LoopShortcutTextBox.Leave += new System.EventHandler(this.MacroShortcutTextBox_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Stop Loop Shortcut:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(352, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Loop Count:";
            // 
            // PushMethodComboBox
            // 
            this.PushMethodComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PushMethodComboBox.FormattingEnabled = true;
            this.PushMethodComboBox.Location = new System.Drawing.Point(118, 19);
            this.PushMethodComboBox.Name = "PushMethodComboBox";
            this.PushMethodComboBox.Size = new System.Drawing.Size(419, 21);
            this.PushMethodComboBox.TabIndex = 22;
            this.PushMethodComboBox.SelectedIndexChanged += new System.EventHandler(this.PushMethodComboBox_SelectedIndexChanged);
            // 
            // PlaybackSpeedComboBox
            // 
            this.PlaybackSpeedComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaybackSpeedComboBox.FormattingEnabled = true;
            this.PlaybackSpeedComboBox.Location = new System.Drawing.Point(118, 46);
            this.PlaybackSpeedComboBox.Name = "PlaybackSpeedComboBox";
            this.PlaybackSpeedComboBox.Size = new System.Drawing.Size(228, 21);
            this.PlaybackSpeedComboBox.TabIndex = 20;
            this.PlaybackSpeedComboBox.SelectedIndexChanged += new System.EventHandler(this.PlaybackSpeedComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Button Push Method:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Playback Speed:";
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(3, 217);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(543, 12);
            this.panel11.TabIndex = 31;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ToggleMacro_CHK);
            this.groupBox5.Controls.Add(this.tabControl1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 111);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(543, 106);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Recordings";
            // 
            // ToggleMacro_CHK
            // 
            this.ToggleMacro_CHK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToggleMacro_CHK.AutoSize = true;
            this.ToggleMacro_CHK.Location = new System.Drawing.Point(436, 16);
            this.ToggleMacro_CHK.Name = "ToggleMacro_CHK";
            this.ToggleMacro_CHK.Size = new System.Drawing.Size(95, 17);
            this.ToggleMacro_CHK.TabIndex = 8;
            this.ToggleMacro_CHK.Text = "Enable Toggle";
            this.ToggleMacro_CHK.UseVisualStyleBackColor = true;
            this.ToggleMacro_CHK.CheckedChanged += new System.EventHandler(this.ToggleMacro_CHK_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.onMacroTab);
            this.tabControl1.Controls.Add(this.offMacroTab);
            this.tabControl1.Location = new System.Drawing.Point(9, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 81);
            this.tabControl1.TabIndex = 8;
            // 
            // onMacroTab
            // 
            this.onMacroTab.Controls.Add(this.panel1);
            this.onMacroTab.Controls.Add(this.StopOnMacroRecordingButton);
            this.onMacroTab.Controls.Add(this.StartOnMacroRecordingButton);
            this.onMacroTab.Location = new System.Drawing.Point(4, 22);
            this.onMacroTab.Name = "onMacroTab";
            this.onMacroTab.Padding = new System.Windows.Forms.Padding(3);
            this.onMacroTab.Size = new System.Drawing.Size(520, 55);
            this.onMacroTab.TabIndex = 0;
            this.onMacroTab.Text = "On Macro";
            this.onMacroTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 7);
            this.panel1.TabIndex = 18;
            // 
            // StopOnMacroRecordingButton
            // 
            this.StopOnMacroRecordingButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.StopOnMacroRecordingButton.Enabled = false;
            this.StopOnMacroRecordingButton.Location = new System.Drawing.Point(3, 24);
            this.StopOnMacroRecordingButton.Name = "StopOnMacroRecordingButton";
            this.StopOnMacroRecordingButton.Size = new System.Drawing.Size(514, 21);
            this.StopOnMacroRecordingButton.TabIndex = 0;
            this.StopOnMacroRecordingButton.Text = "Stop Recording";
            this.StopOnMacroRecordingButton.UseVisualStyleBackColor = true;
            this.StopOnMacroRecordingButton.Click += new System.EventHandler(this.StopRecordOnMacro_Click);
            // 
            // StartOnMacroRecordingButton
            // 
            this.StartOnMacroRecordingButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.StartOnMacroRecordingButton.Location = new System.Drawing.Point(3, 3);
            this.StartOnMacroRecordingButton.Name = "StartOnMacroRecordingButton";
            this.StartOnMacroRecordingButton.Size = new System.Drawing.Size(514, 21);
            this.StartOnMacroRecordingButton.TabIndex = 15;
            this.StartOnMacroRecordingButton.Text = "Start Recording";
            this.StartOnMacroRecordingButton.UseVisualStyleBackColor = true;
            this.StartOnMacroRecordingButton.Click += new System.EventHandler(this.RecordOnMacroButton_Click);
            // 
            // offMacroTab
            // 
            this.offMacroTab.Controls.Add(this.panel2);
            this.offMacroTab.Controls.Add(this.StopOffMacroRecordingButton);
            this.offMacroTab.Controls.Add(this.StartOffMacroRecordingButton);
            this.offMacroTab.Location = new System.Drawing.Point(4, 22);
            this.offMacroTab.Name = "offMacroTab";
            this.offMacroTab.Padding = new System.Windows.Forms.Padding(3);
            this.offMacroTab.Size = new System.Drawing.Size(503, 55);
            this.offMacroTab.TabIndex = 1;
            this.offMacroTab.Text = "Off Macro";
            this.offMacroTab.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 7);
            this.panel2.TabIndex = 18;
            // 
            // StopOffMacroRecordingButton
            // 
            this.StopOffMacroRecordingButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.StopOffMacroRecordingButton.Enabled = false;
            this.StopOffMacroRecordingButton.Location = new System.Drawing.Point(3, 24);
            this.StopOffMacroRecordingButton.Name = "StopOffMacroRecordingButton";
            this.StopOffMacroRecordingButton.Size = new System.Drawing.Size(497, 21);
            this.StopOffMacroRecordingButton.TabIndex = 9;
            this.StopOffMacroRecordingButton.Text = "Stop Recording";
            this.StopOffMacroRecordingButton.UseVisualStyleBackColor = true;
            this.StopOffMacroRecordingButton.Click += new System.EventHandler(this.StopRecordOffMacro_Click);
            // 
            // StartOffMacroRecordingButton
            // 
            this.StartOffMacroRecordingButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.StartOffMacroRecordingButton.Enabled = false;
            this.StartOffMacroRecordingButton.Location = new System.Drawing.Point(3, 3);
            this.StartOffMacroRecordingButton.Name = "StartOffMacroRecordingButton";
            this.StartOffMacroRecordingButton.Size = new System.Drawing.Size(497, 21);
            this.StartOffMacroRecordingButton.TabIndex = 16;
            this.StartOffMacroRecordingButton.Text = "Start Recording";
            this.StartOffMacroRecordingButton.UseVisualStyleBackColor = true;
            this.StartOffMacroRecordingButton.Click += new System.EventHandler(this.RecordOffMacroButton_Click);
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 101);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(543, 10);
            this.panel9.TabIndex = 30;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.AddButton);
            this.panel5.Controls.Add(this.ClearFormButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 337);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(543, 23);
            this.panel5.TabIndex = 28;
            // 
            // ClearFormButton
            // 
            this.ClearFormButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClearFormButton.Location = new System.Drawing.Point(409, 0);
            this.ClearFormButton.Name = "ClearFormButton";
            this.ClearFormButton.Size = new System.Drawing.Size(134, 23);
            this.ClearFormButton.TabIndex = 12;
            this.ClearFormButton.Text = "Reset";
            this.ClearFormButton.UseVisualStyleBackColor = true;
            this.ClearFormButton.Click += new System.EventHandler(this.ClearFormButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ShortcutFocus_PNL);
            this.groupBox3.Controls.Add(this.MacroNameTextBox);
            this.groupBox3.Controls.Add(this.MacroShortcutTextBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 26);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(543, 75);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Information";
            // 
            // ShortcutFocus_PNL
            // 
            this.ShortcutFocus_PNL.Location = new System.Drawing.Point(39, 59);
            this.ShortcutFocus_PNL.Name = "ShortcutFocus_PNL";
            this.ShortcutFocus_PNL.Size = new System.Drawing.Size(22, 10);
            this.ShortcutFocus_PNL.TabIndex = 30;
            // 
            // MacroNameTextBox
            // 
            this.MacroNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MacroNameTextBox.Location = new System.Drawing.Point(67, 19);
            this.MacroNameTextBox.Name = "MacroNameTextBox";
            this.MacroNameTextBox.Size = new System.Drawing.Size(470, 20);
            this.MacroNameTextBox.TabIndex = 13;
            this.MacroNameTextBox.Leave += new System.EventHandler(this.MacroNameTextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Name:";
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(3, 16);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(543, 10);
            this.panel10.TabIndex = 36;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PlayMacro_BTN);
            this.groupBox2.Controls.Add(this.SavedShortcutsListView);
            this.groupBox2.Controls.Add(this.RemoveButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 409);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(549, 194);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saved Macros";
            // 
            // PlayMacro_BTN
            // 
            this.PlayMacro_BTN.Dock = System.Windows.Forms.DockStyle.Top;
            this.PlayMacro_BTN.Enabled = false;
            this.PlayMacro_BTN.Location = new System.Drawing.Point(3, 144);
            this.PlayMacro_BTN.Name = "PlayMacro_BTN";
            this.PlayMacro_BTN.Size = new System.Drawing.Size(543, 23);
            this.PlayMacro_BTN.TabIndex = 1;
            this.PlayMacro_BTN.Text = "Play";
            this.PlayMacro_BTN.UseVisualStyleBackColor = true;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(3, 168);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(543, 23);
            this.RemoveButton.TabIndex = 0;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveSelectedMacroButton_Click);
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 399);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(549, 10);
            this.panel6.TabIndex = 28;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSettingsMenu_BTN});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(549, 24);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // showSettingsMenu_BTN
            // 
            this.showSettingsMenu_BTN.Name = "showSettingsMenu_BTN";
            this.showSettingsMenu_BTN.Size = new System.Drawing.Size(61, 20);
            this.showSettingsMenu_BTN.Text = "Settings";
            this.showSettingsMenu_BTN.Click += new System.EventHandler(this.showSettingsMenu_BTN_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 12);
            this.panel3.TabIndex = 34;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(549, 609);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Keyboard Macro Creator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.onMacroTab.ResumeLayout(false);
            this.offMacroTab.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView SavedShortcutsListView;
        private System.Windows.Forms.ColumnHeader TriggerColumn;
        private System.Windows.Forms.TextBox MacroShortcutTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button StopOnMacroRecordingButton;
        private System.Windows.Forms.Button StopOffMacroRecordingButton;
        private System.Windows.Forms.CheckBox ToggleMacro_CHK;
        private System.Windows.Forms.Button ClearFormButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MacroNameTextBox;
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.Button StartOffMacroRecordingButton;
        private System.Windows.Forms.Button StartOnMacroRecordingButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox PlaybackSpeedComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox PushMethodComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage onMacroTab;
        private System.Windows.Forms.TabPage offMacroTab;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox LoopShortcutTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox InfiniteLoop_CHK;
        private System.Windows.Forms.TextBox LoopCount_TB;
        private System.Windows.Forms.Panel StopLoopShortcutFocus_PNL;
        private System.Windows.Forms.Panel ShortcutFocus_PNL;
        private System.Windows.Forms.Button PlayMacro_BTN;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showSettingsMenu_BTN;
        private System.Windows.Forms.Panel panel3;
    }
}


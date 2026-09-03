namespace MessengerSaveEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            openSaveFileDialog = new OpenFileDialog();
            toolStrip1 = new ToolStrip();
            toolStripDropDownButton1 = new ToolStripDropDownButton();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripDropDownButton2 = new ToolStripDropDownButton();
            slot1ToolStripMenuItem = new ToolStripMenuItem();
            slot2ToolStripMenuItem = new ToolStripMenuItem();
            slot3ToolStripMenuItem = new ToolStripMenuItem();
            PleaseOpenLabel = new Label();
            CopyPath = new Button();
            ErrorLabel = new Label();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // openSaveFileDialog
            // 
            openSaveFileDialog.FileName = "SaveGame.txt";
            openSaveFileDialog.Filter = "Save File|*.txt";
            openSaveFileDialog.InitialDirectory = "%userprofile%/AppData/LocalLow/Sabotage Studios/The Messenger";
            openSaveFileDialog.FileOk += openSaveFileDialog_FileOk;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripDropDownButton1, toolStripDropDownButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1262, 27);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
            toolStripDropDownButton1.Image = (Image)resources.GetObject("toolStripDropDownButton1.Image");
            toolStripDropDownButton1.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new Size(46, 24);
            toolStripDropDownButton1.Text = "File";
            toolStripDropDownButton1.Click += toolStripDropDownButton1_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(224, 26);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(224, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(224, 26);
            saveAsToolStripMenuItem.Text = "Save As";
            // 
            // toolStripDropDownButton2
            // 
            toolStripDropDownButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton2.DropDownItems.AddRange(new ToolStripItem[] { slot1ToolStripMenuItem, slot2ToolStripMenuItem, slot3ToolStripMenuItem });
            toolStripDropDownButton2.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            toolStripDropDownButton2.Size = new Size(55, 24);
            toolStripDropDownButton2.Text = "Slots";
            // 
            // slot1ToolStripMenuItem
            // 
            slot1ToolStripMenuItem.Enabled = false;
            slot1ToolStripMenuItem.Name = "slot1ToolStripMenuItem";
            slot1ToolStripMenuItem.Size = new Size(130, 26);
            slot1ToolStripMenuItem.Text = "Slot 1";
            slot1ToolStripMenuItem.Click += slot1ToolStripMenuItem_Click;
            // 
            // slot2ToolStripMenuItem
            // 
            slot2ToolStripMenuItem.Enabled = false;
            slot2ToolStripMenuItem.Name = "slot2ToolStripMenuItem";
            slot2ToolStripMenuItem.Size = new Size(130, 26);
            slot2ToolStripMenuItem.Text = "Slot 2";
            // 
            // slot3ToolStripMenuItem
            // 
            slot3ToolStripMenuItem.Enabled = false;
            slot3ToolStripMenuItem.Name = "slot3ToolStripMenuItem";
            slot3ToolStripMenuItem.Size = new Size(130, 26);
            slot3ToolStripMenuItem.Text = "Slot 3";
            // 
            // PleaseOpenLabel
            // 
            PleaseOpenLabel.BackColor = Color.Transparent;
            PleaseOpenLabel.Dock = DockStyle.Fill;
            PleaseOpenLabel.Font = new Font("Segoe UI", 16F);
            PleaseOpenLabel.ForeColor = SystemColors.ControlLightLight;
            PleaseOpenLabel.Location = new Point(0, 27);
            PleaseOpenLabel.Name = "PleaseOpenLabel";
            PleaseOpenLabel.Size = new Size(1262, 646);
            PleaseOpenLabel.TabIndex = 2;
            PleaseOpenLabel.Text = "Please open your save file in the File menu at the top left, usually found in: \r\n\"%userprofile%\\AppData\\LocalLow\\Sabotage Studio\\The Messenger\"\r\nOr drag your save file into the window\r\n";
            PleaseOpenLabel.TextAlign = ContentAlignment.MiddleCenter;
            PleaseOpenLabel.Click += label1_Click;
            // 
            // CopyPath
            // 
            CopyPath.BackgroundImage = (Image)resources.GetObject("CopyPath.BackgroundImage");
            CopyPath.BackgroundImageLayout = ImageLayout.Stretch;
            CopyPath.Location = new Point(1050, 318);
            CopyPath.Name = "CopyPath";
            CopyPath.Size = new Size(37, 37);
            CopyPath.TabIndex = 3;
            CopyPath.TextImageRelation = TextImageRelation.TextBeforeImage;
            CopyPath.UseVisualStyleBackColor = true;
            CopyPath.Click += CopyPath_Click;
            // 
            // ErrorLabel
            // 
            ErrorLabel.BackColor = Color.Transparent;
            ErrorLabel.Font = new Font("Segoe UI", 14F);
            ErrorLabel.ForeColor = Color.Crimson;
            ErrorLabel.Location = new Point(0, 521);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(1262, 45);
            ErrorLabel.TabIndex = 4;
            ErrorLabel.Text = "Error: (no error yet)";
            ErrorLabel.TextAlign = ContentAlignment.MiddleCenter;
            ErrorLabel.Visible = false;
            ErrorLabel.Click += ErrorLabel_Click;
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1262, 673);
            Controls.Add(ErrorLabel);
            Controls.Add(CopyPath);
            Controls.Add(PleaseOpenLabel);
            Controls.Add(toolStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Messenger Save Editor";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private OpenFileDialog openSaveFileDialog;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private Label PleaseOpenLabel;
        private Button CopyPath;
        private Label ErrorLabel;
        private ToolStripDropDownButton toolStripDropDownButton2;
        private ToolStripMenuItem slot1ToolStripMenuItem;
        private ToolStripMenuItem slot2ToolStripMenuItem;
        private ToolStripMenuItem slot3ToolStripMenuItem;
    }
}

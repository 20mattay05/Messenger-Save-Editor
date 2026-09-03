using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MessengerSaveEditor
{
    public struct SaveFile
    {
        public SaveSlot[] SaveSlots { get; set; }
    }
    public struct SaveSlot
    {
        public List<int> ShopUpgradesUnlocked { get; set; }
        public Items Items { get; set; }

        [JsonIgnore]
        public Dictionary<int, int> itemsDict;
    }
    public struct Items
    {
        public List<int> Keys { get; set; }
        public List<int> Values { get; set; }
    }

    public partial class Form1 : Form
    {
        SaveFileHandler saveFileHandler = new();

        SaveFile? viewedSaveFile = null;
        int activeSlot = 0;
        
        public Form1()
        {
            InitializeComponent();
            DragEnter += new DragEventHandler(Form1_DragEnter);
            DragDrop += new DragEventHandler(Form1_DragDrop);
            errorLabelTimer.Tick += (sender, e) => ErrorLabel.Visible = false;
            MaximizeBox = false;
            slot1ToolStripMenuItem.Click += CheckSlot;
            slot2ToolStripMenuItem.Click += CheckSlot;
            slot3ToolStripMenuItem.Click += CheckSlot;
        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }
        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] saveFile = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (saveFile.Length > 1)
            {
                ShowError($"Expected only one file, instead received {saveFile.Length} files");
                return;
            }
            HandleSaveFile(saveFile);
        }

        private void CopyPath_Click(object sender, EventArgs e)
        {
            string path = @"%userprofile%\AppData\LocalLow\Sabotage Studio\The Messenger";
            Clipboard.SetText(path);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string saveFilePath = openSaveFileDialog.FileName;
                HandleSaveFile(saveFilePath);
            }
        }
        private void HandleSaveFile(string saveFilePath)
        {
            string[] lines = File.ReadAllLines(saveFilePath, System.Text.Encoding.UTF8);
            HandleSaveFile(lines);
        }
        private void HandleSaveFile(string[] saveFile)
        {
            try
            {
                SaveFile sv = saveFileHandler.GetSaveFile(saveFile);
                ViewSaveFile(sv);
            }
            catch (JsonException) { ShowError("Unexpected file selected. Did you choose the right file?"); }
        }

        private void ViewSaveFile(SaveFile sv)
        {
            viewedSaveFile = sv;
            PleaseOpenLabel.Visible = false;
            CopyPath.Visible = false;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

            slot1ToolStripMenuItem.Enabled = true;
            slot1ToolStripMenuItem.Checked = true;

            slot2ToolStripMenuItem.Enabled = true;
            slot3ToolStripMenuItem.Enabled = true;
        }

        private void CheckSlot(object sender, EventArgs e)
        {
            slot1ToolStripMenuItem.Checked = false;
            slot2ToolStripMenuItem.Checked = false;
            slot3ToolStripMenuItem.Checked = false;
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            item.Checked = true;
            switch (item.Text) 
            {
                case "Slot 1": activeSlot = 0; break;
                case "Slot 2": activeSlot = 1; break;
                case "Slot 3": activeSlot = 2; break;
            }
        }

        System.Windows.Forms.Timer errorLabelTimer = new();
        private void ShowError(string errorMessage)
        {
            errorMessage = "Error: " + errorMessage;
            ErrorLabel.Text = errorMessage;
            ErrorLabel.Visible = true;

            const int millisecondsVisible = 5000;
            errorLabelTimer.Interval = millisecondsVisible;
            errorLabelTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void openSaveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ErrorLabel_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void slot1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}

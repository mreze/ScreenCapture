
using System.Drawing.Imaging;
using System.Drawing;
using System;


namespace ScreenCapture
{
    public partial class Form1 : Form
    {
        Dictionary<string, Bitmap> pictures = new();
        Screen selectedScreen;
        public Form1()
        {
            InitializeComponent();
            selectedScreen = Screen.AllScreens[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (Screen screen in Screen.AllScreens)
            {
                ToolStripMenuItem screenSelect = new ToolStripMenuItem();
                screenSelect.Text = screen.DeviceName;
                selectScreenToolStripMenuItem.DropDownItems.Add(screenSelect);

                screenSelect.Click += (sender, e) => selectedScreen = screen;

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureScreen();
        }

        void CaptureScreen()
        {
            try
            {
                Bitmap bmp = new Bitmap(selectedScreen.Bounds.Width, selectedScreen.Bounds.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(selectedScreen.Bounds.Left, selectedScreen.Bounds.Top, 0, 0, selectedScreen.Bounds.Size);
                    SetPictureAndCopytoClipboard(bmp);
                    string key = GenerateKey();
                    pictures[key] = bmp;
                    DrawImages();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static string GenerateKey()
        {
            return DateTime.Now.ToString("H:mm:ss");//Guid.NewGuid().ToString();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(pictureBox1.Image);
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void DrawImages()
        {
            listBox2.Items.Clear();
            UpdateMenuOptions();
            foreach (KeyValuePair<string, Bitmap> keyValuePair in pictures)
            {
                listBox2.Items.Add(keyValuePair.Key);
            }

        }

        private void UpdateMenuOptions()
        {
            if (pictureBox1.Image == null)
            {
                saveAsToolStripMenuItem.Enabled = false;
            }
            else
            {
                saveAsToolStripMenuItem.Enabled = true;
            }

            if (pictures.Count > 0)
            {
                saveAllToolStripMenuItem.Enabled = true;
            }
            else
            {
                saveAllToolStripMenuItem.Enabled = false;
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetPictureAndCopytoClipboard(Bitmap bitmap)
        {
            pictureBox1.Image = bitmap;
            Clipboard.SetImage(bitmap);
            CreateToast();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {

        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (KeyValuePair<string, Bitmap> keyValuePair in pictures)
                {
                    string fileName = keyValuePair.Key.Replace(":", "_") + ".png";
                    keyValuePair.Value.Save(Path.Combine(folderBrowserDialog1.SelectedPath, fileName));
                }
            }
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PNG Image|*.png";
            saveFileDialog1.Title = "Save Image As...";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
            //test

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null) return;
            Bitmap bitmap = pictures[listBox2.SelectedItem as string];
            SetPictureAndCopytoClipboard(bitmap);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictures.Clear();
            saveAllToolStripMenuItem.Enabled = false;
            pictureBox1.Image = null;
            DrawImages();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private static void CreateToast()
        {
            ToastMessage toast = new ToastMessage();
            toast.Show();
            toast.Position(Cursor.Position.X, Cursor.Position.Y);
        }
    }
}

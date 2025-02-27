
using System.Drawing.Imaging;
using System.Drawing;
using System;
using Timer = System.Windows.Forms.Timer;


namespace ScreenCapture
{
    /*TODO:
     * Autocapture every X Minutes
     * Refactor Code
     */
    public partial class Form1 : Form
    {
        Dictionary<string, Bitmap> pictures = new();
        Screen selectedScreen;
        Timer autoCapture = new();
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
        #region Capture Screen
        private void button1_Click(object sender, EventArgs e)
        {
            CaptureScreen();
        }

        private void AutoCapture_Tick(object? sender, EventArgs e)
        {
            CaptureScreen();
        }

        private void CaptureScreen()
        {
            if (TryCaptureScreen(out Bitmap bmp))
            {
                SetPicture(bmp);
                CopyToClipboard(bmp);
                string key = GenerateKey();
                pictures[key] = bmp;
                DrawSavedImageList();
            }
        }
        bool TryCaptureScreen(out Bitmap bmp)
        {
            bmp = new Bitmap(selectedScreen.Bounds.Width, selectedScreen.Bounds.Height);
            try
            {
                
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(selectedScreen.Bounds.Left, selectedScreen.Bounds.Top, 0, 0, selectedScreen.Bounds.Size);
                    
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion

        private static string GenerateKey()
        {
            return DateTime.Now.ToString("H:mm:ss");//Guid.NewGuid().ToString();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            CopyToClipboard(pictureBox1.Image as Bitmap);
        }


        private void DrawSavedImageList()
        {
            listBox2.Items.Clear();
            UpdateMenuOptions();
            foreach (KeyValuePair<string, Bitmap> keyValuePair in pictures)
            {
                listBox2.Items.Add(keyValuePair.Key);
            }

        }

        /// <summary>
        /// Enables and disables Save as and Save All as needed
        /// </summary>
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


        private void SetPicture(Bitmap bitmap)
        {
            pictureBox1.Image = bitmap;
            CopyToClipboard(bitmap);
        }

        private void CopyToClipboard(Bitmap bitmap)
        {
            Clipboard.SetImage(bitmap);
            CreateToast();
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

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null) return;
            Bitmap bitmap = pictures[listBox2.SelectedItem as string];
            SetPicture(bitmap);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictures.Clear();
            saveAllToolStripMenuItem.Enabled = false;
            pictureBox1.Image = null;
            DrawSavedImageList();
        }
        

        private static void CreateToast()
        {
            ToastMessage toast = new ToastMessage();
            toast.Show();
            toast.Position(Cursor.Position.X, Cursor.Position.Y);
        }

        private void StartAutoCapture(int tickTime)
        {
            autoCapture = new Timer();
            autoCapture.Interval = tickTime;
            autoCapture.Tick += AutoCapture_Tick;
            autoCapture.Start();
        }

        private void StopAutoCapture()
        {
            autoStartButton.Enabled = true;
            autoStopButton.Enabled = false;

            autoStartButton.BackColor = Color.DarkGreen;
            autoStopButton.BackColor = Color.Gray;
                   
            autoMinuteTextBox.Enabled = true;
            autoHourTextBox.Enabled = true;
            autoCapture.Stop();
        }

        private void autoStartButton_Click(object sender, EventArgs e)
        {
            if (TryConvertToMilliSeconds(out int tickTime))
            {
                //Set buttons enabled
                autoStartButton.Enabled = false;
                autoStopButton.Enabled = true;

                autoStartButton.BackColor = Color.Gray;
                autoStopButton.BackColor = Color.Red;

                //Disable changing the times
                autoMinuteTextBox.Enabled = false;
                autoHourTextBox.Enabled = false;
                StartAutoCapture(tickTime);
            }  
        }

        private bool TryConvertToMilliSeconds(out int milliseconds)
        {
            milliseconds = 0;
            if (int.TryParse(autoHourTextBox.Text, out int hour))
            {
                //convert hours to milliseconds
                milliseconds += hour * 60 * 60 * 1000;
            }
            else
            {
                MessageBox.Show($"Cannot convert {autoHourTextBox.Text} to a number");
                return false;
            }
            if (int.TryParse(autoMinuteTextBox.Text, out int minute))
            {
                //convert minutes to milliseconds
                milliseconds += minute * 60 * 1000;
            }
            else
            {
                MessageBox.Show($"Cannot convert {autoMinuteTextBox.Text} to a number");
                return false;
            }
            return true;
        }
        private void autoStopButton_Click(object sender, EventArgs e)
        {
            StopAutoCapture();
        }
    }
}


using System.Drawing.Imaging;
using System.Drawing;
using System;
using Timer = System.Windows.Forms.Timer;
using ScreenCapture.Toast;
using ScreenCapture.Data;
using ScreenCapture.Scheduling;


namespace ScreenCapture
{
    public partial class Form1 : Form
    {
        IPictureList pictureList;
        EventScheduler eventScheduler;
        
        Screen selectedScreen;
        Timer autoCapture = new();

        ToastManager toastManager;
        ContextMenuStrip pictureListContextMenu;


        public Form1()
        {
            InitializeComponent();
            pictureList = new PictureList();
            toastManager = new ToastManager();
            eventScheduler = new EventScheduler();

            UpdateScreenSelection(Screen.AllScreens[0]);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.ShowUpDown = true;
            DrawScheduledCaptures();
            UpdateMenuOptions();

            pictureListContextMenu = new ContextMenuStrip();
            pictureListContextMenu.Opening += PictureListContextMenu_Opening;

            listBox2.ContextMenuStrip = pictureListContextMenu;
        }

        private void PictureListContextMenu_Opening(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if(listBox2.SelectedItem == null) { pictureListContextMenu.Hide(); return; }
            pictureListContextMenu?.Items.Clear();
            var menuItem = new ToolStripMenuItem();
            menuItem.Text = "Rename file";

            menuItem.Click += (sender, e) =>
            {
                //to do: create a rename option...
                pictureList.GetPictureByName(listBox2.SelectedItem.ToString()).Rename("Renamed Picture");
                DrawSavedImageList();
                //redraw on completion
            };
            pictureListContextMenu.Items
                .Add(menuItem);
            
        }

        private void UpdateScreenSelection(Screen selected)
        {
            selectScreenToolStripMenuItem.DropDownItems.Clear();

            selectedScreen = selected;
            foreach (Screen screen in Screen.AllScreens)
            {
                ToolStripMenuItem screenSelect = new ToolStripMenuItem();
                screenSelect.Text = screen.DeviceName;
                selectScreenToolStripMenuItem.DropDownItems.Add(screenSelect);
                if (screen == selected)
                {
                    screenSelect.Checked = true;
                }
                screenSelect.Click += (sender, e) =>
                {
                    UpdateScreenSelection(screen);
                };
            }
        }
        #region Capture Screen
        private void button1_Click(object sender, EventArgs e)
        {
            CaptureScreen();
        }

        private void AutoCapture_Tick(object? sender, EventArgs e)
        {
            autoNextTickLabel.Text = "Next capture: " +
                DateTime.Now.AddMilliseconds(autoCapture.Interval).ToString("H:mm:ss");
            CaptureScreen();
        }

        private void CaptureScreen()
        {
            if (TryCaptureScreen(out Bitmap bmp))
            {
                SetPicture(bmp);
                CopyToClipboard(bmp);
                string key = GenerateKey();
                Picture newPicture = new(key, bmp, Guid.NewGuid().ToString());
                pictureList.AddPicture(newPicture);
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

        private void DrawSavedImageList()
        {
            listBox2.Items.Clear();
            UpdateMenuOptions();
            foreach (Picture picture in pictureList.GetAllPictures())
            {
                listBox2.Items.Add(picture.Name);
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

            if (pictureList.PictureCount() > 0)
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
            UpdateMenuOptions();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            CopyToClipboard(pictureBox1.Image as Bitmap);
        }
        private void CopyToClipboard(Bitmap bitmap)
        {
            Clipboard.SetImage(bitmap);
            toastManager.CreateCopyToast();
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAllPictures();
        }

        private void SaveAllPictures()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (Picture picture in pictureList.GetAllPictures())
                {
                    string fileName = CleanFileName(picture.Name);
                    picture.Image.Save(Path.Combine(folderBrowserDialog1.SelectedPath, fileName));
                }
            }
        }

        private static string CleanFileName(string fileName)
        {
            return fileName.Replace(":", "_") + ".png";
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
            if (pictureBox1.Image == null) return;
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
            
            string pictureName = listBox2.SelectedItem.ToString();
            if (pictureName == null) return;
            if(!pictureList.ContainsPictureByName(pictureName)) return;

            Picture picture = pictureList.GetPictureByName(pictureName);
            Bitmap bitmap = picture.Image;
            SetPicture(bitmap);
            CopyToClipboard(bitmap);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureList.Clear();
            saveAllToolStripMenuItem.Enabled = false;
            pictureBox1.Image = null;
            DrawSavedImageList();
        }

        private void StartAutoCapture(int tickTime)
        {
            autoCapture = new Timer();
            autoCapture.Interval = tickTime;
            autoCapture.Tick += AutoCapture_Tick;
            autoNextTickLabel.Text = "Next capture: " +
                DateTime.Now.AddMilliseconds(tickTime).ToString("H:mm:ss");
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

            autoNextTickLabel.Text = "";

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
      
        private void scheduleButton_Click(object sender, EventArgs e)
        {
            
            DateTime target = dateTimePicker1.Value;
            eventScheduler.ScheduleEvent(target, () =>
            {
                CaptureScreen();
                DrawScheduledCaptures();
            });
            DrawScheduledCaptures();
            
        }

        private void RemoveScheduledTimer(Timer timer)
        {
           
            DrawScheduledCaptures();
        }

        private void AddScheduledCapture(Timer timer, string value)
        {
            
            DrawScheduledCaptures();
        }

        private void DrawScheduledCaptures()
        {
            scheduledCapturesListBox.Items.Clear();

            foreach (string timer in eventScheduler.GetTimes())
            {
                scheduledCapturesListBox.Items.Add(timer);
            }
        }


    }
}

namespace ScreenCapture
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            imageList1 = new ImageList(components);
            splitContainer1 = new SplitContainer();
            listBox1 = new ListBox();
            clearButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            saveFileDialog1 = new SaveFileDialog();
            tableLayoutPanel2 = new TableLayoutPanel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            saveAllToolStripMenuItem = new ToolStripMenuItem();
            toastToolStripMenuItem = new ToolStripMenuItem();
            selectScreenToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            listBox2 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            autoHourTextBox = new TextBox();
            autoHourLabel = new Label();
            autoMinuteLabel = new Label();
            autoMinuteTextBox = new TextBox();
            label1 = new Label();
            autoStartButton = new Button();
            autoStopButton = new Button();
            pictureBox2 = new PictureBox();
            autoNextTickLabel = new Label();
            dateTimePicker1 = new DateTimePicker();
            scheduleButton = new Button();
            scheduledCapturesListBox = new ListBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(787, 108);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(clearButton);
            splitContainer1.Size = new Size(228, 344);
            splitContainer1.SplitterDistance = 265;
            splitContainer1.TabIndex = 6;
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(228, 265);
            listBox1.TabIndex = 5;
            // 
            // clearButton
            // 
            clearButton.Cursor = Cursors.Help;
            clearButton.Dock = DockStyle.Fill;
            clearButton.Location = new Point(0, 0);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(228, 75);
            clearButton.TabIndex = 0;
            clearButton.Text = "CLEAR";
            clearButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(200, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, selectScreenToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(834, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveAsToolStripMenuItem, saveAllToolStripMenuItem, toastToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(123, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // saveAllToolStripMenuItem
            // 
            saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            saveAllToolStripMenuItem.Size = new Size(123, 22);
            saveAllToolStripMenuItem.Text = "Save All";
            saveAllToolStripMenuItem.Click += saveAllToolStripMenuItem_Click;
            // 
            // toastToolStripMenuItem
            // 
            toastToolStripMenuItem.Name = "toastToolStripMenuItem";
            toastToolStripMenuItem.Size = new Size(123, 22);
            toastToolStripMenuItem.Text = "Toast";
            // 
            // selectScreenToolStripMenuItem
            // 
            selectScreenToolStripMenuItem.Name = "selectScreenToolStripMenuItem";
            selectScreenToolStripMenuItem.Size = new Size(88, 20);
            selectScreenToolStripMenuItem.Text = "Select Screen";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(247, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 259);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(677, 27);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(145, 259);
            listBox2.TabIndex = 2;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HotTrack;
            button1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(330, 302);
            button1.Name = "button1";
            button1.Size = new Size(226, 49);
            button1.TabIndex = 3;
            button1.Text = "CAPTURE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Red;
            button2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(677, 302);
            button2.Name = "button2";
            button2.Size = new Size(145, 49);
            button2.TabIndex = 4;
            button2.Text = "CLEAR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // autoHourTextBox
            // 
            autoHourTextBox.Location = new Point(69, 62);
            autoHourTextBox.Name = "autoHourTextBox";
            autoHourTextBox.PlaceholderText = "0";
            autoHourTextBox.Size = new Size(124, 23);
            autoHourTextBox.TabIndex = 5;
            autoHourTextBox.Text = "0";
            // 
            // autoHourLabel
            // 
            autoHourLabel.AutoSize = true;
            autoHourLabel.Location = new Point(16, 65);
            autoHourLabel.Name = "autoHourLabel";
            autoHourLabel.Size = new Size(32, 15);
            autoHourLabel.TabIndex = 6;
            autoHourLabel.Text = "hour";
            // 
            // autoMinuteLabel
            // 
            autoMinuteLabel.AutoSize = true;
            autoMinuteLabel.Location = new Point(16, 99);
            autoMinuteLabel.Name = "autoMinuteLabel";
            autoMinuteLabel.Size = new Size(45, 15);
            autoMinuteLabel.TabIndex = 8;
            autoMinuteLabel.Text = "minute";
            // 
            // autoMinuteTextBox
            // 
            autoMinuteTextBox.Location = new Point(69, 96);
            autoMinuteTextBox.Name = "autoMinuteTextBox";
            autoMinuteTextBox.PlaceholderText = "0";
            autoMinuteTextBox.Size = new Size(124, 23);
            autoMinuteTextBox.TabIndex = 7;
            autoMinuteTextBox.Text = "15";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(2, 27);
            label1.Name = "label1";
            label1.Size = new Size(209, 25);
            label1.TabIndex = 9;
            label1.Text = "Auto Capture Settings";
            // 
            // autoStartButton
            // 
            autoStartButton.BackColor = Color.DarkGreen;
            autoStartButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            autoStartButton.ForeColor = SystemColors.ButtonHighlight;
            autoStartButton.Location = new Point(39, 125);
            autoStartButton.Name = "autoStartButton";
            autoStartButton.Size = new Size(61, 41);
            autoStartButton.TabIndex = 10;
            autoStartButton.Text = "START\r\n";
            autoStartButton.UseVisualStyleBackColor = false;
            autoStartButton.Click += autoStartButton_Click;
            // 
            // autoStopButton
            // 
            autoStopButton.BackColor = Color.Gray;
            autoStopButton.Enabled = false;
            autoStopButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            autoStopButton.ForeColor = SystemColors.ButtonHighlight;
            autoStopButton.Location = new Point(116, 125);
            autoStopButton.Name = "autoStopButton";
            autoStopButton.Size = new Size(61, 41);
            autoStopButton.TabIndex = 11;
            autoStopButton.Text = "STOP";
            autoStopButton.UseVisualStyleBackColor = false;
            autoStopButton.Click += autoStopButton_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.LightGray;
            pictureBox2.Location = new Point(3, 52);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(216, 114);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            // 
            // autoNextTickLabel
            // 
            autoNextTickLabel.AutoSize = true;
            autoNextTickLabel.Location = new Point(15, 238);
            autoNextTickLabel.Name = "autoNextTickLabel";
            autoNextTickLabel.Size = new Size(0, 15);
            autoNextTickLabel.TabIndex = 13;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.Location = new Point(11, 212);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 14;
            // 
            // scheduleButton
            // 
            scheduleButton.Location = new Point(136, 238);
            scheduleButton.Name = "scheduleButton";
            scheduleButton.Size = new Size(75, 23);
            scheduleButton.TabIndex = 15;
            scheduleButton.Text = "Schedule";
            scheduleButton.UseVisualStyleBackColor = true;
            scheduleButton.Click += scheduleButton_Click;
            // 
            // scheduledCapturesListBox
            // 
            scheduledCapturesListBox.FormattingEnabled = true;
            scheduledCapturesListBox.ItemHeight = 15;
            scheduledCapturesListBox.Location = new Point(11, 272);
            scheduledCapturesListBox.Name = "scheduledCapturesListBox";
            scheduledCapturesListBox.Size = new Size(200, 79);
            scheduledCapturesListBox.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 184);
            label2.Name = "label2";
            label2.Size = new Size(168, 25);
            label2.TabIndex = 17;
            label2.Text = "Schedule Capture";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(834, 361);
            Controls.Add(label2);
            Controls.Add(scheduledCapturesListBox);
            Controls.Add(scheduleButton);
            Controls.Add(dateTimePicker1);
            Controls.Add(autoNextTickLabel);
            Controls.Add(autoStopButton);
            Controls.Add(autoStartButton);
            Controls.Add(label1);
            Controls.Add(autoMinuteLabel);
            Controls.Add(autoMinuteTextBox);
            Controls.Add(autoHourLabel);
            Controls.Add(autoHourTextBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            Controls.Add(pictureBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Screen Capture";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ImageList imageList1;
        private OpenFileDialog openFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private SplitContainer splitContainer1;
        private ListBox listBox1;
        private Button clearButton;
        private SaveFileDialog saveFileDialog1;
        private TableLayoutPanel tableLayoutPanel2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem saveAllToolStripMenuItem;
        private PictureBox pictureBox1;
        private ListBox listBox2;
        private Button button1;
        private Button button2;
        private ToolStripMenuItem selectScreenToolStripMenuItem;
        private ToolStripMenuItem toastToolStripMenuItem;
        private TextBox autoHourTextBox;
        private Label autoHourLabel;
        private Label autoMinuteLabel;
        private TextBox autoMinuteTextBox;
        private Label label1;
        private Button autoStartButton;
        private Button button3;
        private Button autoStopButton;
        private PictureBox pictureBox2;
        private Label autoNextTickLabel;
        private ToolStripComboBox testToolStripMenuItem;
        private DateTimePicker dateTimePicker1;
        private Button scheduleButton;
        private ListBox scheduledCapturesListBox;
        private Label label2;
    }
}

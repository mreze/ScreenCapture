namespace ScreenCapture
{
    partial class ToastMessage
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
            components = new System.ComponentModel.Container();
            mainText = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            subText = new Label();
            panelColor = new Panel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // mainText
            // 
            mainText.AutoSize = true;
            mainText.BackColor = Color.Transparent;
            mainText.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mainText.Location = new Point(71, 9);
            mainText.Name = "mainText";
            mainText.Size = new Size(127, 30);
            mainText.TabIndex = 0;
            mainText.Text = "MAIN TEXT";
            // 
            // subText
            // 
            subText.AutoSize = true;
            subText.Location = new Point(71, 41);
            subText.Name = "subText";
            subText.Size = new Size(0, 15);
            subText.TabIndex = 1;
            // 
            // panelColor
            // 
            panelColor.BackColor = SystemColors.Control;
            panelColor.Location = new Point(2, -4);
            panelColor.Name = "panelColor";
            panelColor.Size = new Size(13, 75);
            panelColor.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(21, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 45);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ToastMessage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 67);
            Controls.Add(pictureBox1);
            Controls.Add(panelColor);
            Controls.Add(subText);
            Controls.Add(mainText);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ToastMessage";
            Text = "ToastMessage";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label mainText;
        private System.Windows.Forms.Timer timer1;
        private Label subText;
        private Panel panelColor;
        private PictureBox pictureBox1;
    }
}
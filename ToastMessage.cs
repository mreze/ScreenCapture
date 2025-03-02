using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ScreenCapture
{
    public partial class ToastMessage : Form
    {
        Timer timerDestroy;
        Timer timerMover;
        int yPos = 0;
        int xPos = 0;
        public ToastMessage()
        {
            InitializeComponent();
            timerDestroy = new Timer();
            timerDestroy.Interval = 500;
            timerDestroy.Start();
            timerDestroy.Tick += Timer_Tick;


        }

        private void ToastMessage_Load(object sender, EventArgs e)
        {

        }
        

        private void Mover_Tick(object? sender, EventArgs e)
        {
          
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Close();
        }

        public void SetMainText(string text)
        {
            mainText.Text = text;
        }

        public void SetSubtext(string text)
        {
            subText.Text = text;
        }

        public void SetColor(Color color)
        {
            panelColor.BackColor = color;
        }

        public void SetPosition(Point position)
        {
            Location = position;
        }

    }
}

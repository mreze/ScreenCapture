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

            timerMover = new Timer();
            timerMover.Interval = 10;
            timerMover.Start();
            timerMover.Tick += Mover_Tick;
        }

        private void Mover_Tick(object? sender, EventArgs e)
        {
            yPos -= 5;
            this.Location = new Point(xPos, yPos);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            this.Close();
        }

        public void Position(int x, int y)
        {
            this.Location = new Point(x, y);
            yPos = y;
            xPos = x;
        }


    }
}

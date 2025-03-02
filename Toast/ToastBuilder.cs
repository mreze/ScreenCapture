using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Toast
{
    public class ToastBuilder
    {
        ToastMessage toastMessage = new();
        
        public ToastBuilder()
        {
            Restart();
        }

        public ToastBuilder Restart()
        {
            toastMessage = new ToastMessage();
            
            return this;
        }

        public ToastMessage Build()
        {
            return toastMessage;
        }
        public ToastBuilder WithMainText(string text)
        {
            toastMessage.SetMainText(text);
            return this;
        }

        public ToastBuilder WithSubtext(string text)
        {
            toastMessage.SetSubtext(text);
            return this;
        }

        public ToastBuilder WithColor(Color color)
        {
            toastMessage.SetColor(color);
            return this;
        }

        public ToastBuilder WithPosition(Point position)
        {
            toastMessage.StartPosition = FormStartPosition.Manual;
            toastMessage.Location = position;
            return this;
        }

        public ToastBuilder WithPosition(ToastPosition position)
        {
            toastMessage.StartPosition = FormStartPosition.Manual;
            Point point = new Point();
            Screen toastScreen = Screen.AllScreens[1];

            switch (position)
            {
                
                case ToastPosition.BottomLeft:
                    
                    point.X = toastScreen.WorkingArea.Left;
                    point.Y = toastScreen.WorkingArea.Bottom - toastMessage.Height;
                    
                    break;

                case ToastPosition.TopLeft:
                    point.X = toastScreen.WorkingArea.Left;
                    point.Y = toastScreen.WorkingArea.Top;
                    break; 
                case ToastPosition.TopRight:
                    point.X = toastScreen.WorkingArea.Right - toastMessage.Width;
                    point.Y = toastScreen.WorkingArea.Top;
                    break;


                default:
                case ToastPosition.BottomRight:
                  
                    point.X = toastScreen.WorkingArea.Right-toastMessage.Width;
                    point.Y = toastScreen.WorkingArea.Bottom - toastMessage.Height;
                    
                    break;
                    

            }
            
            toastMessage.Location = point;
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCapture.Toast
{
    public class ToastManager
    {
        ToastBuilder builder;
        //Point toastPosition = new Point();
        bool isActive = true;
        public ToastManager()
        {
            builder = new ToastBuilder();
        }
        public void SetActive(bool active)
        {
            isActive = active;
        }

        public void CreateCopyToast()
        {
            if(!isActive)  return;

            ToastMessage toast = builder.Restart()
                .WithMainText("Copied!")
                .WithColor(Color.Green)
                .WithPosition(ToastPosition.BottomRight)
                .Build();
            
            toast.Show();      
        }
        public void CreateCopyToast(Point position)
        {
            if (!isActive) return;

            ToastMessage toast = builder.Restart()
                .WithMainText("Copied!")
                .WithColor(Color.Green)
                .WithPosition(position)
                .Build();

            toast.Show();
        }

    }
}

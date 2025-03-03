using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Data
{
    public class Picture
    {
        private string name;
        private Bitmap image;
        private string guid;
        private DateTime timeTaken;

        public string Name => name;
        public string Guid => guid;
        public Bitmap Image => image;
        public DateTime TimeTaken => timeTaken;

        public Picture(string name, Bitmap image, string guid)
        {
            this.name = name;
            this.image = image;
            this.guid = guid;
            timeTaken = DateTime.Now;
        }

        public void Rename(string newName)
        {
            if (this.name == newName) { return; }
            this.name = newName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenCapture.Data
{
    public interface IPictureList
    {
        public void AddPicture(Picture picture);
        public bool ContainsPictureByGuid(string guid);
        public bool ContainsPictureByName(string name);
        public void RemovePicture(Picture picture);
        public void RemovePictureByName(string name);
        public void RemovePictureByGuid(string guid);
        public Picture GetPictureByGuid(string guid);
        public Picture GetPictureByName(string name);

        public IEnumerable<Picture> GetAllPictures();

        public void Clear();
        public int PictureCount();

    }
}

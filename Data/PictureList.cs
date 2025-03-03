using System;
using System.Linq;
using System.Xml.Linq;

namespace ScreenCapture.Data
{
    public class PictureList : IPictureList
    {
        List<Picture> pictureList;

        public PictureList()
        {
            pictureList = new List<Picture>();
        }

        public PictureList(List<Picture> pictureList)
        {
            this.pictureList = pictureList;
        }
        public void AddPicture(Picture picture)
        {
            pictureList.Add(picture);
        }

        public bool ContainsPictureByGuid(string guid)
        {
            return pictureList.Any(p => p.Guid == guid);
        }

        public bool ContainsPictureByName(string name)
        {
            return pictureList.Any(p => p.Name == name);
        }

        public IEnumerable<Picture> GetAllPictures()
        {
            return pictureList;
        }

        public Picture GetPictureByGuid(string guid)
        {
            return pictureList.Where(p => p.Guid == guid).First();
        }

        public Picture GetPictureByName(string name)
        {
            return pictureList.Where(p => p.Name == name).First();
        }

        public int PictureCount()
        {
            return pictureList.Count();
        }

        public void Clear()
        {
            pictureList.Clear();
        }
        public void RemovePicture(Picture picture)
        {
            pictureList.Remove(picture);
        }

        public void RemovePictureByGuid(string guid)
        {
            throw new NotImplementedException();
        }

        public void RemovePictureByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

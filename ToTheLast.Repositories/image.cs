using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Nightjar.ToTheLast.Entities;
using Nightjar.ToTheLast.DAL.Access;

namespace Nightjar.ToTheLast.DAL
{
    public class ImageDAC:IImageDAC
    {
        #region IImageDAC Members

        public IList<Image> Get(int galleryID)
        {
            IList<Image> images=new List<Image>();

            using (SprocWrapper db = new SprocWrapper())
            {
                using (IDataReader reader = db.Image_Get("GalleryID="+galleryID.ToString(),"SortOrder ASC"))
                {
                    int total;
                    FillImageCollection(reader, images, 0, Int32.MaxValue, out total);
                }
            }

            return images;
        }

        public Image GetImage(int imageID)
        {
            IList<Image> images = new List<Image>();

            using (SprocWrapper db = new SprocWrapper())
            {
                using (IDataReader reader = db.Image_Get("ImageID="+imageID.ToString(),null))
                {
                    int total;
                    FillImageCollection(reader, images, 0, Int32.MaxValue, out total);
                }
            }

            if (images.Count == 1)
                return images[0];
            else
                return null;
        }

        public void Add(string filename, string title, int galleryID, int sortOrder)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                db.Image_Insert(filename, title, galleryID,sortOrder);
            }
        }

        public bool Update(int imageID,string title,int sortOrder)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Image_Update(imageID, title,sortOrder);
            }
        }

        public bool Delete(int imageID)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Image_Delete(imageID);
            }
        }

        #endregion

        public void FillImageCollection(IDataReader reader, IList<Image> images, int startIndex, int noRecords, out int totalNoRecords)
        {
            int imageID;
            string filename;
            string title;
            int galleryID;

            int count = 0;

            while (reader.Read())
            {
                if (count < startIndex || noRecords == 0)
                {
                    count++;
                    continue;
                }
                else
                    count++;

                imageID = (Convert.IsDBNull(reader["ImageID"])) ? (int)0 : (System.Int32)reader["ImageID"];
                filename = (Convert.IsDBNull(reader["Filename"])) ? string.Empty : (System.String)reader["Filename"];
                title = (Convert.IsDBNull(reader["Title"])) ? null : (System.String)reader["Title"];
                galleryID = (Convert.IsDBNull(reader["GalleryID"])) ? (int)0 : (System.Int32)reader["GalleryID"];
                images.Add(new Image(imageID, filename, title, galleryID));
                noRecords--;
            }

            totalNoRecords = count;
        }
    }
}

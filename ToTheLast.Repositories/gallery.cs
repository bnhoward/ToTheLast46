using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Nightjar.ToTheLast.Entities;
using Nightjar.ToTheLast.DAL.Access;

namespace Nightjar.ToTheLast.DAL
{
    public class GalleryDAC : IGalleryDAC
    {
        #region IGalleryDAC Members

        public IList<Gallery> Get()
        {
            IList<Gallery> galleries = new List<Gallery>();

            using (SprocWrapper db = new SprocWrapper())
            {
                using (IDataReader reader = db.Gallery_Get(null,"SortOrder ASC"))
                {
                    int total;
                    FillGalleryCollection(reader, galleries, 0, Int32.MaxValue, out total);
                }
            }

            return galleries;
        }

        public Gallery GetGallery(int galleryID)
        {
            IList<Gallery> galleries = new List<Gallery>();

            using (SprocWrapper db = new SprocWrapper())
            {
                using (IDataReader reader = db.Gallery_Get("GalleryID=" + galleryID.ToString(), "SortOrder ASC"))
                {
                    int total;
                    FillGalleryCollection(reader, galleries, 0, Int32.MaxValue, out total);
                }
            }

            if (galleries.Count == 1)
                return galleries[0];
            else
                return null;
        }

        public void Add(string name, string description, int sortOrder)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                db.Gallery_Insert(name, description, sortOrder);
            }
        }

        public bool Update(int galleryID, string name, string description, int sortOrder, string displayImage)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Gallery_Update(galleryID, name, description, sortOrder, displayImage);
            }
        }

        public bool Delete(int galleryID)
        {
            using (SprocWrapper db = new SprocWrapper())
            {
                return db.Gallery_Delete(galleryID);
            }
        }

        #endregion

        public void FillGalleryCollection(IDataReader reader, IList<Gallery> galleries, int startIndex, int noRecords, out int totalNoRecords)
        {
            int galleryID;
            string name;
            string description;
            int sortOrder;
            string displayImage;

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

                galleryID = (Convert.IsDBNull(reader["GalleryID"])) ? (int)0 : (System.Int32)reader["GalleryID"];
                name = (Convert.IsDBNull(reader["Name"])) ? string.Empty : (System.String)reader["Name"];
                description = (Convert.IsDBNull(reader["Description"])) ? null : (System.String)reader["Description"];
                sortOrder = (Convert.IsDBNull(reader["SortOrder"])) ? (int)0 : (System.Int32)reader["SortOrder"];
                displayImage = (Convert.IsDBNull(reader["DisplayImage"])) ? null : (System.String)reader["DisplayImage"];
                galleries.Add(new Gallery(galleryID, name, description, sortOrder,displayImage));
                noRecords--;
            }

            totalNoRecords = count;
        }
    }
}

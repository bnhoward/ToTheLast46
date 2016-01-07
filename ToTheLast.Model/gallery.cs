using System;
using System.Collections.Generic;
using System.Text;

namespace Nightjar.ToTheLast.Entities
{
    public class Gallery:IGallery
    {
        int galleryID,sortOrder;
        string name, description,displayImage;

        public Gallery(int galleryID, string name, string description, int sortOrder,string displayImage)
        {
            this.galleryID = galleryID;
            this.name = name;
            this.description = description;
            this.sortOrder = sortOrder;
            this.displayImage = displayImage;
        }

        #region IGallery Members

        public int GalleryID
        {
            get { return galleryID; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }

        public int SortOrder
        {
            get { return sortOrder; }
        }

        public string DisplayImage
        {
            get { return displayImage; }
        }

        #endregion
    }
}

// This file was generated from the Angels database at 05/12/2007 16:07:44.
using System;
using System.Collections.Generic;
using System.Text;

namespace Nightjar.ToTheLast.Entities
{
    public class Image
    {
        int imageID;
        string filename;
        string title;
        int galleryID;

        public Image(int imageID, string filename, string title, int galleryID)
        {
            this.imageID = imageID;
            this.filename = filename;
            this.title = title;
            this.galleryID = galleryID;
        }

        #region Image Members


        public int ImageID
        {
            get { return imageID; }
        }

        public string Filename
        {
            get { return filename; }
        }

        public string Title
        {
            get { return title; }
        }

        public int GalleryID
        {
            get { return galleryID; }
        }


        #endregion
    }
}


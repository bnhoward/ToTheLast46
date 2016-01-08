using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToTheLast46.Web.Areas.Admin666.Models
{
    public class ImageCreate
    {
        [DisplayName("Image")]
        public string Filename
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }
        [Required]
        public int GalleryID
        {
            get; set;
        }
    }
}
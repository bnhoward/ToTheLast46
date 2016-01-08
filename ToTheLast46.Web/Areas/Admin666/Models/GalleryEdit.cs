using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToTheLast46.Web.Areas.Admin666.Models
{
    public class GalleryEdit
    {
        public int GalleryID { get; set; }
        public string Description
        {
            get; set;
        }
        [Required]
        public string Name
        {
            get; set;
        }
        public string MainImage
        {
            get; set;
        }
        [Required]
        [DisplayName("Order")]
        public int SortOrder
        {
            get; set;
        }
    }
}
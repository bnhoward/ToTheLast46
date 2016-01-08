using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToTheLast46.Web.Areas.Admin666.Models
{
    public class LinkEdit
    {
        public int LinkID
        {
            get; set;
        }
        [Required]
        public string URL
        {
            get; set;
        }
        [Required]
        public string Title
        {
            get; set;
        }
        public string Note
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
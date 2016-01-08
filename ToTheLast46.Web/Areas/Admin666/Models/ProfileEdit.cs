using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToTheLast46.Web.Areas.Admin666.Models
{
    public class ProfileEdit
    {
        public int ProfileID { get; set; }
        [Required]
        public string Name
        {
            get; set;
        }
        [Required]
        [DisplayName("Text")]
        public string ProfileText
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
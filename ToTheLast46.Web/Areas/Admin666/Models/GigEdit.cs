using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToTheLast46.Web.Areas.Admin666.Models
{
    public class GigEdit
    {
        public int GigID
        {
            get; set;
        }
        [Required]
        public string Description
        {
            get; set;
        }
        [Required]
        public string Venue
        {
            get; set;
        }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date
        {
            get; set;
        }
    }
}
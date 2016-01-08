using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToTheLast46.Web.Areas.Admin666.Models
{
    public class GuestbookEdit
    {
        public int GuestbookID
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Comment
        {
            get; set;
        }
        [Required]
        public string Reply
        {
            get; set;
        }
        [Required]
        public bool Display
        {
            get; set;
        }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date
        {
            get; set;
        }
    }
}
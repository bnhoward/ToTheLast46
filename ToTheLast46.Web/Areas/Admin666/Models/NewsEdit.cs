using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToTheLast46.Web.Areas.Admin666.Models
{
    public class NewsEdit
    {
        public int NewsID
        {
            get; set;
        }
        [Required]
        public string Subject
        {
            get; set;
        }
        [Required]
        [DisplayName("Text")]
        public string NewsText
        {
            get; set;
        }

        [DisplayName("Date Created")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateCreated
        {
            get; set;
        }
    }
}
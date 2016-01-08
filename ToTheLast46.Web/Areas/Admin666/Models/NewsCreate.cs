using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToTheLast46.Web.Areas.Admin666.Models
{
    public class NewsCreate
    {
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
    }
}
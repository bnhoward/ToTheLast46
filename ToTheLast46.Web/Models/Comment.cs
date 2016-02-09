using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToTheLast46.Web.Models
{
    public class GuestbookComment
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Please add a comment")]
        [DisplayName("Comment")]
        public string Com { get; set; }
    }
}
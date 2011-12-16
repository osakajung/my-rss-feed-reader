using System.ComponentModel.DataAnnotations;
using RSSFeedDesktop.Tools;

namespace RSSFeedDesktop.Model
{
    public class LogOnModel : DataError
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User email")]
        public string UserEmail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}

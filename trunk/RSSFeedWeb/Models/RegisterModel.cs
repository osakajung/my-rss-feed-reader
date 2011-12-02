using System.ComponentModel.DataAnnotations;

namespace RSSFeedWeb.Models
{
    public class RegisterModel
    {
        //[Required]
        //[Display(Name = "User name")]
        //public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public bool Register()
        {
            AccountService.AccountManagerClient client = new AccountService.AccountManagerClient();
            return client.Register(this.Email, Tools.MD5Hash(this.Password));
        }
    }
}

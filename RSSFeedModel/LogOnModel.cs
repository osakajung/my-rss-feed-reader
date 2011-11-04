using System.ComponentModel.DataAnnotations;

namespace RSSFeedModel
{
    public class LogOnModel
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

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }

        public bool LogOn()
        {
            RSSAccountManagerService.RssFeedAccountManagerClient client = new RSSAccountManagerService.RssFeedAccountManagerClient();
            var res = client.logOn(this.UserEmail, Tools.MD5Hash(this.Password), 0);
            if (res == null)
                return false;
            return true;
        }
    }
}

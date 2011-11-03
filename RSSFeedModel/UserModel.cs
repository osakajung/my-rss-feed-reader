using System;
using System.ComponentModel.DataAnnotations;

namespace RSSFeedModel
{
    public class UserModel
    {
        public Int64 Id { get; set; }

        [Required]
        [Display(Name = "Email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool Connected { get; set; }

        [Required]
        public RoleModel Role { get; set;}

        [Required]
        public StatusModel Status { get; set; }
    }
}

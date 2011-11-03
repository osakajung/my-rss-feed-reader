using System;
using System.ComponentModel.DataAnnotations;

namespace RSSFeedModel
{
    public class RoleModel
    {
        public Int64 Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string Name { get; set; }
    }
}

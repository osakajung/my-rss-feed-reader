using System.ComponentModel.DataAnnotations;

namespace RSSFeedWeb.Models
{
    public class NewFeedModel
    {
        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Feed link")]
        public string Address { get; set; }
    }
}

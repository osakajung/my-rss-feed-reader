using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RSSFeedModel
{
    public class NewFeedModel
    {
        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Feed link")]
        public string Address { get; set; }
    }
}

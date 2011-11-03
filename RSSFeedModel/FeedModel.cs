using System;
using System.ComponentModel.DataAnnotations;

namespace RSSFeedModel
{
    public class FeedModel
    {
        public Int64 Id { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string Address { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public CategoryModel Category { get; set; }
    }
}

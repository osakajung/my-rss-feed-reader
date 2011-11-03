using System;
using System.ComponentModel.DataAnnotations;

namespace RSSFeedModel
{
    public class ItemModel
    {
        public Int64 Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Url)]
        public string Link { get; set; }

        public string Description { get; set; }

        public FeedModel Feed { get; set; }
    }
}

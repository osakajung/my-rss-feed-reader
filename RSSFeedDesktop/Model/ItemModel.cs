using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSSFeedDesktop.Model
{
    public class ItemModel
    {
        public Int64 Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime Date { get; set; }
        public FeedModel Feed { get; set; }
    }
}

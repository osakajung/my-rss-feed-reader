using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSSFeedDesktop.Model
{
    public class FeedModel
    {
        public Int64 Id { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public bool isRead { get; set; }
    }
}

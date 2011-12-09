using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RSSFeedPhone.Models
{
    public class FeedModel
    {
        public Int64 Id { get; set; }

        public string Address { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public long NonReadItems { get; set; }

        public FeedModel() { }

        public FeedModel(DataService.FEED feed)
        {
            this.Id = feed.feed_id;
            this.Address = feed.feed_address;
            this.Title = feed.feed_title;
            this.Link = feed.feed_link;
            this.Description = feed.feed_description;
        }
    }
}

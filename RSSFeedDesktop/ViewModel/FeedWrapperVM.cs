using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSFeedDesktop.Model;

namespace RSSFeedDesktop.ViewModel
{
    public class FeedWrapperVM : ViewModelBase
    {
        private FeedModel _feed;

        public FeedModel Feed
        {
            get { return _feed; }
            set 
            { 
                _feed = value;
                OnPropertyChanged(() => Feed);
            }
        }

        public FeedWrapperVM(DataService.FEED feed)
        {
            this.Feed.Id = feed.feed_id;
            this.Feed.Address = feed.feed_address;
            this.Feed.Title = feed.feed_title;
            this.Feed.Link = feed.feed_link;
            this.Feed.Description = feed.feed_description;
            this.Feed.isRead = false;
        }
    }
}

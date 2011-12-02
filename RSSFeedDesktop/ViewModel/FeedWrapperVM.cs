using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSFeedDesktop.Model;
using System.Collections.ObjectModel;
using RSSFeedDesktop.Tools;

namespace RSSFeedDesktop.ViewModel
{
    public class FeedWrapperVM : ViewModelBase
    {
        private FeedModel _feed;
        private ObservableCollection<ItemWrapperVM> _feedItems;
        
        public FeedModel Feed
        {
            get { return _feed; }
            set 
            { 
                _feed = value;
                OnPropertyChanged(() => Feed);
            }
        }

        public ObservableCollection<ItemWrapperVM> FeedItems
        {
            get { return _feedItems; }
            set
            {
                if (_feedItems != value)
                {
                    _feedItems = value;
                    OnPropertyChanged(() => FeedItems);
                }
            }
        }

        public FeedWrapperVM()
        {
            Feed = new FeedModel();
            this.Feed.Id = 0;
            this.Feed.Address = string.Empty;
            this.Feed.Title = string.Empty;
            this.Feed.Link = string.Empty;
            this.Feed.Description = string.Empty;
            this.Feed.isRead = false;
            FeedItems = new ObservableCollection<ItemWrapperVM>();
        }

        public FeedWrapperVM(DataService.FEED feed)
        {
            Feed = new FeedModel();
            this.Feed.Id = feed.feed_id;
            this.Feed.Address = feed.feed_address;
            this.Feed.Title = feed.feed_title;
            this.Feed.Link = feed.feed_link;
            this.Feed.Description = feed.feed_description;
            this.Feed.isRead = false;
            FeedItems = new ObservableCollection<ItemWrapperVM>();
        }

        public void UpdateItems()
        {
            var db = new DataService.RSSFeedDatabaseEntities(new Uri("http://localhost:3152/FeedData.svc/"));
            long id = Feed.Id;
            var items = db.ITEM.Where(p => p.feed_id == id).OrderBy(p => p.feed_id);
            if (items != null)
                FeedItems.Clear();
            foreach (var item in items)
            {
                FeedItems.Add(new ItemWrapperVM(item));
            }
        }
    }
}

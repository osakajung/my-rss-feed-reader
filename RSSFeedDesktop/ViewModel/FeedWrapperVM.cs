using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSFeedDesktop.Model;
using System.Collections.ObjectModel;
using RSSFeedDesktop.Tools;
using System.Configuration;

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

        public void UpdateItems(string email)
        {
            var db = new DataService.RSSFeedDatabaseEntities(new Uri(ConfigurationManager.AppSettings["UrlDataService"]));
            try
            {
                var user = db.USER.Expand("FEED").Expand("ITEM").Where(p => p.user_email == email).FirstOrDefault();
                long id = Feed.Id;
                var feeditems = db.ITEM.Where(i => i.feed_id == id).ToList();
                var useritems = user.ITEM.ToList();
                var NonReadItems = feeditems.Except(useritems).ToList();
                var ReadItems = feeditems.Intersect(useritems).ToList();
                if (NonReadItems != null || ReadItems != null)
                    FeedItems.Clear();
                foreach (var item in NonReadItems)
                    FeedItems.Add(new ItemWrapperVM(item, false));
                foreach (var item in ReadItems)
                    FeedItems.Add(new ItemWrapperVM(item, true));
                FeedItems = new ObservableCollection<ItemWrapperVM>(FeedItems.OrderByDescending(f => f.Item.Date));
            }
            catch (Exception)
            {
            }
        }
    }
}

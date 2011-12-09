using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Data.Services.Client;
using RSSFeedDesktop.Tools;
using RSSFeedDesktop.DataService;

namespace RSSFeedDesktop.ViewModel
{
    public class RssManagerVM : ViewModelBase
    {
        private bool isLoaded;
        public event EventHandler LogOffCompleted;
        private ICommand _logOffCommand;
        private ICommand _addFeedCommand;
        private ICommand _updateBrowserCommand;
        private ICommand _removeFeedCommand;
        private ICommand _updateFeedCommand;
        private ICommand _updateFeedFromWebCommand;
        private ICommand _markAsReadFeedCommand;
        private ObservableCollection<FeedWrapperVM> _feeds;
        private FeedWrapperVM _feedSelected;
        private ItemWrapperVM _itemSelected;
        private string _feedUrl;
        private Uri _urlSource;

        #region Property Notified
        public Uri UrlSource
        {
            get { return _urlSource; }
            set
            {
                _urlSource = value;
                OnPropertyChanged(() => UrlSource);
            }
        }

        public ItemWrapperVM ItemSelected
        {
            get 
            {
                readItem(_itemSelected);
                return _itemSelected;
            }
            set
            {
                _itemSelected = value;
                OnPropertyChanged(() => ItemSelected);
            }
        }

        public string FeedUrl
        {
            get { return _feedUrl; }
            set
            {
                _feedUrl = value;
                OnPropertyChanged(() => FeedUrl);
            }
        }

        public FeedWrapperVM FeedSelected
        {
            get { return _feedSelected; }
            set
            {
                _feedSelected = value;
                try
                {
                    _feedSelected.UpdateItems(AccountVM.email);
                }
                catch (Exception)
                {}
                OnPropertyChanged(() => FeedSelected);
            }
        }

        public ObservableCollection<FeedWrapperVM> Feeds
        {
            get { return _feeds; }
            set
            {
                if (_feeds != value)
                {
                    _feeds = value;
                    OnPropertyChanged(() => Feeds);
                }
            }
        }

        #region Command
        public ICommand UpdateBrowserCommand
        {
            get
            {
                if (_updateBrowserCommand == null)
                {
                    _updateBrowserCommand = new RelayCommand<object>(UpdateBrowserAction, null);
                }

                return _updateBrowserCommand;
            }
        }

        public ICommand UpdateFeedFromWebCommand
        {
            get
            {
                if (_updateFeedFromWebCommand == null)
                {
                    _updateFeedFromWebCommand = new RelayCommand<object>(UpdateFeedFromWebAction, null);
                }

                return _updateFeedFromWebCommand;
            }
        }

        public ICommand LogOffCommand
        {
            get
            {
                if (_logOffCommand == null)
                {
                    _logOffCommand = new RelayCommand<object>(LogOffAction, null);
                }

                return _logOffCommand;
            }
        }

        public ICommand AddFeedCommand
        {
            get
            {
                if (_addFeedCommand == null)
                {
                    _addFeedCommand = new RelayCommand<object>(AddFeedAction, null);
                }

                return _addFeedCommand;
            }
        }

        public ICommand RemoveFeedCommand
        {
            get
            {
                if (_removeFeedCommand == null)
                {
                    _removeFeedCommand = new RelayCommand<object>(RemoveFeedAction, null);
                }

                return _removeFeedCommand;
            }
        }

        public ICommand MarkAsReadFeedCommand
        {
            get
            {
                if (_markAsReadFeedCommand == null)
                {
                    _markAsReadFeedCommand = new RelayCommand<object>(MarkAsReadFeedAction, null);
                }

                return _markAsReadFeedCommand;
            }
        }

        public ICommand UpdateFeedCommand
        {
            get
            {
                if (_updateFeedCommand == null)
                {
                    _updateFeedCommand = new RelayCommand<object>(UpdateFeedAction, null);
                }

                return _updateFeedCommand;
            }
        }
        #endregion
        #endregion

        public RssManagerVM()
        {
            Feeds = new ObservableCollection<FeedWrapperVM>();
            FeedSelected = new FeedWrapperVM();
            isLoaded = false;
        }

        #region Command method
        private void AddFeedAction(object parameter)
        {
            string feedUrl = (string)parameter;
            if (!string.IsNullOrEmpty(feedUrl))
            {
                ParserService.FeedParserClient parser = new ParserService.FeedParserClient();
                parser.parseFeed(feedUrl, AccountVM.email);
                UpdateFeedAction(feedUrl);
            }
        }

        private void LogOffAction(object parameter)
        {
            AccountService.AccountManagerClient client = new AccountService.AccountManagerClient();
            if (this.LogOffCompleted != null && client.logOff(AccountVM.email))
            {
                this.LogOffCompleted.Invoke(this, EventArgs.Empty);
                isLoaded = false;
            }
        }

        private void RemoveFeedAction(object param)
        {
            FeedWrapperVM feed = (FeedWrapperVM)param;
            ParserService.FeedParserClient parser = new ParserService.FeedParserClient();
            parser.deleteFeed((int)feed.Feed.Id, AccountVM.email);
            UpdateFeedAction(null);
        }

        private void MarkAsReadFeedAction(object param)
        {
            FeedWrapperVM feed = (FeedWrapperVM)param;
            ParserService.FeedParserClient parser = new ParserService.FeedParserClient();
            parser.readFeed((int)feed.Feed.Id, AccountVM.email);
            foreach (ItemWrapperVM item in feed.FeedItems)
                item.Item.IsRead = true;
        }

        private void UpdateFeedAction(object param)
        {
            DataService.RSSFeedDatabaseEntities db = new DataService.RSSFeedDatabaseEntities(new Uri("http://localhost:3152/FeedData.svc/"));
            string email = AccountVM.email;
            var user = db.USER.Expand("FEED").Where(p => p.user_email == email).FirstOrDefault();
            DataServiceCollection<DataService.FEED> feeds = null;
            if (user != null)
                feeds = user.FEED;
            if (feeds != null)
                Feeds.Clear();
            foreach (var item in feeds)
            {
                Feeds.Add(new FeedWrapperVM(item));
            }
            if (Feeds.Count > 0)
            {
                Feeds.ElementAt(0).UpdateItems(AccountVM.email);
                FeedSelected = Feeds.ElementAt(0);
            }
            if (!isLoaded)
                UpdateFeedFromWebAction(null);
        }

        private void UpdateBrowserAction(object param)
        {
            if (_itemSelected != null)
                UrlSource = new Uri(_itemSelected.Item.Link.ToString());
        }

        private void readItem(ItemWrapperVM _itemToRead)
        {
            if (_itemToRead != null)
            { 
                DataService.RSSFeedDatabaseEntities db = new DataService.RSSFeedDatabaseEntities(new Uri("http://localhost:3152/FeedData.svc/"));
                string email = AccountVM.email;
                USER user = db.USER.Expand("ITEM").Where(u => u.user_email == email).FirstOrDefault();
                string link = _itemToRead.Item.Link;
                var item = db.ITEM.Where(i => i.item_link == link).ToList().Except(db.USER.Where(u => u.user_email == email).FirstOrDefault().ITEM).FirstOrDefault();
                if (user != null && item != null)
                {
                    db.AddLink(user, "ITEM", item);
                    db.SaveChanges();
                }
                _itemToRead.Item.IsRead = true;
            }
        }

        private void UpdateFeedFromWebAction(object param)
        {
            ParserService.FeedParserClient parser = new ParserService.FeedParserClient();
            foreach (FeedWrapperVM feed in Feeds)
            {
                parser.parseFeed(feed.Feed.Address, AccountVM.email);
            }        
            isLoaded = true;
            UpdateFeedAction(_feedSelected.Feed.Address);
        }
        #endregion
    }
}

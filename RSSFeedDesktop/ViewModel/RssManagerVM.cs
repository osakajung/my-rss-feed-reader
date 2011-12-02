using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Data.Services.Client;

namespace RSSFeedDesktop.ViewModel
{
    public class RssManagerVM : ViewModelBase
    {
        public event EventHandler LogOffCompleted;
        private ICommand _logOffCommand;
        private ICommand _addFeedCommand;
        private ICommand _removeFeedCommand;
        private ICommand _updateFeedCommand;
        private ICommand _markAsReadFeedCommand;
        private ObservableCollection<FeedWrapperVM> _feeds;
        private ObservableCollection<ItemWrapperVM> _feedItems;
        private FeedWrapperVM _feedSelected;

        public FeedWrapperVM FeedSelected
        {
            get { return _feedSelected; }
            set
            {
                _feedSelected = value;
                _feedSelected.UpdateItems();
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

        public RssManagerVM()
        {
            Feeds = new ObservableCollection<FeedWrapperVM>();
            FeedItems = new ObservableCollection<ItemWrapperVM>();
            FeedSelected = new FeedWrapperVM();
        }

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
            }
        }

        private void RemoveFeedAction(object param)
        {
            //remove feed service method;
            ;
        }

        private void MarkAsReadFeedAction(object param)
        {
            //mark all article as read service method;
            ;
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
                Feeds.ElementAt(0).UpdateItems();
                FeedSelected = Feeds.ElementAt(0);
            }
        }
    }
}

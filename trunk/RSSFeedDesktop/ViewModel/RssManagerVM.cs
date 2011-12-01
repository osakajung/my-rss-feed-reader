using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RSSFeedModel;

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
        private ObservableCollection<FeedModel> _feeds;
        private ObservableCollection<ItemModel> _feedItems;

        public ObservableCollection<FeedModel> Feeds
        {
            get { return _feeds; }
            set
            {
                if (_feeds != value)
                {
                    _feeds = value;
                    OnPropertyChanged("Feeds");
                }
            }
        }

        public ObservableCollection<ItemModel> FeedItems
        {
            get { return _feedItems; }
            set
            {
                if (_feedItems != value)
                {
                    _feedItems = value;
                    OnPropertyChanged("FeedItems");
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
            Feeds = new ObservableCollection<FeedModel>();
            FeedItems = new ObservableCollection<ItemModel>();
        }

        private void AddFeedAction(object parameter)
        {
            string feedUrl = (string)parameter;
            if (!string.IsNullOrEmpty(feedUrl))
            {
                ParserService.FeedParserClient parser = new ParserService.FeedParserClient();
                parser.parseFeed(feedUrl, AccountVM.email);
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
            //mark all article as read service method;
            ;
        }
    }
}

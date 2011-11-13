using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RSSFeedDesktop.ViewModel
{
    public class RssManagerVM : ViewModelBase
    {
        public event EventHandler LogOffCompleted;
        private ICommand _logOffCommand;
        private ICommand _addFeedCommand;
        private ICommand _removeFeedCommand;
        private ICommand _markAsReadFeedCommand;
        private ObservableCollection<string> _feeds;
        private ObservableCollection<string> _feedItems;

        public ObservableCollection<string> Feeds
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

        public ObservableCollection<string> FeedItems
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

        public RssManagerVM()
        {
            Feeds = new ObservableCollection<string>();
            FeedItems = new ObservableCollection<string>();
            Feeds.Add("rrrrrrrr");
            Feeds.Add("aaaaaaaa");
            Feeds.Add("zzzzzzzz");
            FeedItems.Add("eeeeeeee");
            FeedItems.Add("aaaaaaaa");
            FeedItems.Add("zzzzzzzz");
            FeedItems.Add("jjjjjjjj");
        }

        private void AddFeedAction(object parameter)
        {
            string feedUrl = parameter as string;
            if (!string.IsNullOrEmpty(feedUrl))
            {
                //methode du service pour ajouter un feed
                // Url a ajouter est dans la property FeedURL
            }
        }

        private void LogOffAction(object parameter)
        {
            if (this.LogOffCompleted != null)
            {
                //methode du service pour logOff
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
    }
}

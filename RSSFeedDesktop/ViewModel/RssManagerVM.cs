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

        public RssManagerVM()
        {
            Feeds = new ObservableCollection<FeedModel>();
            FeedItems = new ObservableCollection<ItemModel>();
            Feeds.Add(new FeedModel() { Address = "adress", Description = "description", isRead = true, Title = "titre" });
            Feeds.Add(new FeedModel() { Address = "adress2", Description = "description2", isRead = true, Title = "titre2" });
            Feeds.Add(new FeedModel() { Address = "adress3", Description = "description3", isRead = false, Title = "titre3" });
            FeedItems.Add(new ItemModel(new RSSFeedModel.DataService.ITEM() { item_description = "description article quoi", item_link = "www.google.fr", item_title = "TITRE" }));
            FeedItems.Add(new ItemModel(new RSSFeedModel.DataService.ITEM() { item_description = "description article quoi2", item_link = "www.google.fr", item_title = "TITRE2" }));
            FeedItems.Add(new ItemModel(new RSSFeedModel.DataService.ITEM() { item_description = "description article quoi3", item_link = "www.google.fr", item_title = "TITRE3" }));
            FeedItems.Add(new ItemModel(new RSSFeedModel.DataService.ITEM() { item_description = "description article quoi4", item_link = "www.google.fr", item_title = "TITRE4" }));
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

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
using RSSFeedPhone.Models;
using System.Collections.ObjectModel;
using RSSFeedPhone.Tools;
using System.Data.Services.Client;
using RSSFeedPhone.DataService;
using Microsoft.Phone.Controls;

namespace RSSFeedPhone.ViewModels
{
    public class FeedListViewModel : NotifyPropertyChanged
    {
        #region Properties

        private ObservableCollection<FeedModel> _FeedList;
        public ObservableCollection<FeedModel> FeedList
        {
            get { return _FeedList; }
            set
            {
                if (value != null)
                {
                    _FeedList = value;
                    OnPropertyChanged(() => FeedList);
                }
            }
        }

        private FeedModel _SelectedFeed;
        public FeedModel SelectedFeed
        {
            get { return _SelectedFeed; }
            set
            {
                if (value != null)
                {
                    _SelectedFeed = value;
                    OnPropertyChanged(() => SelectedFeed);
                }
            }
        }

        private ICommand _SelectFeedCommand;
        public ICommand SelectFeedCommand
        {
            get { return _SelectFeedCommand; }
        }

        #endregion

        #region Contructors

        public FeedListViewModel()
        {
            FeedList = new ObservableCollection<FeedModel>();
            _SelectFeedCommand = new DelegateCommand(this.SelectFeedAction);
            DataServiceCollection<FEED> feeds = new DataServiceCollection<FEED>(Tools.Tools.Context());

            feeds.LoadCompleted += (s, e) =>
                {
                    if (e.Error != null)
                        return;
                    foreach (FEED feed in feeds)
                    {
                        FeedList.Add(new FeedModel(feed));
                    }
                };

            string query = "/USER(" + Tools.Tools.UserIdentity + "L)/FEED/";
            feeds.LoadAsync(new Uri(query, UriKind.Relative));
        }

        #endregion

        public void SelectFeedAction(object o)
        {
            var root = App.Current.RootVisual as PhoneApplicationFrame;
            Tools.Tools.SelectedFeedId = SelectedFeed.Id;
            root.Navigate(new Uri("/Views/ItemListView.xaml", UriKind.Relative));
        }
    }
}

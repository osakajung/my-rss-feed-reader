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
using System.Collections.ObjectModel;
using RSSFeedPhone.Models;
using RSSFeedPhone.Tools;
using System.Data.Services.Client;
using RSSFeedPhone.DataService;
using Microsoft.Phone.Tasks;

namespace RSSFeedPhone.ViewModels
{
    public class ItemListViewModel : NotifyPropertyChanged
    {
        #region Properties
        
        private ObservableCollection<ItemModel> _ItemList;
        public ObservableCollection<ItemModel> ItemList
        {
            get { return _ItemList; }
            set
            {
                if (value != null)
                {
                    _ItemList = value;
                    OnPropertyChanged(() => ItemList);
                }
            }
        }

        private ItemModel _SelectedFeedItem;
        public ItemModel SelectedFeedItem
        {
            get { return _SelectedFeedItem; }
            set
            {
                if (value != null)
                {
                    _SelectedFeedItem = value;
                    OnPropertyChanged(() => SelectedFeedItem);
                }
            }
        }

        private ICommand _SelectItemCommand;
        public ICommand SelectItemCommand
        {
            get { return _SelectItemCommand; }
        }

        #endregion

        #region Constructors

        public ItemListViewModel()
        {
            ItemList = new ObservableCollection<ItemModel>();
            _SelectItemCommand = new DelegateCommand(this.ShowItemAction);
            DataServiceCollection<ITEM> items = new DataServiceCollection<ITEM>(Tools.Tools.Context());

            items.LoadCompleted += (s, e) =>
            {
                if (e.Error != null)
                    return;
                foreach (ITEM item in items)
                {
                    ItemList.Add(new ItemModel(item));
                }
            };

            string query = "/FEED(" + Tools.Tools.SelectedFeedId + "L)/ITEM/?$orderby=item_date desc";
            items.LoadAsync(new Uri(query, UriKind.Relative));
        }

        #endregion

        public void ShowItemAction(object o)
        {
            WebBrowserTask wbTask = new WebBrowserTask();
            wbTask.Uri = new Uri(SelectedFeedItem.Link, UriKind.Absolute);
            wbTask.Show();
        }
    }
}

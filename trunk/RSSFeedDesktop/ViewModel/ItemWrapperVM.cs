using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSFeedDesktop.Model;
using RSSFeedDesktop.Tools;
using System.Windows.Input;

namespace RSSFeedDesktop.ViewModel
{
    public class ItemWrapperVM : ViewModelBase
    {
        private ItemModel _item;
        private ICommand _showItemBrowser;

        public ItemModel Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged(() => Item);
            }
        }

        public ICommand ShowItemBrowser
        {
            get
            {
                if (_showItemBrowser == null)
                {
                    _showItemBrowser = new RelayCommand<object>(ShowItemBrowserAction, null);
                }

                return _showItemBrowser;
            }
        }

        private void ShowItemBrowserAction(object param)
        {
            //remove feed service method;
            ;
        }        

        public ItemWrapperVM(bool isRead)
        {
            Item = new ItemModel();
            this.Item.Id = 0;
            this.Item.Title = string.Empty;
            this.Item.Link = string.Empty;
            this.Item.Description = string.Empty;
            this.Item.IsRead = isRead;
            this.Item.Date = DateTime.Now;
        }

        public ItemWrapperVM(DataService.ITEM item, bool isRead)
        {
            Item = new ItemModel();
            this.Item.Id = item.item_id;
            this.Item.Title = item.item_title;
            this.Item.Link = item.item_link;
            this.Item.Description = item.item_description;
            this.Item.IsRead = isRead;
            this.Item.Date = item.item_date;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSFeedDesktop.Model;

namespace RSSFeedDesktop.ViewModel
{
    public class ItemWrapperVM : ViewModelBase
    {
        private ItemModel _item;

        public ItemModel Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged(() => Item);
            }
        }

        public ItemWrapperVM(DataService.ITEM item)
        {
            this.Item.Id = item.item_id;
            this.Item.Title = item.item_title;
            this.Item.Link = item.item_link;
            this.Item.Description = item.item_description;
        }
    }
}

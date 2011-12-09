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

namespace RSSFeedPhone.Models
{
    public class ItemModel
    {
        public Int64 Id { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public ItemModel(DataService.ITEM item)
        {
            this.Id = item.item_id;
            this.Title = item.item_title;
            this.Link = item.item_link;
            this.Description = item.item_description;
            this.PublishDate = item.item_date;
        }
    }
}

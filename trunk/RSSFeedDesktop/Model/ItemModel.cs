using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSFeedDesktop.Tools;

namespace RSSFeedDesktop.Model
{
    public class ItemModel : ViewModelBase
    {
        bool isRead;

        public Int64 Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public bool IsRead
        {
            get { return isRead; }
            set
            {
                isRead = value;
                OnPropertyChanged(() => IsRead);
            }
        }
        public DateTime Date { get; set; }
        public FeedModel Feed { get; set; }
    }
}

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
using RSSFeedPhone.ViewModels;

namespace RSSFeedPhone.Tools
{
    public class Tools
    {
        public static DataService.RSSFeedDatabaseEntities Context()
        {
            return new DataService.RSSFeedDatabaseEntities(new Uri("http://localhost:3152/FeedData.svc/"));
        }

        private static long _UserIdentity;
        public static long UserIdentity
        {
            get { return _UserIdentity; }
            set { _UserIdentity = value; }
        }

        private static long _SelectedFeedId;
        public static long SelectedFeedId
        {
            get { return _SelectedFeedId; }
            set { _SelectedFeedId = value; }
        }
    }
}

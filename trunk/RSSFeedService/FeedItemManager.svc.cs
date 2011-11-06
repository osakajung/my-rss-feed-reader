using System;
using System.Xml;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel.Syndication;
using RSSFeedModel;

namespace RSSFeedService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FeedItemManager" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FeedItemManager : IFeedItemManager
    {
        public List<FeedModel> _rssItems;
        //public List<RssFeedItem> _rssItems;
        public int tmp = 0;
        private RSSFeedDatabaseEntities db = new RSSFeedDatabaseEntities();

        public List<FeedModel> getItemList(string myUrl)
        {
            this._rssItems =  new List<FeedModel>();
            if (String.IsNullOrEmpty(myUrl))
            {
                throw new ArgumentException("You must provide a feed url");
            }

            SyndicationFeed flux;

            XmlReader reader = XmlReader.Create(myUrl);
 
            flux = SyndicationFeed.Load(reader);
 
            foreach (SyndicationItem i in flux.Items)
            {
                //http://news.google.fr/?output=rss
                FeedModel feedItem = new FeedModel();
                feedItem.Description = i.Summary.Text;
                feedItem.Title = i.Title.Text;
                tmp = i.Links.Count;
                feedItem.Link = i.Links[0].Uri.ToString();
                feedItem.Address = myUrl;

                var res =
                        (from item in db.FEED
                        where item.feed_link == feedItem.Link
                        select item).FirstOrDefault();

                if (res == null)
                    feedItem.isRead = false;
                else
                    feedItem.isRead = true;                        

                _rssItems.Add(feedItem);
            }
            return _rssItems;
        }
    }
}

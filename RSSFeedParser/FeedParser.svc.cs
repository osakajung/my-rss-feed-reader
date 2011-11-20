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

namespace RSSFeedParser
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FeedItemManager" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FeedParser : IFeedParser
    {
        public int tmp = 0;
        private RSSFeedData.DataService.RSSFeedDatabaseEntities db = new RSSFeedData.DataService.RSSFeedDatabaseEntities(new Uri("http://localhost:3152/FeedData.svc/"));

        public void parseFeed(string myUrl)
        {
            if (String.IsNullOrEmpty(myUrl))
            {
                throw new ArgumentException("You must provide a feed url");
            }

            SyndicationFeed flux;

            XmlReader reader = XmlReader.Create(myUrl);
 
            flux = SyndicationFeed.Load(reader);

            // TODO : Ajout FEED dans BDD

            foreach (SyndicationItem i in flux.Items)
            {
                //http://news.google.fr/?output=rss
                ITEM feedItem = new ITEM();
                feedItem.item_description = i.Summary.Text;
                feedItem.item_title = i.Title.Text;
                tmp = i.Links.Count;
                feedItem.item_link = i.Links[0].Uri.ToString();

                // TODO : Ajout ITEM dans BDD
            }
        }
    }
}

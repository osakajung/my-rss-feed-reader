using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RSSFeedParser
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FeedParser : IFeedParser
    {
        public int tmp = 0;
        private DataService.RSSFeedDatabaseEntities db = new DataService.RSSFeedDatabaseEntities(new Uri("http://localhost:3152/FeedData.svc/"));

        public bool parseFeed(string myUrl)
        {
            if (String.IsNullOrEmpty(myUrl))
            {
                return false;
                throw new ArgumentException("You must provide a feed url");
            }

            SyndicationFeed flux;

            // TODO : checker si c'est bien un flux au bout du lien

            XmlReader reader = XmlReader.Create(myUrl);

            flux = SyndicationFeed.Load(reader);

            // TODO : Ajout FEED dans BDD si pas deja abonne

            foreach (SyndicationItem i in flux.Items)
            {
                //http://news.google.fr/?output=rss
                DataService.ITEM feedItem = new DataService.ITEM();
                feedItem.item_description = i.Summary.Text;
                feedItem.item_title = i.Title.Text;
                tmp = i.Links.Count;
                feedItem.item_link = i.Links[0].Uri.ToString();

                // TODO : Ajout ITEM dans BDD
            }
            return true;
        }
    }
}

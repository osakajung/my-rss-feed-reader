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
using RSSFeedParser.DataService;

namespace RSSFeedParser
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FeedParser : IFeedParser
    {
        public int tmp = 0;
        private DataService.RSSFeedDatabaseEntities db = new DataService.RSSFeedDatabaseEntities(new Uri("http://localhost:3152/FeedData.svc/"));

        private bool FeedExists(string myurl)
        {
            FEED feed = db.FEED.Where(f => f.feed_address == myurl).FirstOrDefault();
            if (feed == null)
                return false;
            return true;
        }

        private bool AlreadyAdded(string url, string email)
        {
            USER user = db.USER.Expand("FEED").Where(u => u.user_email == email).FirstOrDefault();
            if (user == null)
                throw new Exception();
            FEED feed = user.FEED.FirstOrDefault(f => f.feed_address == url);
            if (feed == null)
                return false;
            return true;
        }

        private void AddFeed(SyndicationFeed flux, string url)
        {
            FEED feed = new FEED()
            {
                feed_address = url.Substring(0, ((url.Length > 200) ? 200 : url.Length)),
                feed_description = flux.Description.Text,
                feed_title = flux.Title.Text.Substring(0, ((flux.Title.Text.Length > 200) ? 200 : flux.Title.Text.Length)),
                feed_link = flux.Links.FirstOrDefault().Uri.ToString().Substring(0, ((flux.Links.FirstOrDefault().Uri.ToString().Length > 200) ? 200 : flux.Links.FirstOrDefault().Uri.ToString().Length))
            };
            try
            {
                db.AddToFEED(feed);
                db.SaveChanges();
            }
            catch (Exception){}
        }

        private void AddSubscription(FEED feed, string email)
        {
            if (feed != null)
            {
                USER user = db.USER.Expand("FEED").Where(u => u.user_email == email).FirstOrDefault();
                if (user != null)
                {
                    db.AddLink(user, "FEED", feed);
                    db.SaveChanges();
                }
            }
        }

        public bool parseFeed(string myUrl, string email)
        {
            SyndicationFeed flux;
            XmlReader reader;
            FEED feed = null;

            if (String.IsNullOrEmpty(myUrl))
                return false;
            try
            {
                reader = XmlReader.Create(myUrl);
            }
            catch (Exception)
            {
                return false;
            }

            flux = SyndicationFeed.Load(reader);
            if (FeedExists(myUrl) == false)
                AddFeed(flux, myUrl);
            feed = db.FEED.Expand("ITEM").Where(f => f.feed_address == myUrl).FirstOrDefault();
            try
            {
                if (this.AlreadyAdded(myUrl, email) == false)
                    this.AddSubscription(feed, email);
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            foreach (SyndicationItem i in flux.Items)
            {
                ITEM feedItem = new DataService.ITEM()
                {
                    item_description = i.Summary.Text,
                    item_title = i.Title.Text.Substring(0, ((i.Title.Text.Length > 200) ? 200 : i.Title.Text.Length)),
                    item_link = i.Links[0].Uri.ToString().Substring(0, ((i.Links[0].Uri.ToString().Length > 200) ? 200 : i.Links[0].Uri.ToString().Length)),
                    feed_id = feed.feed_id
                };
                db.AddToITEM(feedItem);
            }
            db.SaveChanges();
            return true;
        }
    }
}

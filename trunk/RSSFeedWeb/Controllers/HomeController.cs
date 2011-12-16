using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using RSSFeedWeb.Models;

namespace RSSFeedWeb.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to RSS Book on the Web !";

            List<FeedModel> list = new List<FeedModel>();

            var ctx = Tools.Context();
            var user = ctx.USER.Expand("FEED").Expand("ITEM").Where(p => p.user_email == User.Identity.Name).FirstOrDefault();
            Collection<DataService.FEED> feeds = null;
            if (user != null)
                feeds = user.FEED;

            ParserService.FeedParserClient client = new ParserService.FeedParserClient();
            
            foreach (var feed in feeds)
            {
                try
                {
                   client.parseFeed(feed.feed_address, User.Identity.Name);
                }
                catch (System.Exception)
                {
                }
                FeedModel feedModel = new FeedModel(feed);
                list.Add(feedModel);
                var items = ctx.ITEM.Where(i => i.feed_id == feed.feed_id).ToList();
                var readItems = user.ITEM.ToList();
                feedModel.NonReadItems = items.Except(readItems).Count();
            }
            return View(list);
        }

        [Authorize]
        public ActionResult Details(int? Id)
        {
            if (!Id.HasValue)
                return RedirectToAction("Index");

            ParserService.FeedParserClient client = new ParserService.FeedParserClient();
            
            var ctx = Tools.Context();
            var feed = (from f in ctx.FEED
                       where f.feed_id == Id
                       select f).FirstOrDefault();
            try
            {
                client.parseFeed(feed.feed_address, User.Identity.Name);
            }
            catch (System.Exception)
            {
            }

            ViewBag.FeedTitle = feed.feed_title;

            var items = from i in ctx.ITEM
                        where i.feed_id == Id
                        orderby i.item_date descending
                        select new ItemModel(i);
            try
            {
                client.readFeed(Id.Value, User.Identity.Name);
            }
            catch (System.Exception)
            {
            }

            return View(items.ToList());
        }

        [Authorize]
        public ActionResult Remove(int? Id)
        {
            if (Id.HasValue)
            {
                ParserService.FeedParserClient client = new ParserService.FeedParserClient();
                try
                {
                    client.deleteFeed(Id.Value, User.Identity.Name);
                }
                catch (System.Exception)
                {
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Read(int? id)
        {
            if (id.HasValue)
            {
                ParserService.FeedParserClient client = new ParserService.FeedParserClient();
                try
                {
                    client.readFeed(id.Value, User.Identity.Name);
                }
                catch (System.Exception)
                {
                }
            } 
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewFeedModel model)
        {
            ParserService.FeedParserClient client = new ParserService.FeedParserClient();
            try
            {
                if (client.parseFeed(model.Address, User.Identity.Name))
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Unable to add feed.");
            }
            catch (System.Exception)
            {
            }
            return View(model);
        }
    }
}

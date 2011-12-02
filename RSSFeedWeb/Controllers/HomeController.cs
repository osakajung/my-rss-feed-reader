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
            var user = ctx.USER.Expand("FEED").Where(p => p.user_email == User.Identity.Name).FirstOrDefault();
            Collection<DataService.FEED> feeds = null;
            if (user != null)
                feeds = user.FEED;
            foreach (var item in feeds)
            {
                list.Add(new FeedModel(item));
            }
            return View(list);
        }

        [Authorize]
        public ActionResult Details(int Id)
        {
            var ctx = Tools.Context();
            var feed = (from f in ctx.FEED
                       where f.feed_id == Id
                       select f).FirstOrDefault();

            ViewBag.FeedTitle = feed.feed_title;

            var items = from i in ctx.ITEM
                        where i.feed_id == Id
                        orderby i.feed_id
                        select new ItemModel(i);

            return View(items.ToList());
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

            if (client.parseFeed(model.Address, User.Identity.Name))
                return RedirectToAction("Index");
            else
                ModelState.AddModelError("", "Unable to add feed.");
            return View(model);
        }
    }
}

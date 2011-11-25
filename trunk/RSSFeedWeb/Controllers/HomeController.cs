using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Data.Services.Client;

namespace RSSFeedWeb.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to RSS Book on the Web !";

            List<RSSFeedModel.FeedModel> list = new List<RSSFeedModel.FeedModel>();

            var ctx = RSSFeedModel.Tools.context;
            var user = ctx.USER.Expand("FEED").Where(p => p.user_email == User.Identity.Name).FirstOrDefault();
            DataServiceCollection<RSSFeedModel.DataService.FEED> feeds = null;
            if (user != null)
                feeds = user.FEED;
            foreach (var item in feeds)
            {
                list.Add(new RSSFeedModel.FeedModel(item));
            }
            return View(list);
        }

        [Authorize]
        public ActionResult Details(int Id)
        {
            var ctx = RSSFeedModel.Tools.context;
            var feed = (from f in ctx.FEED
                       where f.feed_id == Id
                       select f).FirstOrDefault();

            ViewBag.FeedTitle = feed.feed_title;

            var items = from i in ctx.ITEM
                        where i.feed_id == Id
                        select new RSSFeedModel.ItemModel(i);

            return View(items.ToList());
        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(RSSFeedModel.NewFeedModel model)
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

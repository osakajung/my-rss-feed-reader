using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace RSSFeedWeb.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to RSS Book on the Web !";

            var ctx = RSSFeedModel.Tools.context;

            List<RSSFeedModel.FeedModel> list = new List<RSSFeedModel.FeedModel>();

            // SELECT * FROM FEED WHERE feed_id IN (SELECT feed_id FROM SUBSCRIBE WHERE user_id IN (SELECT user_id FROM USER WHERE user_email = User.Identity.Name))

            var user = ctx.USER.Expand("FEED").Where(p => p.user_email == User.Identity.Name).FirstOrDefault();

            var feeds = user.FEED;

            foreach (var item in feeds)
            {
                list.Add(new RSSFeedModel.FeedModel(item));
            }

            return View(list);
        }

        [Authorize]
        public ActionResult Details(int id)
        {


            return View();
        }
    }
}

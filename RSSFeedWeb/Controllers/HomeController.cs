using System.Linq;
using System.Web.Mvc;

namespace RSSFeedWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            var categories = from m in Tools.context.CATEGORY
                        select m;
            return View(categories);
        }

        [Authorize]
        public ActionResult About()
        {
            return View();
        }
    }
}

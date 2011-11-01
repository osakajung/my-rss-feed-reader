using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSSFeedWeb.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            RSSFeedService.RSSFeedDatabaseEntities ctx = new RSSFeedService.RSSFeedDatabaseEntities(new Uri("http://localhost:3152/RSSFeedDataService.svc/"));

            var categories = from m in ctx.CATEGORY
                        select m;
            return View(categories);
        }

        
        public ActionResult About()
        {
            return View();
        }
    }
}

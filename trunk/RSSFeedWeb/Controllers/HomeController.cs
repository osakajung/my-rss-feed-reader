using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RSSFeedWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            // Code pour le cryptage en MD5, à mettre dans une classe outil
            //
            //MD5 md5 = new MD5CryptoServiceProvider();
            //Byte[] originalBytes = Encoding.UTF8.GetBytes("mypass");
            //Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            //StringBuilder result = new StringBuilder();

            //for (int i = 0; i < encodedBytes.Length; i++)
            //{
            //    // Affiche le Hash en hexadecimal 
            //    result.Append(encodedBytes[i].ToString("X2"));
            //}
            //ViewBag.Pass = result.ToString();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}

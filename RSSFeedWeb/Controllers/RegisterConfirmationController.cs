﻿using System.Web.Mvc;

namespace RSSFeedWeb.Controllers
{
    public class RegisterConfirmationController : Controller
    {
        //
        // GET: /RegisterConfirmation/64E1B8D34F425D19E1EE2EA7236D3028

        public ActionResult Index(string key)
        {
            AccountService.AccountManagerClient client = new AccountService.AccountManagerClient();
            bool res = false;
            try
            {
                res = client.RegisterConfirmation(key);
            }
            catch (System.Exception)
            {
            }
            ViewBag.Result = res;
            return View();
        }
    }
}

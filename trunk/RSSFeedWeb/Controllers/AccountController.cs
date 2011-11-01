using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RSSFeedWeb.Models;

namespace RSSFeedWeb.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(RSSFeedService.USER model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in Tools.context.USER
                           where u.user_email == model.user_email
                           && u.user_password == Tools.MD5Hash(model.user_password)
                           select u).FirstOrDefault();

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.user_email, true);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RSSFeedService.USER model)
        {
            if (ModelState.IsValid)
            {
                RSSFeedService.USER user = new RSSFeedService.USER();

                user.user_email = model.user_email;
                user.user_password = Tools.MD5Hash(model.user_password);
                var status = (from s in Tools.context.STATUS
                             where s.status_name == "valid"
                             select s).FirstOrDefault();
                var role = (from r in Tools.context.ROLE
                           where r.role_name == "member"
                           select r).FirstOrDefault();

                user.status_id = status.status_id;
                user.role_id = role.role_id;
               
                Tools.context.AddToUSER(user);
                Tools.context.SaveChanges();
                // Ajouter un check pour ne pas avoir 2 users avec le même mail
                FormsAuthentication.SetAuthCookie(model.user_email, false /* createPersistentCookie */);
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            //if (ModelState.IsValid)
            //{

            //    // ChangePassword will throw an exception rather
            //    // than return false in certain failure scenarios.
            //    bool changePasswordSucceeded;
            //    try
            //    {
            //        MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
            //        changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
            //    }
            //    catch (Exception)
            //    {
            //        changePasswordSucceeded = false;
            //    }

            //    if (changePasswordSucceeded)
            //    {
            //        return RedirectToAction("ChangePasswordSuccess");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
            //    }
            //}
            return RedirectToAction("ChangePasswordSuccess");
            // If we got this far, something failed, redisplay form
            //return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}

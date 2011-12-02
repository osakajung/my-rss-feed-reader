using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Net.Mail;
using System.ServiceModel.Activation;
using System.Net.Mime;
using RSSFeedAccountManager.DataService;


namespace RSSFeedAccountManager
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RssFeedAccountMamager" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AccountManager : IAccountManager
    {
        //RSSFeedDatabaseEntities Context() = new RSSFeedDatabaseEntities(new Uri("http://localhost:3152/FeedData.svc/"));

        public AccountManager()
        {
            Context = new RSSFeedDatabaseEntities(new Uri("http://localhost:3152/FeedData.svc/"));
        }

        public RSSFeedDatabaseEntities Context { get; set; }

        public bool logOn(string email, string password, ClientType clientId)
        {
            if (email == null || password == null)
                return false;
            //password = this.MD5Hash(password);

            var user = (from u in Context.USER
                        where u.user_email == email
                        && u.user_password == password
                        && u.STATUS.status_name == "valid"
                        && u.user_connected == 0
                        select u).FirstOrDefault();
            if (user != null)
            {
                //email = user.user_email;
                user.user_connected = (short)clientId;
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool logOff(string email)
        {
            var user = (from u in Context.USER
                        where u.user_email == email
                        select u).FirstOrDefault();
            if (user != null)
            {
                user.user_connected = 0;
                Context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Register(string email, string password)
        {
            USER model = new USER();
            var status = Context.STATUS.Where(p => p.status_name == "invalid").FirstOrDefault();
            var role = Context.ROLE.Where(p => p.role_name == "member").FirstOrDefault();

            var user = Context.USER.Where(p => p.user_email == email).FirstOrDefault();

            if (status != null && role != null && user == null)
            {
                model.status_id = status.status_id;
                model.role_id = role.role_id;
                model.user_email = email;
                model.user_key = MD5Hash(model.user_email);
                model.user_password = password;
                model.user_connected = 0;
                try
                {
                    Context.AddToUSER(model);
                    Context.SaveChanges();
                    SendConfirmMail(model);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
            else
                return false;
        }

        public bool ChangePassword(string email, string password, string newPassword)
        {
            USER user = Context.USER.Where(p => p.user_email == email).Where(p => p.user_password == password).FirstOrDefault();

            if (user == null)
                return false;
            user.user_password = newPassword;
            try
            {
                Context.UpdateObject(user);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private bool EmailExists(string Email)
        {
            var usr = Context.USER.Where(p => p.user_email == Email).FirstOrDefault();
            if (usr == null)
                return false;
            return true;
        }

        private string MD5Hash(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = Encoding.UTF8.GetBytes(str);
            Byte[] bytes = md5.ComputeHash(originalBytes);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("X2"));
            }
            return result.ToString();
        }

        private void SendConfirmMail(USER model)
        {
            string urlPageToConfirm = "http://localhost:3147/RegisterConfirmation/" + model.user_key;
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress("noReplyRssFeed@gmail.com", "noReplyRssFeed", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(model.user_email);
            MailMessage message = new MailMessage(from, to);
            string body = "<p>Welcome on Rss Feed Project. </p> To activate your account click on the link below: <br /> ";
            body += "<a href='" + urlPageToConfirm + "'>" + urlPageToConfirm + "</a>";

            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            // Add the alternate body to the message.

            AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
            message.AlternateViews.Add(alternate);
            message.Subject = "Register Confirmation";
            message.SubjectEncoding = System.Text.Encoding.Unicode;
            string userState = "Register Confirmation1";
            try
            {
                client.SendAsync(message, userState);
            }
            catch (Exception)
            {

            }
            //message.Dispose();
        }

        public void ResetPassword()
        {
            throw new NotImplementedException();
        }


        public bool RegisterConfirmation(string key)
        {
            var user = (from u in Context.USER
                        where u.user_key == key
                        && u.STATUS.status_name == "invalid"
                        select u).FirstOrDefault();
            if (user != null)
            {
                var status = Context.STATUS.Where(p => p.status_name == "valid").FirstOrDefault();
                user.status_id = status.status_id;
                Context.UpdateObject(user);
                Context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

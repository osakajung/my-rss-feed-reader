﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Security.Cryptography;
using System.ComponentModel;
using System.Net.Mail;

namespace RSSFeedService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RssFeedAccountMamager" in code, svc and config file together.
    public class RssFeedAccountMamager : IRssFeedAccountMamager
    {
        RSSFeedDatabaseEntities db = new RSSFeedDatabaseEntities();

        public USER logOn(USER model)
        {
            var user = (from u in db.USER
                        where u.user_email == model.user_email
                        && u.user_password == model.user_password
                        select u).FirstOrDefault();
            if (user != null)
                user.user_connected = true;
            return user;
        }

        public void logOff(USER model)
        {
            var user = (from u in db.USER
                        where u.user_email == model.user_email
                        && u.user_password == model.user_password
                        select u).FirstOrDefault();
            if (user != null)
                user.user_connected = false;
        }

        public bool Register(USER model)
        {
            var status = db.STATUS.Where(p => p.status_name == "valid").FirstOrDefault();
            var role = db.ROLE.Where(p => p.role_name == "member").FirstOrDefault();

            if (status != null && role != null)
            {
                model.status_id = status.status_id;
                model.role_id = role.role_id;
                model.user_key = MD5Hash(model.user_email);
                model.user_connected = false;
                try
                {
                    db.AddToUSER(model);
                    db.SaveChanges();
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

        public void ChangePassword()
        {

        }

        private bool EmailExists(string Email)
        {
            var usr = db.USER.Where(p => p.user_email == Email).FirstOrDefault();
            if (usr == null)
                return false;
            return true;
        }

        private string MD5Hash(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = Encoding.UTF8.GetBytes(str);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < encodedBytes.Length; i++)
            {
                result.Append(encodedBytes[i].ToString("X2"));
            }
            return result.ToString();
        }

        private void SendConfirmMail(USER model)
        {
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress("noReplyRssFeed@gmail.com", "noReplyRssFeed", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(model.user_email);
            MailMessage message = new MailMessage(from, to);
            message.Body = "Welcome on Rss Feed Project. </ br> To activate your account click on the link below: </ br> ";
            message.Body += "<a href='http://localhost:3147/RegisterConfirmation.asp?key" + model.user_key + "'>http://localhost:3147/RegisterConfirmation.asp?key" + model.user_key + "</a>";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "Register Confirmation";
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            string userState = "Register Confirmation";
            client.SendAsync(message, userState);
            message.Dispose();
        }
        
        public void ResetPassword()
        {
            throw new NotImplementedException();
        }
    }
}
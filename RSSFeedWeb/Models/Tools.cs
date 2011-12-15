using System;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;

namespace RSSFeedWeb.Models
{
    public class Tools
    {
        //public static DataService.RSSFeedDatabaseEntities context = new DataService.RSSFeedDatabaseEntities(new Uri("http://localhost:3152/FeedData.svc/"));

        public static DataService.RSSFeedDatabaseEntities Context()
        {
            return new DataService.RSSFeedDatabaseEntities(new Uri(ConfigurationManager.AppSettings["UrlDataService"].ToString()));
        }

        public static string MD5Hash(string str)
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace RSSFeedWeb
{
    public class Tools
    {
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
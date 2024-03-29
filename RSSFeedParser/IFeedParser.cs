﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RSSFeedParser
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFeedParser" in both code and config file together.
    [ServiceContract]
    public interface IFeedParser
    {
        [OperationContract]
        bool parseFeed(string myUrl, string email);

        [OperationContract]
        void deleteFeed(int id, string email);

        [OperationContract]
        void readFeed(int id, string email);
    }
}

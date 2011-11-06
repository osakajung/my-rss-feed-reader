using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RSSFeedModel;

namespace RSSFeedService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFeedItemManager" in both code and config file together.
    [ServiceContract]
    public interface IFeedItemManager
    {
        [OperationContract]
        List<FeedModel> getItemList(string myUrl);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RSSFeedService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRssFeedAccountMamager" in both code and config file together.
    [ServiceContract]
    public interface IRssFeedAccountMamager
    {
        [OperationContract]
        USER logOn(USER model);
        [OperationContract]
        void logOff(USER model);
        [OperationContract]
        bool Register(USER model);
        [OperationContract]
        void ChangePassword();
        [OperationContract]
        void ResetPassword();
    }
}

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
    public interface IRssFeedAccountManager
    {
        [OperationContract]
        USER logOn(string email, string password);

        [OperationContract]
        bool logOff(string email);
        
        [OperationContract]
        bool Register(string email, string password);
        
        [OperationContract]
        bool ChangePassword(string email, string password, string newPassword);
        
        [OperationContract]
        void ResetPassword();
        [OperationContract]
        bool RegisterConfirmation(string key);
    }
}

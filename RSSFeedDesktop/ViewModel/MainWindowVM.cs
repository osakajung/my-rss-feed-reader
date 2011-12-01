using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSSFeedDesktop.ViewModel
{
    class MainWindowVM
    {
        private AccountVM accountMgr;
        private RssManagerVM rssMgr;

        public RssManagerVM RssMgr
        {
            get 
            {
                if (rssMgr == null)
                    rssMgr = new RssManagerVM();
                return rssMgr; 
            }
        }

        public AccountVM AccountMgr
        {
            get 
            {
                if (accountMgr == null)
                    accountMgr = new AccountVM();
                return accountMgr; 
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using RSSFeedModel;

namespace RSSFeedDesktop.ViewModel
{
    public class AcccountVM : ViewModelBase
    {
        //UserModel _user;
        public ActionCommand LogInCommand { get; private set; }

        //public UserModel User
        //{
        //    get { return _user; }
        //    set
        //    {
        //        if (_user != value)
        //        {
        //            _user = value;
        //            OnPropertyChanged("User");
        //        }
        //    }
        //}

        public AcccountVM()
        {
            LogInCommand = new ActionCommand()
            {
                Action = () =>
                {
                
                }
            };
        }
    }
}

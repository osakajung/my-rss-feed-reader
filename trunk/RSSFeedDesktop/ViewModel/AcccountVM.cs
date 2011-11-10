using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSFeedModel;

namespace RSSFeedDesktop.ViewModel
{
    public class AcccountVM : ViewModelBase
    {
        private LogOnModel _logOn;
        private RegisterModel _register;
        public event EventHandler LoginCompleted;

        public ActionCommand LogInCommand { get; private set; }

        public LogOnModel LogOn
        {
            get { return _logOn; }
            set
            {
                if (_logOn != value)
                {
                    _logOn = value;

                    OnPropertyChanged("LogOn");
                }
            }
        }

        public RegisterModel Register
        {
            get { return _register; }
            set
            {
                if (_register != value)
                {
                    _register = value;
                    OnPropertyChanged("Register");
                }
            }
        }

        public AcccountVM()
        {
            LogOn = new LogOnModel();
            Register = new RegisterModel();
            LogInCommand = new ActionCommand(() => LoginAction());
        }

        private void LoginAction()
        {
            if (LogOn.LogOn(RSSFeedModel.RSSAccountManagerService.ClientType.DesktopClient) && this.LoginCompleted != null)
            {
                this.LoginCompleted.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

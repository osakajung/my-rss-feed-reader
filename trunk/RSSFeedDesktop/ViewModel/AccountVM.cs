using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSFeedModel;
using System.Windows.Input;

namespace RSSFeedDesktop.ViewModel
{
    public class AccountVM : ViewModelBase
    {
        public static string email = "";
        private LogOnModel _logOn;
        private RegisterModel _register;
        public event EventHandler LoginCompleted;

        private ICommand _logInCommand;

        public ICommand LogInCommand
        {
            get
            {
                if (_logInCommand == null)
                {
                    _logInCommand = new RelayCommand<object>(LoginAction, null);
                }

                return _logInCommand;
            }
        }

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

        public AccountVM()
        {
            LogOn = new LogOnModel();
            Register = new RegisterModel();
        }

        private void LoginAction(object param)
        {
            if (/* LogOn.LogOn(RSSFeedModel.AccountService.ClientType.DesktopClient) && */ this.LoginCompleted != null)
            {
                email = LogOn.UserEmail;
                this.LoginCompleted.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

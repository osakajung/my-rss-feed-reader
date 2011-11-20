using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSFeedModel;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel.DataAnnotations;

namespace RSSFeedDesktop.ViewModel
{
    public class AccountVM : ViewModelBase
    {
        public static string email = "";
        private LogOnModel _logOn;
        private RegisterModel _register;
        public event EventHandler LoginCompleted;
        public event EventHandler RegisterCompleted;

        private ICommand _logInCommand;
        private ICommand _registerCommand;

        public ICommand RegisterCommand
        {
            get
            {
                if (_registerCommand == null)
                    _registerCommand = new RelayCommand<object>(RegisterAction, RegisterCanExecute);
                return _registerCommand;
            }
        }

        public ICommand LogInCommand
        {
            get
            {
                if (_logInCommand == null)
                    _logInCommand = new RelayCommand<object>(LoginAction, LoginCanExecute);
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

        private bool LoginCanExecute(object param)
        {
            List<System.ComponentModel.DataAnnotations.ValidationResult> validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            ValidationContext vc = new ValidationContext(LogOn, null, null);
            if (Validator.TryValidateObject(LogOn, vc, validationResults, true) && this.LoginCompleted != null)
            {
                return true;
            }
            return false;
        }

        private void LoginAction(object param)
        {
            if (true/* LogOn.LogOn(RSSFeedModel.AccountService.ClientType.DesktopClient) && */)
            {
                email = LogOn.UserEmail;
                this.LoginCompleted.Invoke(this, EventArgs.Empty);
            }
        }

        private bool RegisterCanExecute(object param)
        {
            List<System.ComponentModel.DataAnnotations.ValidationResult> validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            ValidationContext vc = new ValidationContext(Register, null, null);
            if (Validator.TryValidateObject(Register, vc, validationResults, true) && this.RegisterCompleted != null)
            {
                return true;
            }
            return false;
        }

        private void RegisterAction(object param)
        {
            if (true/* Register.Register() && */)
            {
                //this.RegisterCompleted.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

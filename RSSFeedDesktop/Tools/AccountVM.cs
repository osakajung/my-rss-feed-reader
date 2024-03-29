﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RSSFeedDesktop.Tools;
using System.Windows.Input;
using System.Windows.Controls;
using System.ComponentModel.DataAnnotations;
using RSSFeedDesktop.Model;

namespace RSSFeedDesktop.ViewModel
{
    public class AccountVM : ViewModelBase
    {
        public static string email = string.Empty;
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
                    OnPropertyChanged(() => LogOn);
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
                    OnPropertyChanged(() => Register);
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
            var accountMgr = new AccountService.AccountManagerClient();
            try
            {
                if (this.LoginCompleted != null && accountMgr.logOn(LogOn.UserEmail, Tools.Tools.MD5Hash(LogOn.Password), AccountService.ClientType.DesktopClient))
                {
                    email = LogOn.UserEmail;
                    this.LoginCompleted.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception)
            {
            }

        }

        private bool RegisterCanExecute(object param)
        {
            List<System.ComponentModel.DataAnnotations.ValidationResult> validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            ValidationContext vc = new ValidationContext(Register, null, null);
            if (Validator.TryValidateObject(Register, vc, validationResults, true) && this.RegisterCompleted != null && Register.Password == Register.ConfirmPassword)
            {
                return true;
            }
            return false;
        }

        private void RegisterAction(object param)
        {
            var accountMgr = new AccountService.AccountManagerClient();
            try
            {
                if (accountMgr.Register(Register.Email, Tools.Tools.MD5Hash(Register.Password)))
                {
                    this.RegisterCompleted.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

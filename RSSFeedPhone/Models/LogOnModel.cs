using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using RSSFeedPhone.Tools;

namespace RSSFeedPhone.Models
{
    public class LogOnModel : NotifyPropertyChanged
    {
        #region Constructors

        public LogOnModel()
        {
            this.UserEmail = "admin@admin.com";
            this.Password = "toto42";
            this.ErrorMessage = "";
        }
        
        #endregion

        #region Properties

        private string _UserEmail;
        public string UserEmail
        {
            get { return _UserEmail; }
            set
            {
                if (value != null)
                {
                    _UserEmail = value;
                    OnPropertyChanged(() => UserEmail);
                }
            }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if (value != null)
                {
                    _Password = value;
                    OnPropertyChanged(() => Password);
                }
            }
        }

        private string _ErrorMessage;

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set
            {
                if (value != null)
                {
                    _ErrorMessage = value;
                    OnPropertyChanged(() => ErrorMessage);
                }
            }
        }

        #endregion
    }
}

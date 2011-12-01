using System;
using System.Linq;
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
using RSSFeedPhone.Models;
using Microsoft.Phone.Controls;
using RSSFeedPhone.Tools;
//using RSSFeedPhone.DataService;
using System.Data.Services.Client;

namespace RSSFeedPhone.ViewModels
{
    public class LogOnViewModel : NotifyPropertyChanged
    {
        #region Constructors

        public LogOnViewModel()
        {
            this._Model = new LogOnModel();
            this._LogOnCommand = new DelegateCommand(this.LogOnAction);
        }

        #endregion

        #region Properties

        //public RSSFeedDatabaseEntities Context { get; set; }

        private LogOnModel _Model;
        public LogOnModel Model
        {
            get { return _Model; }
            set
            {
                if (value != null)
                {
                    _Model = value;
                    OnPropertyChanged("Model");
                }
            }
        }

        private ICommand _LogOnCommand;
        public ICommand LogOnCommand
        {
            get { return _LogOnCommand; }
        }

        #endregion

        public void LogOnAction(object o)
        {
            var root = App.Current.RootVisual as PhoneApplicationFrame;
            root.Navigate(new Uri("/Views/FeedListView.xaml", UriKind.Relative));

            //AccountService.AccountManagerClient client = new AccountService.AccountManagerClient();
            //client.logOnCompleted += new EventHandler<AccountService.logOnCompletedEventArgs>(client_logOnCompleted);
            //client.logOnAsync(Model.UserEmail, Model.Password, AccountService.ClientType.MobileClient);
        }

        //void client_logOnCompleted(object sender, AccountService.logOnCompletedEventArgs e)
        //{
        //    if (e.Error == null)
        //    {
        //        if (e.Result != null)
        //        {
        //            var root = App.Current.RootVisual as PhoneApplicationFrame;
        //            root.Navigate(new Uri("Views/FeeLisView.xaml", UriKind.Relative));
        //        }
        //    }
        //}
    }
}

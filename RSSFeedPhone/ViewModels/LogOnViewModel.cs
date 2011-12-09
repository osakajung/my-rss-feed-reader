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
using RSSFeedPhone.DataService;
using System.Data.Services.Client;
using System.Text;

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

        private LogOnModel _Model;
        public LogOnModel Model
        {
            get { return _Model; }
            set
            {
                if (value != null)
                {
                    _Model = value;
                    OnPropertyChanged(() => Model);
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
            DataServiceCollection<USER> users = new DataServiceCollection<USER>(Tools.Tools.Context());

            users.LoadCompleted += (s, e) =>
                {
                    if (e.Error != null)
                    {
                        Model.ErrorMessage = "An error occured !";
                        return;
                    }
                    var user = users.FirstOrDefault();
                    if (user == null)
                    {
                        Model.ErrorMessage = "Cannot connect !";
                        return;
                    }
                    Model.ErrorMessage = "";
                    Tools.Tools.UserIdentity = user.user_id;
                    var root = App.Current.RootVisual as PhoneApplicationFrame;
                    root.Navigate(new Uri("/Views/FeedListView.xaml", UriKind.Relative));
                };

            if (!string.IsNullOrEmpty(Model.UserEmail) && !string.IsNullOrEmpty(Model.Password))
            {
                string query = "/USER?filter=user_email eq '" + Model.UserEmail + "' and user_password eq '" + MD5Core.GetHashString(Model.Password) + "'";
                users.LoadAsync(new Uri(query, UriKind.Relative));
            }
            else
                Model.ErrorMessage = "Some information are missing !";
        }
    }
}

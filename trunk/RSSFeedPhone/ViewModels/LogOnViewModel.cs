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
            // TODO : Rendre le context disponible pour tout le monde
            this.Context = new RSSFeedDatabaseEntities(new Uri("http://localhost:3152/FeedData.svc/"));
        }

        #endregion

        #region Properties

        public RSSFeedDatabaseEntities Context { get; set; }

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
            var query = Context.CreateQuery<USER>("USER");

            DataServiceCollection<DataService.USER> users = new DataServiceCollection<USER>();

            users.LoadCompleted += (s, e) =>
                {
                    if (users != null)
                    {
                        var user = users.FirstOrDefault(u => u.user_email == Model.UserEmail && u.user_password == MD5Core.GetHashString(Model.Password));
                        if (user == null)
                            return;
                        var root = App.Current.RootVisual as PhoneApplicationFrame;
                        root.Navigate(new Uri("/Views/FeedListView.xaml", UriKind.Relative));
                    }
                };

            if (!string.IsNullOrEmpty(Model.UserEmail) && !string.IsNullOrEmpty(Model.Password))
                users.LoadAsync(query);
        }
    }
}

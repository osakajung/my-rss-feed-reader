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
using System.Linq.Expressions;

namespace RSSFeedPhone.Tools
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged<T>(Expression<Func<T>> propName)
        {
            if (PropertyChanged != null)
            {
                var body = propName.Body as MemberExpression;
                PropertyChanged(this, new PropertyChangedEventArgs(body.Member.Name));
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            var handlers = PropertyChanged;
            if (handlers != null)
                handlers(this, new PropertyChangedEventArgs(propName));
        }
    }
}

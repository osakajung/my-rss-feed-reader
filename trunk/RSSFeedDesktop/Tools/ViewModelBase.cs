using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;

namespace RSSFeedDesktop.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChanged<T>(Expression<Func<T>> prop)
        {
            if (PropertyChanged != null)
            {
                var body = prop.Body as MemberExpression;
                PropertyChanged(this, new PropertyChangedEventArgs(body.Member.Name));
            }
        }
    }
}

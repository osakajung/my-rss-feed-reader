using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace RSSFeedDesktop.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            var handlers = PropertyChanged;
            if (handlers != null)
                handlers(this, new PropertyChangedEventArgs(propName));
        }
    }
}

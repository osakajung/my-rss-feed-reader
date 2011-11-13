using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace RSSFeedDesktop.ViewModel
{
    class FeedsCommandVM
    {

        private ICommand _removeFeedCommand;
        public ICommand RemoveFeedCommand
        {
            get
            {
                if (_removeFeedCommand == null)
                {
                    _removeFeedCommand = new RelayCommand<object>(RemoveFeedAction, null);
                }

                return _removeFeedCommand;
            }
        }


        private void RemoveFeedAction(object param)
        {
            //remove feed service methode;
            ;
        }
    }
}

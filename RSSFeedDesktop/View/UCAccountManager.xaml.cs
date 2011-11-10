using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RSSFeedDesktop.ViewModel;

namespace RSSFeedDesktop
{
    /// <summary>
    /// Logique d'interaction pour UCAccountManager.xaml
    /// </summary>
    public partial class UCAccountManager : UserControl
    {
        public UCAccountManager()
        {
            this.InitializeComponent();
        }

        private void GoToRssManager()
        {
            UserControl o = Extensions.FindAncestor(this as DependencyObject, "RSSFeedDesktop.MainWindow") as UserControl;
            VisualStateManager.GoToState(o as Control, "loginOk", false);
        }
    }
}
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

namespace RSSFeedDesktop
{
	/// <summary>
	/// Logique d'interaction pour UCRssManager.xaml
	/// </summary>
	public partial class UCRssManager : UserControl
	{
		public UCRssManager()
		{
			this.InitializeComponent();
		}

        public static readonly RoutedEvent GoToAccountManagerEvent = EventManager.RegisterRoutedEvent(
                        "GoToAccountManagerEventHandler", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UCAccountManager));

        public event RoutedEventHandler GoToAccountManagerEventHandler
        {
            add { AddHandler(GoToAccountManagerEvent, value); }
            remove { RemoveHandler(GoToAccountManagerEvent, value); }
        }
		
		public void LogOff()
		{
            RaiseEvent(new RoutedEventArgs(GoToAccountManagerEvent));	
		}
	}
}
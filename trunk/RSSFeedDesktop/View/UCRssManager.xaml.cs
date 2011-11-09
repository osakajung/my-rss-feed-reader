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
		int subscribeState;
		
		public UCRssManager()
		{
			this.InitializeComponent();
			subscribeState = 0;
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			if (subscribeState == 0)
				VisualStateManager.GoToState(this, "AddRss", false);
			else
				VisualStateManager.GoToState(this, "ReturnAddRss", false);
			subscribeState = (subscribeState + 1) % 2;
		}

        private void closeAddRssUC(object sender, System.Windows.RoutedEventArgs e)
        {
            this.UCRssAdd.Visibility = Visibility.Hidden;
        }
	}
}
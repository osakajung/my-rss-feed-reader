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
using System.Windows.Shapes;

namespace RSSFeedDesktop.ViewModel
{
	public static partial class Extensions
	{
		public static DependencyObject FindAncestor(DependencyObject obj, string elem)
		{
            UIElement res = obj as UIElement;
			while (obj != null)
			{
                res = obj as UIElement;
				obj = VisualTreeHelper.GetParent(obj);
                string t = res.ToString();
                if (t == elem)
                    break;

			}
			return res;
		}
	}
}
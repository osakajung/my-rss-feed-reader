using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows;

namespace RSSFeedDesktop.Tools
{
    [ValueConversion(typeof(bool), typeof(String))]
    class IsReadConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isRead = (bool)value;
            if (isRead)
                return "../Images/rss_valid.png";
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strValue = value as string;
            bool isRead;
            if (bool.TryParse(strValue, out isRead))
            {
                return isRead;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}

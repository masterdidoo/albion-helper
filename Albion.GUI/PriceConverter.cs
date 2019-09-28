using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Albion.Db.Items.Requirements;

namespace Albion.GUI
{
    public class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is long)) return null;

            var vr = (long) value;

            return vr / 10000;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return null;

            if (!long.TryParse((string) value, out var vr)) return null;

            return vr * 10000;
        }
    }
}
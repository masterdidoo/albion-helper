using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Albion.GUI
{
    public class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is long)) return null;

            var vr = (long) value / 10000;

            return vr;
//            return vr.ToString("#,##0", CultureInfo.InvariantCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string)) return null;

            if (!long.TryParse((string) value, out var vr)) return null;

            return vr * 10000;
        }
    }
}
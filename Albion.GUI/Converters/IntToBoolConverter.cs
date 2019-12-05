using System;
using System.Globalization;
using System.Windows.Data;

namespace Albion.GUI.Converters
{
    public class IntToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value is string s) && long.TryParse(s, NumberStyles.Any, culture.NumberFormat, out var vr)) return vr >= 0;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
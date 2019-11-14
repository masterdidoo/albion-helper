using System;
using System.Globalization;
using System.Windows.Data;

namespace Albion.GUI.Converters
{
    public class Multiplier : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            long rez = 1;
            foreach (var value in values)
            {
                switch (value)
                {
                    case long l:
                        rez *= l;
                        break;
                    case int i:
                        rez *= i;
                        break;
                    default:
                        return null;
                }
            }

            return rez / 10000;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Albion.GUI.Converters
{
    public class Divisor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var vals = GetLong(values).ToArray();
            if (vals.Length < 2 || vals[0] == 0) return 0;

            return vals[1] / vals [0] / 10000;
        }

        private IEnumerable<long?> GetLong(object[] values)
        {
            foreach (var value in values)
            {
                switch (value)
                {
                    case long l:
                        yield return l;
                        break;
                    case int i:
                        yield return i;
                        break;
                }
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
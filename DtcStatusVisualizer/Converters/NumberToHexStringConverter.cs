using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DtcStatusVisualizer.Converters
{
    class NumberToHexStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return String.Format(CultureInfo.CurrentCulture, "{0:X}", value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hexValue = String.Format(CultureInfo.CurrentCulture, "{0}", value);
            if (string.IsNullOrEmpty(hexValue))
                hexValue = "0";

            if (Int64.TryParse(hexValue, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out long result))
                return result;
            else
                return default(long);
        }
    }
}

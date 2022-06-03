using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
namespace DtcStatusVisualizer.Converters
{
    class NumberToBinaryStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToString((uint)value, 2).PadLeft(8, '0');
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var hexValue = String.Format(CultureInfo.CurrentCulture, "{0}", value);
            if (string.IsNullOrEmpty(hexValue))
                hexValue = "0";
            try
            {
                var result = System.Convert.ToUInt32(hexValue, 2);
                return result;
            }
            catch
            {
                return 0;
            }
        }
    }
}

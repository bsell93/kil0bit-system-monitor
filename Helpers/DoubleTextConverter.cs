using System;
using System.Globalization;
using System.Windows.Data;

namespace Kil0bitSystemMonitor.Helpers
{
    /// <summary>
    /// Converts between <see cref="double"/> and invariant text for editable numeric fields.
    /// </summary>
    public sealed class DoubleTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
                return d.ToString("0.###", CultureInfo.InvariantCulture);
            return "0";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string s)
                return 0d;
            if (double.TryParse(s.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double r))
                return Math.Clamp(r, 0d, 400d);
            return 0d;
        }
    }
}

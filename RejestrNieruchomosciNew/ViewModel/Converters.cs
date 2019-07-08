using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RejestrNieruchomosciNew.ViewModel
{
    class resultCnvr : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"liczba działek:{(string)value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }

    class stringToDecimal : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : string.Format("{0:0.00000}", (decimal)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal result;

            if (decimal.TryParse(value?.ToString(), out result) == true)
                return result;

            return null;
        }
    }
}

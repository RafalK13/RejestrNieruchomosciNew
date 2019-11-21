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

            if (value == null)
                return null;

            string digit = value.ToString().Replace(",", ".");

            decimal result;
            if (decimal.TryParse(digit, out result))
                return string.Format("{0:#,0.00}", result);

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal result;

            if (decimal.TryParse(value?.ToString(), out result) == true)
                return result;

            return null;
        }
    }

    #region Konwertery przeniesione z poprzednich wersji
    public class TekstToVisiblityConverter : IValueConverter
    {
        public object convFun(object value)
        {
            try
            {
                return string.IsNullOrEmpty(value.ToString()) ? false : true;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return convFun(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return convFun(value);
        }
    }

    public class DateConverter : IValueConverter
    {
        public object convFun(object value)
        {
            try
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    return null;
                else
                {
                    DateTime newDate = DateTime.Parse(value.ToString());
                    return newDate.ToString("yyyy/MM/dd");
                }
            }
            catch (Exception ex)
            {
       
                return null;
            }
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return convFun(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return convFun(value);
        }
    }

    public class DoubleConverter : IValueConverter
    {
        double convFun(object value)
        {
            double decResult;
            try
            {
                if (value == null)
                {

                    return 0;
                }
                else
                {
                    if (Double.TryParse(value.ToString(), out decResult) == true)
                        return decResult;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return convFun(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return convFun(value);
        }
    }

    public class IntConverter : IValueConverter
    {
        int? conFun(object value)
        {
            try
            {
                int result;

                if (value == null)
                    return null;

                if (int.TryParse(value.ToString(), out result) == true)
                    return result;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return conFun(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return conFun(value);
        }
    }

    public class VisiblePanels : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int result;

                if (value == null)
                    return false;

                if (int.TryParse(value.ToString(), out result) == true)
                {
                    return result > -1 ? true : false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }

    #region
    //22.02.1976
    #endregion
    #endregion
}

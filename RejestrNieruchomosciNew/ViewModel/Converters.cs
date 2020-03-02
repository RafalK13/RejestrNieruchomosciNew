using RejestrNieruchomosciNew.Model;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace RejestrNieruchomosciNew.ViewModel
{
    class uliceIdToUliceName : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null)
                return 0;

            if (values[1] == null)
                return 0;

            if (int.TryParse(values[0].ToString(), out int id))
            {
                UliceSloList pl = values[1] as UliceSloList;
                if (pl != null)
                {
                    var v = pl.list.FirstOrDefault(row => row.UliceSloId == id);
                    if (v != null)
                        return v.Nazwa;
                }
            }

            return null;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class personIdToPersonName : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null)
                return 0;

            if (values[1] == null)
                return 0;

            int id = int.Parse(values[0].ToString());

            PodmiotList pl = values[1] as PodmiotList;
            if (pl != null)
            {
                var v = pl.list.FirstOrDefault(row => row.PodmiotId == id);
                if (v != null)
                    return v.Name;
            }

            return null;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    
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

    class stringToInt : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            string digit = value.ToString();

            int result;
            if (int.TryParse(digit, out result))
                return string.Format("{0:#,0}", result);
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int result;

            if (int.TryParse(value?.ToString(), out result) == true)
                return result;

            return null;
        }
    }

    class stringToDouble : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            string digit = value.ToString().Replace(",", ".");

            double result;
            if (double.TryParse(digit, out result))
                return string.Format("{0:#,0.00}", result);
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double result;

            if (double.TryParse(value?.ToString(), out result) == true)
                return result;

            return null;
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
                return string.Format("{0:#,0}", result);
                //return string.Format("{0:#,0.00}", result);

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
            catch (Exception)
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
                //if (string.IsNullOrEmpty(value.ToString()))  - bardzo wolne działenie
                if (value == null)
                    return null;
                else
                {
                    DateTime newDate = DateTime.Parse(value.ToString());
                    return newDate.ToString("yyyy/MM/dd");
                }
            }
            catch (Exception)
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
        object convFun(object value)
        {
            double decResult;
            try
            {
                if (value == null)
                {

                    return null;
                }
                else
                {
                    if (Double.TryParse(value.ToString(), out decResult) == true)
                        return decResult;
                    else
                        return null;
                }
            }
            catch (Exception )
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
            catch (Exception)
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
            catch (Exception )
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

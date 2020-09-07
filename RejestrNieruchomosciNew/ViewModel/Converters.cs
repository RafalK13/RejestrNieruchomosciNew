using RejestrNieruchomosciNew.Model;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace RejestrNieruchomosciNew.ViewModel
{
    class oneRoomConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0;

            if (bool.TryParse(value.ToString(), out bool valBool) == false)
                return 0;

            if( valBool == true)
                return new GridLength(0);

            return new GridLength(250);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }

    class oneRoomConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            if (values[0] == null)
                return 0;

            if (values[1] == null)
                return 0;

            if( bool.TryParse( values[0].ToString(), out bool valBool) == false)
                return 0;

            if (int.TryParse(values[1].ToString(), out int valInt) == false)
                return 0;

            if (valBool == false)
                return 0;
           
            
            return 50;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class AdresConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null)
                return 0;

            if (values[1] == null)
                return 0;

            Adres adr = values[0] as Adres;
            AdresSloList adrList = values[1] as AdresSloList;
            string miejsc = "";
            string ulica = "";
            string numer = "";

            if (adr == null || adrList==null || adr.MiejscowoscSloId == 0)
                return null;
            
            miejsc = adrList.miejscList.listAll.FirstOrDefault(r => r.MiejscowoscSloId == adr.MiejscowoscSloId).Nazwa;
            
             if( adr.UlicaSloId != null)
                ulica = ", "+adrList.ulicaList.listAll.FirstOrDefault(r => r.UlicaSloId == adr.UlicaSloId).Nazwa;

             if (string.IsNullOrEmpty(adr.Numer) == false)
                numer = ", " + adr.Numer;

             string s = $"{miejsc}{ulica}{numer}";

            return $"{miejsc}{ulica}{numer}";
            
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class pathTofileName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return  value.ToString().Split('\\', '/').ToList().Last();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }

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
                UlicaSloList pl = values[1] as UlicaSloList;
                if (pl != null)
                {
                    var v = pl.list.FirstOrDefault(row => row.UlicaSloId == id);
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

            if (int.TryParse(values[0].ToString(), out int id) == true)
            {

                PodmiotList pl = values[1] as PodmiotList;
                if (pl != null)
                {
                    var v = pl.list.FirstOrDefault(row => row.PodmiotId == id);
                    if (v != null)
                        return v.Name;
                }
            }

            return null;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class slownikIdToName : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {

            if (values[0] == null)
                return 0;

            if (values[1] == null)
                return 0;

            if (values[2] == null)
                return 0;

            if (values[3] == null)
                return 0;

           IEnumerable e = values[1] as IEnumerable;

            if (e != null)
            {
                var v = e.Cast<object>().FirstOrDefault(row => row.GetType().GetProperty(values[2].ToString()).GetValue(row).ToString() == values[0].ToString());

                if (v != null)
                    return v.GetType().GetProperty(values[3].ToString()).GetValue(v);
                else
                    return null;
            }
            else
                return null;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class NabycieRodzDokIdToName : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null)
                return 0;

            if (values[1] == null)
                return 0;

            if (int.TryParse(values[0].ToString(), out int id) == true)
            {
                RodzajDokumentuList wladList = values[1] as RodzajDokumentuList;

                if (wladList != null)
                {
                    var v = wladList.list.FirstOrDefault(row => row.RodzajDokumentuSloId == id);
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
            {
                if (result == 0)
                    return null;
                else
                    return string.Format("{0:#,0}", result);
            }
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
    class stringToDouble_two : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            string digit = value.ToString().Replace(",", ".");

            double result;
            if (double.TryParse(digit, out result))
                return string.Format("{0:N2}", result);
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


    class stringToDouble : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            string digit = value.ToString().Replace(",", ".");

            double result;
            if (double.TryParse(digit, out result))
                return string.Format("{0:#,0.0000}", result);
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

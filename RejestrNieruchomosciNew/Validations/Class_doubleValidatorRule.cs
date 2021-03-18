using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RejestrNieruchomosciNew.Validations
{
    public class Class_doubleValidatorRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return null;

            if (value.ToString().Length > 15)
                return new ValidationResult(false, $"Zbyt duża liczba");

            string s = value.ToString().Replace(cultureInfo.NumberFormat.NumberGroupSeparator, "");
            //string s = value.ToString().Trim().Replace(" ", "");
            bool v = double.TryParse(s , NumberStyles.AllowDecimalPoint, cultureInfo, out double d);
            if (v == true)
                if (v == true)
                return ValidationResult.ValidResult;

            return new ValidationResult(false, $"Liczba(, zamiast .)");
        }
    }
}

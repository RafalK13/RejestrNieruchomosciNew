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
            int r = 13;
            if (value == null)
                return null;

            bool v = double.TryParse(value.ToString(), out double d);
            if (v == true)
                return ValidationResult.ValidResult;

            return new ValidationResult(false, $"Podana wartość nie jest liczbą");
        }
    }
}

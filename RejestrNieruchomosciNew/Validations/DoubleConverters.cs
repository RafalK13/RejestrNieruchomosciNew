using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Validations
{
    public class DoubleConverters
    {
        public static bool toDouble4(double? arg)
        {
            if (arg == null)
                return true;

     
            if (double.TryParse(arg.ToString(), out double result))
            {
                if (result == 0)
                    return true;

                int poPrzec = 4;
                string r1 = result.ToString();

                int n = r1.IndexOf(",");

                if (n != -1)
                {
                    int l = r1.Length;

                    if (l - n - 1 > poPrzec)
                        return false;
                }
                return true;
            }
            else
                return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    static class ObservableCon<T> where T : ICloneable
    {
        public static List<T> ObservableToList(ObservableCollection<T> observ)
        {
            List<T> list = new List<T>();

            foreach (var r in observ)
            {
                list.Add((T)r.Clone());
            }
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IViewFactory
    {
        T CreateView<T>();
        T CreateView<T>(string s);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IViewFactory
    {
        T CreateView<T>() where T : IView;
        T CreateView<T, G>(G argument) where T : IView;
                                       
    }
}

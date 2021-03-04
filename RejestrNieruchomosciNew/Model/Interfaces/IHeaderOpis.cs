using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IHeaderOpis
    {
        string numer { get; set; }
        string gmina { get; set; }
        string obreb { get; set; }
        string adres { get; set; }

        void changeValues(IDzialka dzialka);
    }
}

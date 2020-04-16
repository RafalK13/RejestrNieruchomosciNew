using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IAdres
    {
        int AdresId { get; set; }

        //int? DzialkaId { get; set; }
        int MiejscowoscSloId { get; set; }
        int UlicaSloId { get; set; }

        string Numer { get; set; }

        Dzialka Dzialka { get; set; }
        MiejscowoscSlo MiejscowoscSlo { get; set; }
        UlicaSlo UlicaSlo { get; set; }

        bool testAdres();

        IMiejscowoscSloList miejscList { get; set; }
        IUlicaSloList ulicaList { get; set; }

        event EventHandler zmiana;
    }
}

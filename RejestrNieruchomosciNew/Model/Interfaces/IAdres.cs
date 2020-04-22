using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IAdres : IEquatable<IAdres>
    {
        int AdresId { get; set; }

        int MiejscowoscSloId { get; set; }
        int UlicaSloId { get; set; }

        string Numer { get; set; }

        Dzialka Dzialka { get; set; }
        MiejscowoscSlo MiejscowoscSlo { get; set; }
        UlicaSlo UlicaSlo { get; set; }

        bool testAdres();
        IAdres copy(IAdres adrSource);

        IMiejscowoscSloList miejscList { get; set; }
        IUlicaSloList ulicaList { get; set; }

        event EventHandler zmiana;
    }
}

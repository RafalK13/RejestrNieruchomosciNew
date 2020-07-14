using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IAdres
    {
        int AdresId { get; set; }

        int MiejscowoscSloId { get; set; }
        int? UlicaSloId { get; set; }

        string Numer { get; set; }

        Dzialka Dzialka { get; set; }
        MiejscowoscSlo MiejscowoscSlo { get; set; }
        UlicaSlo UlicaSlo { get; set; }
        Budynek Budynek { get; set; }


        IAdres testAdres();
        IAdres copy(IAdres adrSource);

        void AdresCls();

        IAdres save(IAdres adr);

        //IMiejscowoscSloList miejscList { get; set; }
        //IUlicaSloList ulicaList { get; set; }

        event EventHandler zmiana;
    }
}

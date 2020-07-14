using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IBudynek : ICloneable
    {
        int BudynekId { get; set; }
        
        string Nazwa { get; set; }

        int? AdresId { get; set; }
        
        double powBezPiwnic { get; set; }
        double powZPiwnic { get; set; }
        double powCalk { get; set; }
        double powZabud { get; set; }
        double kubatura { get; set; }

        int iloscKond { get; set; }
        double numerEwid { get; set; }
        bool wpisRejZab { get; set; }

        bool prad { get; set; }
        bool woda { get; set; }
        bool kanSan { get; set; }
        bool kanLok { get; set; }
        bool kanDeszcz { get; set; }
        bool tel { get; set; }
        bool co { get; set; }
        bool gaz { get; set; }
        bool internet { get; set; }
        bool tv { get; set; }

        string opisKonstr { get; set; }
        string stanTech { get; set; }

        ICollection<Dzialka_Budynek> Dzialka_Budynek { get; set; }
        Adres Adres { get; set; }
    }
}

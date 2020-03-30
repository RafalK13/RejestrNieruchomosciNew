using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IBudynek : IEquatable<IBudynek>, ICloneable
    {
        int BudynekId { get; set; }
        int DzialkaId { get; set; }

        string Nazwa { get; set; }

        double powBezPiwnic { get; set; }
        double powPiwnic { get; set; }
        double powCalk { get; set; }
        double powZabud { get; set; }
        double kubatura { get; set; }

        int iloscKond { get; set; }
        double numerEwid { get; set; }
        bool wpisRejZab { get; set; }

        int MediaId { get; set; }

        string stanTech { get; set; }
    }
}

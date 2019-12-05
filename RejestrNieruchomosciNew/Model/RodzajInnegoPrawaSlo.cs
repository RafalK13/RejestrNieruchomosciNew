using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public class RodzajInnegoPrawaSlo : IRodzajInnegoPrawaSlo
    {
        public int RodzajInnegoPrawaSloId { get; set; }
        public string Nazwa { get; set; }

        public ICollection<InnePrawa> InnePrawa { get; set; }
    }
}

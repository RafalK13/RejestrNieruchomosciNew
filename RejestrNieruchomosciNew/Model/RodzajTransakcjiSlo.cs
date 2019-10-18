using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public class RodzajTransakcjiSlo : IRodzajTransakcjiSlo
    {
        public int RodzajTransakcjiSloId { get; set; }
        public string Nazwa { get; set; }

        public ICollection<TransakcjeSlo> TransakcjeSlo { get; set; }
    }
}

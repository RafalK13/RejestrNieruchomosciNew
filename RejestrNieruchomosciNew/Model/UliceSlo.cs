using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public class UliceSlo
    {
        public int UliceSloId { get; set; }
        public string  Nazwa { get; set; }

        public ICollection<Dzialka> Dzialka { get; set; }
    }
}

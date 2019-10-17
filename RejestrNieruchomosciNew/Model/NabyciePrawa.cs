using System;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    class NabyciePrawa : INabyciePrawa
    {
        public int NabyciePrawaId { get; set; }
        public int WladanieId { get; set; }
        public DateTime ObowiazywanieOd { get; set; }
        public DateTime ObowiazywanieDo { get; set; }
        public string NumerPost { get; set; }
    }
}

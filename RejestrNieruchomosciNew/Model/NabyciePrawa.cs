using System;
using System.Collections.Generic;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class NabyciePrawa : INabyciePrawa
    {
        public int NabyciePrawaId { get; set; }
        public DateTime ObowiazywanieOd { get; set; }
        public DateTime ObowiazywanieDo { get; set; }
        public string ProtokolPrzejecia { get; set; }
        public int Skan { get; set; }

        //public ICollection<Wladanie> Wladanie { get; set; }
    }
}

using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface INabyciePrawa
    {
        int NabyciePrawaId { get; set; }
        DateTime ObowiazywanieOd { get; set; }
        DateTime ObowiazywanieDo { get; set; }
        string ProtokolPrzejecia { get; set; }
        int Skan { get; set; }

        object Clone();
    }
}

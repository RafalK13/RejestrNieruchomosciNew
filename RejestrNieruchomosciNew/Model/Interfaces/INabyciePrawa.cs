using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface INabyciePrawa
    {
        int NabyciePrawaId { get; set; }
        int WladanieId { get; set; }
        DateTime ObowiazywanieOd { get; set; }
        DateTime ObowiazywanieDo { get; set; }
        string NumerPost { get; set; }
    }
}

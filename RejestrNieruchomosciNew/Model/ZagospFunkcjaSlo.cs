using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospFunkcjaSlo : IZagospFunkcjaSlo
    {
        public int ZagospFunkcjaSloId { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Zagosp> Zagosp { get; set; }
    }
}

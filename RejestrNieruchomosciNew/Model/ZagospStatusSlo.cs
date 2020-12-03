using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospStatusSlo : IZagospStatusSlo
    {
        public int ZagospStatusSloId { get; set; }
        public string Nazwa { get; set; }
        
    }
}

using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public class UzytkiSlo : IUzytkiSlo
    {
        public int UzytkiSloId { get; set; }
        public string Nazwa { get; set; }

        
    }
}

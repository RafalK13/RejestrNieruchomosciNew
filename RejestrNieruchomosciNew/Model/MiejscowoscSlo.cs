using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public class MiejscowoscSlo : IMiejscowoscSlo
    {
        public int MiejscowoscSloId { get; set; }

        public int GminaSloId { get; set; }
        public int MiejscowoscUlice { get; set; }

        public  string Nazwa { get; set; }

        public ICollection<Adres> Adres { get; set; }
     }
}

// OPIS SIMC 
// MiejscowoscSloId == SYM
// MiejscowoscUlice == SYMPOD


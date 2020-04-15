using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.Generic;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class UlicaSlo : ViewModelBase, IUlicaSlo
    {
        public int UlicaSloId { get; set; }

        public int MiejscowoscUlice { get; set; }

        public string Nazwa { get; set; }
        
        public ICollection<Adres> Adres { get; set; }
        //public ICollection<Dzialka> Dzialka { get; set; }
        //public GminaSlo GminaSlo { get; set; }
    }
}

// OPIS ULIC 
// MiejscowoscUlice == SYM

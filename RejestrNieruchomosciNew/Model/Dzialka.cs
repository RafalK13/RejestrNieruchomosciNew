using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace RejestrNieruchomosciNew
{
    public partial class Dzialka : ChangeClass
    {
        private string _numer;
        private int _obrebId;

        public int DzialkaId { get; set; }
        public string Numer
        {
            get => _numer;
            set
            {
                _numer = value;
                OnPropertyChanged("Numer");
            }
        }
        public string Kwakt { get; set; }
        public string Kwzrob { get; set; }
        public decimal? Pow { get; set; }
        public int ObrebId
        {
            get => _obrebId;
            set
            {
                _obrebId = value;
                OnPropertyChanged("ObrebId");
            }
        }
        public Obreb Obreb { get; set; }

        //public int? InnePrawa { get; set; }
        //public virtual ICollection<InnePrawa> InnePrawaNavigation { get; set; }
        //public virtual ICollection<Wladanie> Wladanie { get; set; }
    }
}

using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace RejestrNieruchomosciNew
{
    public partial class Dzialka : ViewModelBase
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
                RaisePropertyChanged("Numer");
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
                RaisePropertyChanged("ObrebId");
            }
        }
        public Obreb Obreb { get; set; }

        public Dzialka() { }

        public Dzialka( string _numer, int _ObrebId, string _kwA=null, string _kwZ=null, decimal? _Pow=null  )
        {
            Numer = _numer;
            ObrebId = _ObrebId;
            Kwakt = _kwA;
            Kwzrob = _kwZ;
            Pow = _Pow;


        }

        //public int? InnePrawa { get; set; }
        //public virtual ICollection<InnePrawa> InnePrawaNavigation { get; set; }
        //public virtual ICollection<Wladanie> Wladanie { get; set; }
    }
}

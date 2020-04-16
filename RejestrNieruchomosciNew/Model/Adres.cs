using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RejestrNieruchomosciNew.Model
{
    public class Adres : ViewModelBase, IAdres
    {
        private string _numer;
        private int _miejscowoscSloId;
        private int _ulicaSloId;

        public int AdresId { get; set; }

        public string Numer
        {
            get => _numer;
            set
            {
                _numer = value;
                RaisePropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);

            }
        }

        public int MiejscowoscSloId
        {
            get => _miejscowoscSloId; set
            {
                _miejscowoscSloId = value;
                RaisePropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);

            }
        }
        public int UlicaSloId
        {
            get => _ulicaSloId; set
            {
                _ulicaSloId = value;
                RaisePropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }

        public Dzialka Dzialka { get; set; }
        public MiejscowoscSlo MiejscowoscSlo { get; set; }
        public UlicaSlo UlicaSlo { get; set; }

        [NotMapped]
        public IMiejscowoscSloList miejscList { get; set; }
        [NotMapped]
        public IUlicaSloList ulicaList { get; set; }

        public bool testAdres()
        {
            return MiejscowoscSloId != 0 &&
                   UlicaSloId != 0;
        }

        public event EventHandler zmiana;
    }
}

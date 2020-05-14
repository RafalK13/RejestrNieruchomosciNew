using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace RejestrNieruchomosciNew.Model
{
    [Serializable]
    public class Adres : INotifyPropertyChanged, IAdres
    {
        private string _numer;
        private int _miejscowoscSloId;
        private int _ulicaSloId;
        private IMiejscowoscSloList _miejscList;
        private IUlicaSloList _ulicaList;

        public int AdresId { get; set; }

        public string Numer
        {
            get => _numer;
            set
            {
                _numer = value;
                NotifyPropertyChanged(); 
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);

            }
        }

        public int MiejscowoscSloId
        {
            get => _miejscowoscSloId;
            set
            {
                _miejscowoscSloId = value;
                NotifyPropertyChanged(); 
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);

            }
        }
        public int UlicaSloId
        {
            get => _ulicaSloId;
            set
            {
                //Set(ref _ulicaSloId, value);
                _ulicaSloId = value;
                NotifyPropertyChanged();

                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }

        public Dzialka Dzialka { get; set; }
        public MiejscowoscSlo MiejscowoscSlo { get; set; }
        public UlicaSlo UlicaSlo { get; set; }

        [NotMapped]
        public IMiejscowoscSloList miejscList
        {
            get => _miejscList;
            set
            {
                //Set(ref _miejscList, value);
                _miejscList = value;
                NotifyPropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }
        [NotMapped]
        public IUlicaSloList ulicaList
        {
            get => _ulicaList;

            set {
                _ulicaList = value;
                NotifyPropertyChanged();
            }
            //set => Set(ref _ulicaList, value);
        }

        public bool testAdres()
        {
            return MiejscowoscSloId != 0 &&
                   UlicaSloId != 0;
        }

        bool IEquatable<IAdres>.Equals(IAdres other)
        {
            return Numer == other.Numer &&
                   MiejscowoscSloId == other.MiejscowoscSloId &&
                   UlicaSloId == other.UlicaSloId;
        }

        public IAdres copy(IAdres adrSource)
        {
            Numer = adrSource.Numer;
            MiejscowoscSloId = adrSource.MiejscowoscSloId;
            UlicaSloId = adrSource.UlicaSloId;

            return this;
        }

        public void AdresCls()
        {
            MiejscowoscSloId = 0;
            UlicaSloId = 0;
            Numer = string.Empty;
        }

        public event EventHandler zmiana;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
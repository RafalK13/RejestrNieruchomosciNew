using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.Generic;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class UliceSlo : ViewModelBase, IUliceSlo
    {
        private int _UliceSloId;
        public int UliceSloId
        {
            get => _UliceSloId;

            set
            {
                _UliceSloId = value;
                RaisePropertyChanged();
            }
        }
        public string  Nazwa { get; set; }

        public int GminaSloId { get; set; }

        public ICollection<Dzialka> Dzialka { get; set; }
        public GminaSlo GminaSlo { get; set; }
    }
}

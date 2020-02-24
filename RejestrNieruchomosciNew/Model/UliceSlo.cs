using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class UliceSlo : ViewModelBase
    {
        private int _UliceSloId;
        public int UliceSloId
        {
            get
            {
               
                if (_UliceSloId <= 0)
                    return 1;
                else
                    return _UliceSloId;
            }

            set
            {
               
                _UliceSloId = value;
                RaisePropertyChanged();
            }
        }
        public string  Nazwa { get; set; }

        public ICollection<Dzialka> Dzialka { get; set; }
    }
}

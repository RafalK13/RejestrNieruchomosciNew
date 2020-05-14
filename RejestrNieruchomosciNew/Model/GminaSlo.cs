using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace RejestrNieruchomosciNew
{
    [Serializable]
    public partial class GminaSlo : INotifyPropertyChanged //ViewModelBase
    {
        private int _gminaSloId;

        public int GminaSloId
        {
            get => _gminaSloId;
            set
            {
                //Set(ref _gminaSloId, value);
                _gminaSloId = value;
                NotifyPropertyChanged();
            }
        }

        public string Nazwa { get; set; }

        //public ICollection<UlicaSlo> UliceSlo { get; set; }
        //public virtual List<Obreb> Obreb { get; set; }

        public GminaSlo copy(GminaSlo gm)
        {
            GminaSloId = gm.GminaSloId;
            Nazwa = gm.Nazwa;
            return this;
        }
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

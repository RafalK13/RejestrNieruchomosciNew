using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class GminaSlo : ViewModelBase
    {
        private int _gminaSloId;

        public int GminaSloId
        {
            get => _gminaSloId;
            set => Set(ref _gminaSloId, value);
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
    }
}

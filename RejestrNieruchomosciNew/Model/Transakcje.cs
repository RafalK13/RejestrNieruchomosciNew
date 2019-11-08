using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class Transakcje : ViewModelBase, ITransakcje
    {
        private int _TransakcjeId;
        public int TransakcjeId
        {
            get => _TransakcjeId;
            set
            {
                _TransakcjeId = value;
                RaisePropertyChanged("TransakcjeId");
            }
        }
        private int? _RodzajTransakcjiSloId;
        public int? RodzajTransakcjiSloId
        {
            get => _RodzajTransakcjiSloId;
            set
            {
                _RodzajTransakcjiSloId = value;
                RaisePropertyChanged("RodzajTransakcjiSloId");
            }
        }
        private int? _NazwaCzynnosciSloId;
        public int? NazwaCzynnosciSloId
        {
            get => _NazwaCzynnosciSloId;
            set
            {
                _NazwaCzynnosciSloId = value;
                RaisePropertyChanged("NazwaCzynnosciSloId");
            }
        }

        private int? _RodzajDokumentuSloId;
        public int? RodzajDokumentuSloId
        {
            get => _RodzajDokumentuSloId;
            set
            {
                _RodzajDokumentuSloId = value;
                RaisePropertyChanged("RodzajDokumentuSloId");
            }
        }

        private string _Numer;
        public string Numer
        {
            get => _Numer;
            set
            {
                _Numer = value;
                RaisePropertyChanged("Numer");
            }
        }

        public DateTime? _Data;
        public DateTime? Data
        {
            get => _Data;
            set
            {
                _Data = value;
                RaisePropertyChanged("Data");
            }
        }

        private string _Tytul;
        public string Tytul
        {
            get => _Tytul;
            set
            {
                _Tytul = value;
                RaisePropertyChanged("Tytul");
            }
        }
        public string Skan { get; set; }

        [InverseProperty("TransakcjeK")]
        public ICollection<Wladanie> WladanieK { get; set; }
        [InverseProperty("TransakcjeS")]
        public ICollection<Wladanie> WladanieS { get; set; }
    }
}

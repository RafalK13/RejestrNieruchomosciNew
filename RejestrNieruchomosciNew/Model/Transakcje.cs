using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows;
using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class Transakcje : ViewModelBase, ITransakcje
    {
        private int? _TransakcjeId;
        public int? TransakcjeId
        {
            get => _TransakcjeId;
            set
            {
                _TransakcjeId = value;
                RaisePropertyChanged("TransakcjeId");
                onChange(this, EventArgs.Empty);
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
                onChange(this, EventArgs.Empty);
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
                onChange(this, EventArgs.Empty);
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
                onChange(this, EventArgs.Empty);
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
                onChange(this, EventArgs.Empty);
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
                onChange(this, EventArgs.Empty);
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
                onChange(this, EventArgs.Empty);
            }
        }
        private string _Skan;
        public string Skan
        {
            get => _Skan;
            set
            {
                _Skan = value;
                RaisePropertyChanged("Skan");
                onChange(this, EventArgs.Empty);
            }
        }

        private DateTime? _WpisDoKW;
        public DateTime? WpisDoKW
        {
            get => _WpisDoKW;
            set
            {
                _WpisDoKW = value;
                RaisePropertyChanged("WpisDoKW");
                onChange(this, EventArgs.Empty);
            }
        }

        [InverseProperty("TransakcjeK_Wlad")]
        public ICollection<Wladanie> TransakcjeK_Wlad { get; set; }
        [InverseProperty("TransakcjeS_Wlad")]
        public ICollection<Wladanie> TransakcjeS_Wlad { get; set; }

        public event EventHandler onChange;

        public virtual void Transakcje_onChange(object sender, EventArgs e)
        {

        }

        public Transakcje()
        {
            onChange += Transakcje_onChange;
        }

    }
}

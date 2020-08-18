using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
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
                
                if( onChange != null)
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

                if (onChange != null)
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

                if (onChange != null)
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

                if (onChange != null)
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

                if (onChange != null)
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
                RaisePropertyChanged();

                if (onChange != null)
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

                if (onChange != null)
                    onChange(this, EventArgs.Empty);
            }
        }
       
        public string Skan
        {
            get
            {
                return ConfigurationManager.AppSettings["zalacznikPath"] + "\\Transakcje\\" + TransakcjeId;
            }
            //set
            //{

            //    u.zalPath = ConfigurationManager.AppSettings["zalacznikPath"] + "\\Transakcje\\" + u.selectedIdTrans;
            //    _Skan = value;
            //    RaisePropertyChanged("Skan");

            //    if (onChange != null)
            //        onChange(this, EventArgs.Empty);
            //}
        }

        private DateTime? _WpisDoKW;
        public DateTime? WpisDoKW
        {
            get => _WpisDoKW;
            set
            {
                _WpisDoKW = value;
                RaisePropertyChanged("WpisDoKW");

                if( onChange != null)
                    onChange(this, EventArgs.Empty);
            }
        }

        [InverseProperty("TransakcjeK_Wlad")]
        public ICollection<Wladanie> TransakcjeK_Wlad { get; set; }
        [InverseProperty("TransakcjeS_Wlad")]
        public ICollection<Wladanie> TransakcjeS_Wlad { get; set; }

        public object clone() {
            return this.MemberwiseClone();
        }

        public bool Equals(ITransakcje other)
        {
            ITransakcje t = other as ITransakcje;

            if(other == null)
                return false;

            if (t == null)
                return false;

            return TransakcjeId == t.TransakcjeId;
        }

        public event EventHandler onChange;
    }
}

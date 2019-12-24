using System;
using System.Collections;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class DecyzjeAdministracyjne : ViewModelBase, IDecyzjeAdministracyjne
    {
        public int DecyzjeAdministracyjneId { get; set; }

        private string _Numer;
        public string Numer
        {
            get => _Numer;
            set
            {
                _Numer = value;
                RaisePropertyChanged();
                onChange(this, EventArgs.Empty);
            }
        }

        private DateTime? _DataDecyzji;
        public DateTime? DataDecyzji
        {
            get => _DataDecyzji;
            set
            {
                _DataDecyzji = value;
                RaisePropertyChanged();
                onChange(this, EventArgs.Empty);
            }
        }

        private int? _PodmiotId;
        public int? PodmiotId
        {
            get => _PodmiotId;
            set
            {
                _PodmiotId = value;
                RaisePropertyChanged();
                onChange(this, EventArgs.Empty);
            }
        }

        private string _Przedmiot;
        public string Przedmiot
        {
            get => _Przedmiot;
            set
            {
                _Przedmiot = value;
                RaisePropertyChanged();
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
                RaisePropertyChanged();
                onChange(this, EventArgs.Empty);
            }
        }

        //onChange(this, EventArgs.Empty);

        public ICollection<InnePrawa> InnePrawa { get; set; }

        public DecyzjeAdministracyjne()
        {
            onChange += Transakcje_onChange;
        }

        public event EventHandler onChange;

        public virtual void Transakcje_onChange(object sender, EventArgs e)
        {

        }
    }
}

using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew
{
    public partial class Dzialka : ViewModelBase, IDzialka
    {
        public int DzialkaId { get; set; }

        private string _Numer;
        public string Numer
        {
            get => _Numer; set
            {
                _Numer = value;
                RaisePropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }

        private string _Kwakt;
        public string Kwakt
        {
            get => _Kwakt;
            set
            {
                _Kwakt = value;
                RaisePropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }
        private string _Kwzrob;
        public string Kwzrob
        {
            get => _Kwzrob;
            set
            {
                _Kwzrob = value;
                RaisePropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }

        private double? _Pow;
        public double? Pow
        {
            get => _Pow; set
            {
                _Pow = value;
                RaisePropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);

            }
        }

        public string lokalizacja { get; set; }
        public string uzbrojenie { get; set; }
        public string ksztalt { get; set; }
        public string sasiedztwo { get; set; }
        public string dostDoDrogi { get; set; }
        public string rodzNaw { get; set; }

        private int? _UliceSloId;
        public int? UliceSloId
        {
            get => _UliceSloId;

            set
            {
                _UliceSloId = value;

                if (_UliceSloId <= 0)
                    _UliceSloId = 1;
                RaisePropertyChanged("UliceSloId");
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }
        //public UliceSlo UlicaSlo { get; set; }

        public int? NadzorKonserwSloId { get; set; }
        public NadzorKonserwSlo NadzorKonserwSlo { get; set; }

        public ICollection<Uzytki> Uzytki { get; set; }

        private int _ObrebId;
        public int ObrebId
        {
            get => _ObrebId;
            set
            {
                _ObrebId = value;
                RaisePropertyChanged();
            }
        }
        public Obreb Obreb { get; set; }

        public ICollection<Wladanie> Wladanie { get; set; }
        public ICollection<InnePrawa> InnePrawa { get; set; }
        public PlatnoscUW PlatnoscUW { get; set; }
        public ICollection<Zagosp> Zagosp { get; set; }

        [NotMapped]
        public ProcessDzialka procDz { get; set; }

        public Dzialka()
        {

        }

        public Dzialka(string _numer, int _ObrebId, string _kwA = null, string _kwZ = null, double? _Pow = null, int? _NadzorKonserwSloId = null, int? _UliceSloId = null)
        {
            Numer = _numer;
            ObrebId = _ObrebId;
            Kwakt = _kwA;
            Kwzrob = _kwZ;
            Pow = _Pow;
            NadzorKonserwSloId = _NadzorKonserwSloId;
            UliceSloId = _UliceSloId;
        }

        public void clone(IDzialka d)
        {
            var t = d.GetType();

            foreach (var v in t.GetProperties())
            {
                if (v.CanWrite)
                {
                    v.SetValue(this, v.GetValue(d));
                }
            }
        }

        public void copy(IDzialka dzDest, IDzialka dzSource)
        {
            dzDest.Numer = dzSource.Numer;
            dzDest.ObrebId = dzSource.ObrebId;
            dzDest.DzialkaId = dzSource.DzialkaId;
            dzDest.Kwakt = dzSource.Kwakt;
            dzDest.Kwzrob = dzSource.Kwzrob;
            dzDest.Pow = dzSource.Pow;
            dzDest.NadzorKonserwSloId = dzSource.NadzorKonserwSloId;
            dzDest.UliceSloId = dzSource.UliceSloId;
        }

        public IDzialka copy(IDzialka dzSource)
        {
            Numer = dzSource.Numer;
            ObrebId = dzSource.ObrebId;
            DzialkaId = dzSource.DzialkaId;
            Kwakt = dzSource.Kwakt;
            Kwzrob = dzSource.Kwzrob;
            Pow = dzSource.Pow;
            NadzorKonserwSloId = dzSource.NadzorKonserwSloId;
            UliceSloId = dzSource.UliceSloId;

            return this;
        }

        public event EventHandler zmiana;
    }
}

﻿using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace RejestrNieruchomosciNew
{
    //[Serializable]
    [DataContract]
    public partial class Dzialka : INotifyPropertyChanged, IDzialka
    {
        [DataMember]
        public int DzialkaId { get; set; }

        private string _Numer;
        [DataMember]
        public string Numer
        {
            get => _Numer; set
            {
                _Numer = value;
                //RaisePropertyChanged();
                NotifyPropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }

        private string _Kwakt;
        [DataMember]
        public string Kwakt
        {
            get => _Kwakt;
            set
            {
                _Kwakt = value;
                //RaisePropertyChanged();
                NotifyPropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }
        private string _Kwzrob;
        [DataMember]
        public string Kwzrob
        {
            get => _Kwzrob;
            set
            {
                _Kwzrob = value;
                //RaisePropertyChanged();
                NotifyPropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }

        private double? _Pow;
        [DataMember]
        public double? Pow
        {
            get => _Pow; set
            {
                _Pow = value;
                //RaisePropertyChanged();
                NotifyPropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);

            }
        }
        [DataMember]
        public string lokalizacja { get; set; }
        [DataMember]
        public string uzbrojenie { get; set; }
        [DataMember]
        public string ksztalt { get; set; }
        [DataMember]
        public string sasiedztwo { get; set; }
        [DataMember]
        public string dostDoDrogi { get; set; }
        [DataMember]
        public string rodzNaw { get; set; }
        //[DataMember]
        //public int? AdresId { get; set; }
        //[field: NonSerialized]
        [DataMember]
        public Adres Adres { get; set; }
        [DataMember]
        public int? NadzorKonserwSloId { get; set; }
        //[field: NonSerialized]

        public NadzorKonserwSlo NadzorKonserwSlo { get; set; }

        //[field: NonSerialized]
        public ICollection<Uzytki> Uzytki { get; set; }

        private int _ObrebId;
        [DataMember]
        public int ObrebId
        {
            get => _ObrebId;
            set 
            {
                _ObrebId = value;
                //Set( ref _ObrebId, value);

                //RaisePropertyChanged();
                NotifyPropertyChanged();
                if (zmianaObreb != null)
                    zmianaObreb(null, EventArgs.Empty);
            }
        }
        [DataMember]
        public Obreb Obreb { get; set; }


        public ICollection<Wladanie> Wladanie { get; set; }
        public ICollection<InnePrawa> InnePrawa { get; set; }
        public PlatnoscUW PlatnoscUW { get; set; }
        public ICollection<Zagosp> Zagosp { get; set; }
       
        public ICollection<Dzialka_Budynek> Dzialka_Budynek { get; set; }

        //public override bool Equals(object _other)
        //{
        //    if ( _other == null)
        //        return false;

        //    IDzialka other = _other as IDzialka;

        //    if (other == null)
        //        return false;

        //    return DzialkaId.Equals(other.DzialkaId) &&
        //           string.Equals(Numer, other.Numer) &&
        //           string.Equals(Kwakt, other.Kwakt) &&
        //           string.Equals(Kwzrob, other.Kwzrob) &&
        //           Pow.Equals(other.Pow) &&
        //           string.Equals(lokalizacja, other.lokalizacja) &&
        //           string.Equals(uzbrojenie, other.uzbrojenie) &&
        //           string.Equals(ksztalt, other.ksztalt) &&
        //           string.Equals(sasiedztwo, other.sasiedztwo) &&
        //           string.Equals(dostDoDrogi, other.dostDoDrogi) &&
        //           string.Equals(rodzNaw, other.rodzNaw) &&
        //           //AdresId == other.AdresId &&                    
        //           ObrebId.Equals(other.ObrebId) &&
        //           NadzorKonserwSloId.Equals(other.NadzorKonserwSloId);
        //}

        bool IEquatable<IDzialka>.Equals(IDzialka other)
        {
            return DzialkaId.Equals(other.DzialkaId) &&
                   string.Equals(Numer, other.Numer) &&
                   string.Equals(Kwakt, other.Kwakt) &&
                   string.Equals(Kwzrob, other.Kwzrob) &&
                   Pow.Equals(other.Pow) &&
                   string.Equals(lokalizacja, other.lokalizacja) &&
                   string.Equals(uzbrojenie, other.uzbrojenie) &&
                   string.Equals(ksztalt, other.ksztalt) &&
                   string.Equals(sasiedztwo, other.sasiedztwo) &&
                   string.Equals(dostDoDrogi, other.dostDoDrogi) &&
                   string.Equals(rodzNaw, other.rodzNaw) &&
                   //AdresId == other.AdresId &&                    
                   ObrebId.Equals(other.ObrebId) &&
                   NadzorKonserwSloId.Equals(other.NadzorKonserwSloId);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (DzialkaId.GetHashCode());
                hash = (hash * HashingMultiplier) ^ (ObrebId.GetHashCode());
                return hash;
            }
        }

        public Dzialka()
        {
        }

        public Dzialka(string _numer, int _ObrebId, string _kwA = null, string _kwZ = null, double? _Pow = null, int? _NadzorKonserwSloId = null)//, int? _AdresId=null )
        {
            Numer = _numer;
            ObrebId = _ObrebId;
            Kwakt = _kwA;
            Kwzrob = _kwZ;
            Pow = _Pow;
            NadzorKonserwSloId = _NadzorKonserwSloId;
            //AdresId = _AdresId;
        }
       
        public object clone()
        {
            Dzialka d = (Dzialka)this.MemberwiseClone();
            d.PlatnoscUW = PlatnoscUW.clone();

            return d;
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
            //dzDest.AdresId = dzSource.AdresId;
            dzDest.lokalizacja = dzSource.lokalizacja;
            dzDest.uzbrojenie = dzSource.uzbrojenie;
            dzDest.ksztalt = dzSource.ksztalt;
            dzDest.sasiedztwo = dzSource.sasiedztwo;
            dzDest.dostDoDrogi = dzSource.dostDoDrogi;
            dzDest.rodzNaw = dzSource.rodzNaw;
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
            //AdresId = dzSource.AdresId;
            lokalizacja = dzSource.lokalizacja;
            uzbrojenie = dzSource.uzbrojenie;
            ksztalt = dzSource.ksztalt;
            sasiedztwo = dzSource.sasiedztwo;
            dostDoDrogi = dzSource.dostDoDrogi;
            rodzNaw = dzSource.rodzNaw;
          
            if (dzSource.Adres != null)
            {
                if (Adres == null)
                    Adres = new Adres();
                
                Adres.copy(dzSource.Adres);
            }
            else
                Adres = null;

            return this;
        }

        [field: NonSerialized]
        public event EventHandler zmiana;
        [field: NonSerialized]
        public event EventHandler zmianaObreb;

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

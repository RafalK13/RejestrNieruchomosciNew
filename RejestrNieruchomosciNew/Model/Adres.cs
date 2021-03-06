﻿using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RejestrNieruchomosciNew.Model
{
    [Serializable]
    public class Adres : INotifyPropertyChanged, IAdres
    {
        private string _numer;
        private int _miejscowoscSloId;
        private int? _ulicaSloId;

        public int AdresId { get; set; }

        public string Numer
        {
            get => _numer;
            set
            {
                _numer = value;
                NotifyPropertyChanged(); 
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);

            }
        }

        public int MiejscowoscSloId
        {
            get => _miejscowoscSloId;
            set
            {
                _miejscowoscSloId = value;
                NotifyPropertyChanged(); 
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);

            }
        }
        public int? UlicaSloId
        {
            get => _ulicaSloId;
            set
            {
                //Set(ref _ulicaSloId, value);
                _ulicaSloId = value;
                NotifyPropertyChanged();

                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }

        public int? DzialkaId { get; set; }
        [field: NonSerialized]
        public Dzialka Dzialka { get; set; }
        
        public int? BudynekId { get; set; }
        [field: NonSerialized]
        public Budynek Budynek { get; set; }

        public MiejscowoscSlo MiejscowoscSlo { get; set; }
        public UlicaSlo UlicaSlo { get; set; }

        public IAdres testAdres()
        {
            if (MiejscowoscSloId == 0)
                return null;

            return this;
        }

        public override bool Equals(Object other)
        {
            if (other == null)
                return false;

            IAdres obj = other as IAdres;

            if(obj == null)
                return false;

            return string.Equals(Numer, obj.Numer) &&
                          (MiejscowoscSloId == obj.MiejscowoscSloId) && 
                          ( obj != null && UlicaSloId == obj.UlicaSloId);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ MiejscowoscSloId.GetHashCode();
                hash = (hash * HashingMultiplier) ^ UlicaSloId.GetHashCode();

                return hash;
            }
        }

        public object Clone( IAdres obj)
        {
            return (Adres)this.MemberwiseClone(); 
        }

        public IAdres copy(IAdres adrSource)
        {
            if (adrSource == null)
                return null;

            AdresId = adrSource.AdresId;
            Numer =  adrSource.Numer;
            MiejscowoscSloId = adrSource.MiejscowoscSloId;
            UlicaSloId = adrSource.UlicaSloId;

            return this;
        }

        public void AdresCls()
        {
            MiejscowoscSloId = 0;
            UlicaSloId = 0;
            Numer = string.Empty;
        }

        public IAdres save( IAdres adr)
        {
            int a = 13;
            if (adr.AdresId >= 0 && adr.MiejscowoscSloId > 0)
            {
                using (var c = new Context())
                {
                    var v1 = c.Adres.FirstOrDefault(r => r.AdresId == adr.AdresId);
                    if (v1 == null)
                    {
                        adr.AdresId = 0;
                        c.Adres.Add((Adres)adr);
                    }
                    else
                    c.Entry(v1).CurrentValues.SetValues(adr);
                    
                    c.SaveChanges();
                }
            }
            else
            {
                if (adr.AdresId > 0 && adr.MiejscowoscSloId == 0)
                {
                    using (var c = new Context())
                    {
                        c.Remove(adr);
                        c.SaveChanges();
                    }
                    return null;
                }
            }
            return adr;
        }

        [field: NonSerialized]
        public event EventHandler zmiana;
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
 
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
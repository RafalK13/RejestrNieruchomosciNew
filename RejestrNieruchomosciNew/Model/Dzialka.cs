using Castle.Core;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace RejestrNieruchomosciNew
{
    //[Serializable]
    [DataContract]
    public partial class Dzialka : INotifyPropertyChanged, IDzialka, IDataErrorInfo
    {
        [NotMapped]
        public  DzialkaValidator _validatorDzialka { get; set; }

        [DataMember]
        public int DzialkaId { get; set; }

        private string _Numer;
        [DataMember]
        public string Numer
        {
            get => _Numer; set
            {
                _Numer = value;
                ValidateProperty(value, "Numer");
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
                NotifyPropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);
            }
        }

        private double? _Pow;
        [DataMember]
        //[DataType("doub1le", ErrorMessage = "")]
        public double? Pow
        {
            get => _Pow;
            set
            {
                _Pow = value;
                ValidateProperty(value, "Pow");
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

        [DataMember]
        public Adres Adres { get; set; }

        public KonserwZabytkowSlo KonserwZabytkowSlo { get; set; }
        public KonserwPrzyrodySlo KonserwPrzyrodySlo { get; set; }

        public ICollection<Uzytki> Uzytki { get; set; }

        private int _ObrebId;
        [DataMember]
        public int ObrebId
        {
            get => _ObrebId;
            set
            {
                _ObrebId = value;

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
        public Zagosp Zagosp { get; set; }

        public ICollection<Dzialka_Budynek> Dzialka_Budynek { get; set; }

        public DzialkaOchrona DzialkaOchrona { get; set; }

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
                   ObrebId.Equals(other.ObrebId);
            //KonserwPrzyrodySloId.Equals(other.KonserwPrzyrodySloId) &&
            //KonserwZabytkowSloId.Equals(other.KonserwZabytkowSloId);
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

        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = _validatorDzialka?.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                if (firstOrDefault != null)
                    return _validatorDzialka != null ? firstOrDefault.ErrorMessage : "";
                return "";
            }
        }
        public string Error
        {
            get => null;
        }


        public Dzialka()
        {
           
           // _validatorDzialka = new DzialkaValidator();
            int r1 = 1;
        }

        public Dzialka(string _numer, int _ObrebId, string _kwA = null, string _kwZ = null, double? _Pow = null, int? _NadzorKonserwSloId = null, int? _KonserwZabytkowSloId = null, int? _KonserwPrzyrodySloId = null)//, int? _AdresId=null )
        {
           
            Numer = _numer;
            ObrebId = _ObrebId;
            Kwakt = _kwA;
            Kwzrob = _kwZ;
            Pow = _Pow;
            //_validatorDzialka = new DzialkaValidator();
            int r2 = 2;

            //KonserwPrzyrodySloId = _KonserwPrzyrodySloId;
            //KonserwZabytkowSloId = _KonserwZabytkowSloId;
            //AdresId = _AdresId;
        }

        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
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
            //dzDest.KonserwPrzyrodySloId = dzSource.KonserwPrzyrodySloId;
            //dzDest.KonserwZabytkowSloId = dzSource.KonserwZabytkowSloId;
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
            //KonserwPrzyrodySloId = dzSource.KonserwPrzyrodySloId;
            //KonserwZabytkowSloId = dzSource.KonserwZabytkowSloId;
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

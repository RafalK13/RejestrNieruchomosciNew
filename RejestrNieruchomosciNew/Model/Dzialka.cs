using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RejestrNieruchomosciNew
{
    public partial class Dzialka : ViewModelBase, IDzialka
    {
        public int DzialkaId { get; set; }
        public string Numer { get; set; }

        public string Kwakt { get; set; }
        public string Kwzrob { get; set; }
        public double? Pow { get; set; }

        public string lokalizacja { get; set; }
        public string uzbrojenie { get; set; }
        public string ksztalt { get; set; }
        public string sasiedztwo { get; set; }
        public string dostDoDrogi { get; set; }
        public string rodzNaw { get; set; }

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
                RaisePropertyChanged("ObrebId");
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

        public Dzialka( string _numer, int _ObrebId, string _kwA=null, string _kwZ=null, double? _Pow=null  )
        {
            Numer = _numer;
            ObrebId = _ObrebId;
            Kwakt = _kwA;
            Kwzrob = _kwZ;
            Pow = _Pow;
        }

        public void clone( IDzialka d)
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
        }

        public IDzialka copy(IDzialka dzSource)
        {
            Numer = dzSource.Numer;
            ObrebId = dzSource.ObrebId;
            DzialkaId = dzSource.DzialkaId;
            Kwakt = dzSource.Kwakt;
            Kwzrob = dzSource.Kwzrob;
            Pow = dzSource.Pow;

            return this;
        }
    }
}

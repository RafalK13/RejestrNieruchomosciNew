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
        public decimal? Pow { get; set; }

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
        public PlatnoscUW PlatnoscUW { get; set; }

        [NotMapped]
        public ProcessDzialka procDz { get; set; }
        
        public Dzialka()
        {
        }

        public Dzialka( string _numer, int _ObrebId, string _kwA=null, string _kwZ=null, decimal? _Pow=null  )
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

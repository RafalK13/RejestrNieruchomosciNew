using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using System.Linq;

namespace RejestrNieruchomosciNew
{
    public partial class PlatnoscUW : ViewModelBase, IPlatnosc
    {
        public int PlatnoscUWId { get; set; }
        
        private double? _Stawka;
        public double? Stawka
        {
            get => _Stawka; set
            {
                _Stawka = value;
                RaisePropertyChanged("Stawka");
            }
        }

        private int? _Okres;
        public int? Okres
        {
            get => _Okres;
            set
            {
                _Okres = value;
                RaisePropertyChanged("Okres");
            }
        }

        private double? _Wartosc;
        public double? Wartosc
        {
            get => _Wartosc;
            set
            {
                _Wartosc = value;
                RaisePropertyChanged("Wartosc");
            }
        }
        private double? _Wysokosc;
        public double? Wysokosc
        {
            get => _Wysokosc;
            set
            {
                _Wysokosc = value;
                RaisePropertyChanged("Wysokosc");
            }
        }

        public int? _rok1;
        public int? rok1
        {
            get => _rok1;
            set
            {
                _rok1 = value;
                RaisePropertyChanged("rok1");
            }
        }
        public int? _rok2;
        public int? rok2
        {
            get => _rok2;
            set
            {
                _rok2 = value;
                RaisePropertyChanged("rok2");
            }
        }
        private int? _rok3;
        public int? rok3
        {
            get => _rok3;
            set
            {
                _rok3 = value;
                RaisePropertyChanged("rok3");
            }
        }

        public int DzialkaId { get; set; }
        public Dzialka Dzialka { get; set; }

        public PlatnoscUW() { }

        public void save(PlatnoscUW p)
        {
            using (var c = new Context())
            {
                c.Update(p);
                c.SaveChanges();
            }
        }

        private bool isEqual(PlatnoscUW p)
        {
            return this.Stawka == Stawka &&
                   this.Okres == Okres &&
                   this.Wartosc == Wartosc &&
                   this.Wysokosc == Wysokosc &&
                   this.rok1 == rok1 &&
                   this.rok2 == rok2 &&
                   this.rok3 == rok3;
        }

        public PlatnoscUW clone()
        {
            return (PlatnoscUW)this.MemberwiseClone();
        }

        public void cleanObj()
        {
            //this.DzialkaId = null;
            this.Okres = null;
            this.rok1 = null;
            this.rok2 = null;
            this.rok3 = null;
            this.Stawka = null;
            this.Wartosc = null;
            this.Wysokosc = null;
        }

        public bool isNull()
        {
            return (Stawka == null || Stawka.Value == 0) &&
                   (Okres == null || Okres.Value == 0) &&
                   (Wartosc == null || Wartosc.Value == 0) &&
                   (Wysokosc == null || Wysokosc.Value == 0) &&
                   (rok1 == null || rok1.Value == 0) &&
                   (rok2 == null || rok2.Value == 0) &&
                   (rok3 == null || rok3.Value == 0);
        }
        
    }
}

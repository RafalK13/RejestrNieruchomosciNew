using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections;

namespace RejestrNieruchomosciNew.Model
{

    public class Uzytki : ViewModelBase, IUzytki, ICloneable
    {
        public EventHandler powChange;

        public int UzytkiId { get; set; }
        public int DzialkaId { get; set; }
        public int UzytkiSloId { get; set; }

        private double? _Pow;
        public double? Pow
        {
            get => _Pow;
            set {
                _Pow = value;

                if (powChange != null)
                    powChange( null, EventArgs.Empty);
            }
        }


        //private double? _Pow;
        //public double? Pow
        //{
        //    get => _Pow;
        //    set { Set(ref _Pow, value); }
        //}

        public Dzialka Dzialka { get; set; }
        public UzytkiSlo UzytkiSlo { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public Uzytki()
        {

        }

        public Uzytki(IUzytki u)
        {
            UzytkiId = u.UzytkiId;
            DzialkaId = u.DzialkaId;
            UzytkiSloId = u.UzytkiSloId;
            Pow = u.Pow;
        }
    }
}

using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections;

namespace RejestrNieruchomosciNew.Model
{
    public class Uzytki : IUzytki, ICloneable
    {
        public int UzytkiId { get; set; }
        public int DzialkaId { get; set; }
        public int UzytkiSloId { get; set; }
        public double? Pow { get; set; }
        
        public Dzialka Dzialka { get; set; }
        public UzytkiSlo UzytkiSlo { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public Uzytki()
        {

        }

        public Uzytki( IUzytki u)
        {
            UzytkiId = u.UzytkiId;
            DzialkaId = u.DzialkaId;
            UzytkiSloId = u.UzytkiSloId;
            Pow = u.Pow;
        }
    }
}

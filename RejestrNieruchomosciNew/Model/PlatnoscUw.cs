using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class PlatnoscUW : IPlatnoscUW
    {
        public int PlatnoscUWId { get; set; }
        public int? DzialkaId { get; set; }
        public double? Stawka { get; set; }
        public int? Okres { get; set; }
        public double? Wartosc { get; set; }

        public int rok1 { get; set; }
        public int rok2 { get; set; }
        public int rok3 { get; set; }

        public Dzialka Dzialka { get; set; }
    }
}

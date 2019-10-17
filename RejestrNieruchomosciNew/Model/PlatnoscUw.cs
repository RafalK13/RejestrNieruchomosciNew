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

        public ICollection<Wladanie> Wladanie { get; set; }
        
    }
}

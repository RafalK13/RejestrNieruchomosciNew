using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class PlatnoscUw : IPlatnoscUw
    {
        public int Id { get; set; }
        public double? Stawka { get; set; }
        public int? Okres { get; set; }
        public double? Wartosc { get; set; }

        public Wladanie Wladanie { get; set; }
    }
}

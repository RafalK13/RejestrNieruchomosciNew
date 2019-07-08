using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class PlatnoscUw
    {
        public int Id { get; set; }
        public double? Stawka { get; set; }
        public int? Okres { get; set; }
        public double? Wartosc { get; set; }

        public virtual ICollection<Wladanie> Wladanie { get; set; }
    }
}

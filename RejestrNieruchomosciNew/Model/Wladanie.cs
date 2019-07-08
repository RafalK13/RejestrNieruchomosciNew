using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class Wladanie
    {
        public int WladanieId { get; set; }
       // public int DzialkaId { get; set; }
       // public int PodmiotId { get; set; }
        public string Udzial { get; set; }
        public int? FormaWladaniaId { get; set; }
        public int? NazwaCzynnosciId { get; set; }
        public int? RodzajDokumentuId { get; set; }
        public string TytulDokumentu { get; set; }
        public DateTime? DataDokumentu { get; set; }
        public DateTime? DataObowiazywaniaOd { get; set; }
        public DateTime? DataObowiazywaniaDo { get; set; }
        public int? PlatnoscUwid { get; set; }
        public int? Stawka { get; set; }
        public int? Okres { get; set; }
        public decimal? Wartosc { get; set; }

        public virtual Dzialka Dzialka { get; set; }
        //public virtual FormaWladaniaSlo FormaWladania { get; set; }
        //public virtual NazwaCzynnosciSlo NazwaCzynnosci { get; set; }
        //public virtual PlatnoscUw PlatnoscUw { get; set; }
        //public virtual Podmiot Podmiot { get; set; }
        //public virtual RodzajDokumentuSlo RodzajDokumentu { get; set; }
    }
}

using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class Wladanie : IWladanie
    {
        public int WladanieId { get; set; }
        public int? DzialkaId { get; set; }
        public int? PodmiodId { get; set; }
        public int? FormaWladaniaId { get; set; }
        public int? NazwaCzynnosciId { get; set; }
        public int? RodzajDokumentuId { get; set; }
        public int? PlatnoscUwId { get; set; }
        public string TytulDokumentu { get; set; }
        public DateTime? DataDokumentu { get; set; }
        public DateTime? DataObowiazywaniaOd { get; set; }
        public DateTime? DataObowiazywaniaDo { get; set; }
        public string Udzial { get; set; }
        public int? Stawka { get; set; }
        public int? Okres { get; set; }
        public decimal? Wartosc { get; set; }

        public Dzialka Dzialka { get; set; }
        public Podmiot Podmiot { get; set; }
        public PlatnoscUw PlatnoscUw { get; set; }
        public NazwaCzynnosciSlo NazwaCzynnosciSlo { get; set; }
        public RodzajDokumentuSlo RodzajDokumentuSlo { get; set; }
        public FormaWladaniaSlo FormaWladaniaSlo { get; set; }
    }
}

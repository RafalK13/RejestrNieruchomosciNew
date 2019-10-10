using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class Wladanie : IWladanie
    {
        public int WladanieId { get; set; }
        public int DzialkaId { get; set; }
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

        public ICollection<Dzialka> Dzialka { get; set; }
        public ICollection<PlatnoscUw> PlatnoscUw { get; set; }
        public ICollection<NazwaCzynnosciSlo> NazwaCzynnosciSlo { get; set; }
        public ICollection<RodzajDokumentuSlo> RodzajDokumentuSlo { get; set; }
        //public ICollection<MK_REJNIER_PERSONS> MK_REJNIER_PERSONS { get; set; }
        public ICollection<FormaWladaniaSlo> FormaWladaniaSlo { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class InnePrawa
    {
        public int Id { get; set; }
        public int DzialkaId { get; set; }
        public int? InnePrawaId { get; set; }
        public int PodmiotId { get; set; }
        public int? PrzedstawicielId { get; set; }
        public int? NazwaCzynnosciNabId { get; set; }
        public int? RodzajDokumentuNabId { get; set; }
        public string NrDokumentuNab { get; set; }
        public DateTime? DataDokumentuNab { get; set; }
        public string TytulDokumentuNab { get; set; }
        public DateTime? DataWpisuKwnab { get; set; }
        public DateTime? DataObowiazywaniaOd { get; set; }
        public DateTime? DataObowiazywaniaDo { get; set; }
        public DateTime? DoPrzekazania { get; set; }
        public DateTime? DoZwrotnegoPrzekazania { get; set; }
        public int? Stawka { get; set; }
        public int? Okres { get; set; }
        public decimal? Wartosc { get; set; }
        public string WarunkiRealizacji { get; set; }
        public string DecyzjaNr { get; set; }
        public DateTime? DecyzjaData { get; set; }
        public int? DecyzjaOrganId { get; set; }
        public string DecyzjaPrzedmiot { get; set; }
        public int? NazwaCzynnosciZbId { get; set; }
        public int? RodzajDokumentuZbId { get; set; }
        public string NrDokumentuZb { get; set; }
        public DateTime? DataDokumentuZb { get; set; }
        public string TytulDokumentuZb { get; set; }
        public DateTime? DataWpisuKwzb { get; set; }

        public virtual Dzialka Dzialka { get; set; }
    }
}

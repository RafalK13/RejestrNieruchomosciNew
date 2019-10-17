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
        public string Udzial { get; set; }
        public int? NabycieId { get; set; }
        public int? ZbycieId { get; set; }

        //public Dzialka Dzialka { get; set; }
        //public Podmiot Podmiot { get; set; }
        //public PlatnoscUw PlatnoscUw { get; set; }
        //public NazwaCzynnosciSlo NazwaCzynnosciSlo { get; set; }
        //public RodzajDokumentuSlo RodzajDokumentuSlo { get; set; }
        //public FormaWladaniaSlo FormaWladaniaSlo { get; set; }
    }
}

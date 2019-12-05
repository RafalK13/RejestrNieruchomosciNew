using System;
using System.ComponentModel.DataAnnotations.Schema;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class InnePrawa : IInnePrawa
    {
        public int InnePrawaId { get; set; }
        public int? DzialkaId { get; set; }
        public int? PodmiotId { get; set; }

        public int? RodzajInnegoPrawaSloId { get; set; }
       
        public DateTime? DataObowOd { get; set; }
        public DateTime? DataObowDo { get; set; }
        public string ProtPrzejkNr { get; set; }
        public DateTime? ProtPrzejData { get; set; }
        public string ProtPrzejScan { get; set; }
        public string ProtZwrotNr { get; set; }
        public DateTime? ProtZwrotData { get; set; }
        public string ProtZwrotScan { get; set; }
        public DateTime? wizjaTerPrzek { get; set; }
        public DateTime? wizjaTerZwrot { get; set; }

        public int? CelNabyciaId { get; set; }

        public string WarunkiRealizacji { get; set; }

        public int? DecyzjeAdministracyjneId { get; set; }

        [ForeignKey("TransakcjeK_InnePr")]
        public int? TransK_Id { get; set; }
        public Transakcje TransakcjeK_InnePr { get; set; }

        [ForeignKey("TransakcjeS_InnePr")]
        public int? TransS_Id { get; set; }
        public Transakcje TransakcjeS_InnePr { get; set; }

        public RodzajInnegoPrawaSlo RodzajInnegoPrawaSlo { get; set; }

        //public int? PlatnosciId { get; set; }
        public PlatnoscInnePrawa PlatnoscInnePrawa { get; set; }

        //public DecyzjeAdministracyjne DecyzjeAdministracyjne { get; set; }

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }

        bool IEquatable<IInnePrawa>.Equals(IInnePrawa other)
        {
            throw new NotImplementedException();
        }
    }
}

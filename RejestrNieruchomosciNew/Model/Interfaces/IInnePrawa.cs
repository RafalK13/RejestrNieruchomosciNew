using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IInnePrawa : IEquatable<IInnePrawa>, ICloneable
    {
        int InnePrawaId { get; set; }

        int DzialkaId { get; set; }
        int PodmiotId { get; set; }

        int? RodzajInnegoPrawaSloId { get; set; }

        int? TransK_Id { get; set; }
        int? TransS_Id { get; set; }

        DateTime? DataObowOd { get; set; }
        DateTime? DataObowDo { get; set; }

        string ProtPrzejkNr { get; set; }
        DateTime? ProtPrzejData { get; set; }
        string ProtPrzejScan { get; set; }
        
        string ProtZwrotNr { get; set; }
        DateTime? ProtZwrotData { get; set; }
        string ProtZwrotScan { get; set; }

        DateTime? wizjaTerPrzek { get; set; }
        DateTime? wizjaTerZwrot { get; set; }

        int? CelNabyciaId { get; set; }

        //int? PlatnosciId { get; set; }

        string WarunkiRealizacji { get; set; }

        int? DecyzjeAdministracyjneId { get; set; }

    }
}

using System;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    interface IInnePrawa : IEquatable<IInnePrawa>, ICloneable
    {
        int InnePrawaId { get; set; }
        int? DzialkaId { get; set; }
        int? PodmiotId { get; set; }

        int? RodzajInnegoPrawaSloId { get; set; }

        int? TransK_Id { get; set; }
        int? TransS_Id { get; set; }

        DateTime? DataObowOd { get; set; }
        DateTime? DataObowDo { get; set; }
        string ProtPrzekNr { get; set; }
        DateTime? ProtPrzekData { get; set; }
        string ProtPrzekScan { get; set; }

        string ProtZwrotNr { get; set; }
        DateTime? ProtZwrotData { get; set; }
        string ProtZwrotScan { get; set; }

        DateTime? wizjaTerPrzek { get; set; }
        DateTime? wizjaTerZwrot { get; set; }

        //int? NabycieId { get; set; }

        Podmiot Podmiot { get; set; }
    }
}

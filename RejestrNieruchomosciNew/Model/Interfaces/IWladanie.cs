using System;

namespace RejestrNieruchomosciNew.Model
{
    public interface IWladanie : IEquatable<IWladanie>, ICloneable
    {
        int WladanieId { get; set; }
        int? DzialkaId { get; set; }
        int? PodmiotId { get; set; }

        int? FormaWladaniaSloId { get; set; }

        FormaWladaniaSlo FormaWladaniaSlo { get; set; }
    
        int? TransK_Id { get; set; }
        int? TransS_Id { get; set; }
    
        DateTime? DataOdbOd { get; set; }
        DateTime? DataOdbDo { get; set; }
        string NrProtPrzejecia { get; set; }
        DateTime? DataProtPrzej { get; set; }
        string Scan { get; set; }

        int? CelNabyciaId { get; set; }
        string Udzial { get; set; }
    }
}

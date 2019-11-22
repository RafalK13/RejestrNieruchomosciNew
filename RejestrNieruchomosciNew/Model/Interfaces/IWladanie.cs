using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IWladanie : IEquatable<IWladanie>, ICloneable
    {
        int WladanieId { get; set; }
        int? DzialkaId { get; set; }
        int? PodmiotId { get; set; }

        int? FormaWladaniaSloId { get; set; }

        int? TransK_Id { get; set; }
        int? TransS_Id { get; set; }

        DateTime? DataOdbOd { get; set; }
        DateTime? DataOdbDo { get; set; }
        string NrProtPrzejecia { get; set; }
        DateTime? DataProtPrzej { get; set; }
        string Scan { get; set; }

        //int? NabycieId { get; set; }
        string Udzial { get; set; }

        Podmiot Podmiot { get; set; }

        //int WladanieId { get; set; }
        //int? DzialkaId { get; set; }
        //int? PodmiotId { get; set; }

        //int? FormaWladaniaSloId { get; set; }

        //int? TransK_Id { get; set; }
        //int? TransS_Id { get; set; }

        //DateTime? ObowPrawaOd { get; set; }
        //DateTime? ObowPrawaDo { get; set; }

        //string ProtPrzejNr { get; set; }
        //DateTime? ProtPrzejData { get; set; }
        //string ProtPrzejScan { get; set; }

        //string ProtZwrotNr { get; set; }
        //DateTime? ProtZwrotData { get; set; }
        //string ProtZwrotScan { get; set; }

        //DateTime? wizjaTerPrzek { get; set; }
        //DateTime? wizjaTerZwrot { get; set; }

        //Podmiot Podmiot { get; set; }
    }
}

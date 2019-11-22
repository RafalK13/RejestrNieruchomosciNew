using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RejestrNieruchomosciNew
{
    public partial class Wladanie : IWladanie
    {
        public int WladanieId { get; set; }
        public int? DzialkaId { get; set; }
        public int? PodmiotId { get; set; }

        public int? FormaWladaniaSloId { get; set; }

        public string Udzial { get; set; }

        public DateTime? DataOdbOd { get; set; }
        public DateTime? DataOdbDo { get; set; }
        public string NrProtPrzejecia { get; set; }
        public DateTime? DataProtPrzej { get; set; }
        public string Scan { get; set; }
        public int? CelNabyciaId { get; set; }

        [ForeignKey("TransakcjeK")]
        public int? TransK_Id { get; set; }
        public Transakcje TransakcjeK { get; set; }

        [ForeignKey("TransakcjeS")]
        public int? TransS_Id { get; set; }
        public Transakcje TransakcjeS { get; set; }

        public Podmiot Podmiot { get; set; }
        public CelNabycia CelNabycia { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        //object ICloneable.Clone()
        //{
        //    Wladanie w = new Wladanie();

        //    w.DzialkaId = DzialkaId;
        //    w.PodmiotId = PodmiotId;
        //    w.FormaWladaniaSloId = FormaWladaniaSloId;
        //    w.TransakcjaId = TransakcjaId;
        //    w.NabycieId = NabycieId;
        //    w.Udzial = Udzial;

        //    if (Podmiot != null)
        //    {
        //        Podmiot p = new Podmiot();
        //        w.Podmiot = p;
        //        p.PodmiotId = Podmiot.PodmiotId;
        //        p.Name = Podmiot.Name;
        //    }

        //    return w;
        //}

        bool IEquatable<IWladanie>.Equals(IWladanie other)
        {
            return WladanieId.Equals(other.WladanieId) &&
                   DzialkaId.Equals(other.DzialkaId) &&
                   PodmiotId.Equals(other.PodmiotId) &&
                   FormaWladaniaSloId.Equals(other.FormaWladaniaSloId) &&
                   TransK_Id.Equals(other.TransK_Id) &&
                   TransS_Id.Equals(other.TransS_Id) &&
                   string.Equals( Udzial,other.Udzial) &&
                   DataOdbOd.Equals(other.DataOdbOd) &&
                   DataOdbDo.Equals(other.DataOdbDo) &&
                   string.Equals(NrProtPrzejecia, other.NrProtPrzejecia) &&
                   string.Equals(DataProtPrzej, other.DataProtPrzej) &&
                   string.Equals(Scan, other.Scan);
                   
        }
    }

}

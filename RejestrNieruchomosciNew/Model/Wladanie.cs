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

        public int? NabycieId { get; set; }
        public string Udzial { get; set; }

        [ForeignKey("TransakcjeK")]
        public int? TransK_Id { get; set; }
        public Transakcje TransakcjeK { get; set; }

        [ForeignKey("TransakcjeS")]
        public int? TransS_Id { get; set; }
        public Transakcje TransakcjeS { get; set; }

        public Podmiot Podmiot { get; set; }

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
                   //TransakcjaId.Equals(other.TransakcjaId) &&
                   string.Equals( Udzial,other.Udzial) &&
                   NabycieId.Equals(other.NabycieId);
                   
        }
    }

}

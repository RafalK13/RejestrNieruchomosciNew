﻿using RejestrNieruchomosciNew.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace RejestrNieruchomosciNew
{
    public partial class Wladanie : IWladanie
    {
        public int WladanieId { get; set; }
        public int? DzialkaId { get; set; }
        public int? PodmiotId { get; set; }

        public int? FormaWladaniaSloId { get; set; }

        public FormaWladaniaSlo FormaWladaniaSlo { get; set; }

        public string Udzial { get; set; }

        public DateTime? DataOdbOd { get; set; }
        public DateTime? DataOdbDo { get; set; }
        public string NrProtPrzejecia { get; set; }
        public DateTime? DataProtPrzej { get; set; }
        public string Scan { get; set; }
        public int? CelNabyciaId { get; set; }

        [ForeignKey("TransakcjeK_Wlad")]
        public int? TransK_Id { get; set; }
        public Transakcje TransakcjeK_Wlad { get; set; }

        [ForeignKey("TransakcjeS_Wlad")]
        public int? TransS_Id { get; set; }
        public Transakcje TransakcjeS_Wlad { get; set; }

        public Dzialka Dzialka { get; set; }

        public string ZalPath
        {
            get
            {
                if (DzialkaId != null && PodmiotId != null)
                {
                    return ConfigurationManager.AppSettings["zalacznikPath"] + "\\Dzialka\\" + DzialkaId + "\\Wladanie\\ProtokolPrzejecia\\" + PodmiotId;
                }
                return null;
            }
        }

        public string ZalPathOld
        {
            get
            {
                if (ZalPath != null)
                {
                    DateTime d = DateTime.Now;
                    return ZalPath + $"_{d.ToShortDateString()}_{d.ToLongTimeString().Replace(':', '.')}";
                }
                return null;
            }
        }

        public Wladanie()
        {

        }

        public Wladanie(IWladanie w)
        {
            WladanieId = w.WladanieId;
            DzialkaId = w.DzialkaId;
            PodmiotId = w.PodmiotId;
            FormaWladaniaSloId = w.FormaWladaniaSloId;
            Udzial = w.Udzial;
            DataOdbOd = w.DataOdbOd;
            DataOdbDo = w.DataOdbDo;
            NrProtPrzejecia = w.NrProtPrzejecia;
            DataProtPrzej = w.DataProtPrzej;
            Scan = w.Scan;
            CelNabyciaId = w.CelNabyciaId;
            TransK_Id = w.TransK_Id;
            TransS_Id = w.TransS_Id;
    }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        bool IEquatable<IWladanie>.Equals(IWladanie other)
        {
            return WladanieId.Equals(other.WladanieId) &&
                   DzialkaId.Equals(other.DzialkaId) &&
                   PodmiotId.Equals(other.PodmiotId) &&
                   FormaWladaniaSloId.Equals(other.FormaWladaniaSloId) &&
                   TransK_Id.Equals(other.TransK_Id) &&
                   TransS_Id.Equals(other.TransS_Id) &&
                   string.Equals(Udzial, other.Udzial) &&
                   DataOdbOd.Equals(other.DataOdbOd) &&
                   DataOdbDo.Equals(other.DataOdbDo) &&
                   string.Equals(NrProtPrzejecia, other.NrProtPrzejecia) &&
                   string.Equals(DataProtPrzej, other.DataProtPrzej) &&
                   string.Equals(CelNabyciaId, other.CelNabyciaId) &&
                   string.Equals(Scan, other.Scan);
        }
    }

}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class InnePrawa : IInnePrawa
    {
        public int InnePrawaId { get; set; }
        public int DzialkaId { get; set; }
        public int PodmiotId { get; set; }

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

        [ForeignKey("TransakcjeK_InnePr")]
        public int? TransK_Id { get; set; }
        public Transakcje TransakcjeK_InnePr { get; set; }

        [ForeignKey("TransakcjeS_InnePr")]
        public int? TransS_Id { get; set; }
        public Transakcje TransakcjeS_InnePr { get; set; }

        public RodzajInnegoPrawaSlo RodzajInnegoPrawaSlo { get; set; }

        public PlatnoscInnePrawa PlatnoscInnePrawa { get; set; }

        public Dzialka Dzialka { get; set; }

        public int? DecyzjeAdministracyjneId { get; set; }
        public DecyzjeAdministracyjne DecyzjeAdministracyjne { get; set; }

        public string ProtPrzejPath
        {
            get
            {
                //if (DzialkaId != null && PodmiotId != null)
                {
                    return ConfigurationManager.AppSettings["zalacznikPath"] + "\\Dzialka\\" + DzialkaId + "\\InnePrawa\\ProtokolPrzejecia\\" + PodmiotId;
                }
                //return null;
            }
        }

        public string ProtPrzejPathOld
        {
            get
            {
                if (ProtPrzejPath != null)
                {
                    DateTime d = DateTime.Now;
                    return ProtPrzejPath + $"_{d.ToShortDateString()}_{d.ToLongTimeString().Replace(':', '.')}";
                }
                return null;
            }
        }

        public string ProtZwrotPath
        {
            get
            {
                //if (DzialkaId != null && PodmiotId != null)
                {
                    return ConfigurationManager.AppSettings["zalacznikPath"] + "\\Dzialka\\" + DzialkaId + "\\InnePrawa\\ProtokolZwrotny\\" + PodmiotId;
                }
                //return null;
            }
        }

        public string ProtZwrotPathOld
        {
            get
            {
                if (ProtPrzejPath != null)
                {
                    DateTime d = DateTime.Now;
                    return ProtZwrotPath + $"_{d.ToShortDateString()}_{d.ToLongTimeString().Replace(':', '.')}";
                }
                return null;
            }
        }

        public InnePrawa()
        {

        }

        public object Clone()
        {
            InnePrawa inne = (InnePrawa)this.MemberwiseClone();

            if (this.PlatnoscInnePrawa != null)
                inne.PlatnoscInnePrawa = (PlatnoscInnePrawa)this.PlatnoscInnePrawa.clone();
            
            return inne;
        }

        bool IEquatable<IInnePrawa>.Equals(IInnePrawa other)
        {
            //return //InnePrawaId.Equals(other.InnePrawaId) &&
            //       DzialkaId.Equals(other.DzialkaId) &&
            //       PodmiotId.Equals(other.PodmiotId) &&
            //       RodzajInnegoPrawaSloId.Equals(other.RodzajInnegoPrawaSloId) &&
            //       TransK_Id.Equals(other.TransK_Id) &&
            //       TransS_Id.Equals(other.TransS_Id) &&
            //       DataObowOd.Equals(other.DataObowOd) &&
            //       DataObowDo.Equals(other.DataObowDo) &&
            //       string.Equals(ProtPrzejkNr, other.ProtPrzejkNr) &&
            //       ProtPrzejData.Equals(other.ProtPrzejData) &&
            //       string.Equals(ProtPrzejScan, other.ProtPrzejScan) &&
            //       string.Equals(ProtZwrotNr, other.ProtZwrotNr) &&
            //       ProtZwrotData.Equals(other.ProtZwrotData) &&
            //       string.Equals(ProtZwrotScan, other.ProtZwrotScan) &&
            //       wizjaTerPrzek.Equals(other.wizjaTerPrzek) &&
            //       wizjaTerZwrot.Equals(other.wizjaTerZwrot) &&
            //       CelNabyciaId.Equals(other.CelNabyciaId) &&
            //       string.Equals(WarunkiRealizacji, other.WarunkiRealizacji) &&
            //       PlatnoscInnePrawa.Equals(other.PlatnoscInnePrawa);
            ////DecyzjeAdministracyjneId.Equals(other.DecyzjeAdministracyjneId);



            bool a = InnePrawaId.Equals(other.InnePrawaId) &&
                  DzialkaId.Equals(other.DzialkaId) &&
                  PodmiotId.Equals(other.PodmiotId) &&
                  RodzajInnegoPrawaSloId.Equals(other.RodzajInnegoPrawaSloId) &&
                  TransK_Id.Equals(other.TransK_Id) &&
                  TransS_Id.Equals(other.TransS_Id) &&
                  DataObowOd.Equals(other.DataObowOd) &&
                   DataObowDo.Equals(other.DataObowDo) &&
                  string.Equals(ProtPrzejkNr, other.ProtPrzejkNr) &&
                  ProtPrzejData.Equals(other.ProtPrzejData) &&
                  string.Equals(ProtPrzejScan, other.ProtPrzejScan) &&
                  string.Equals(ProtZwrotNr, other.ProtZwrotNr) &&
                  ProtZwrotData.Equals(other.ProtZwrotData) &&
                  string.Equals(ProtZwrotScan, other.ProtZwrotScan) &&
                  wizjaTerPrzek.Equals(other.wizjaTerPrzek) &&
                  wizjaTerZwrot.Equals(other.wizjaTerZwrot) &&
                  CelNabyciaId.Equals(other.CelNabyciaId) &&
                  string.Equals(WarunkiRealizacji, other.WarunkiRealizacji);
                  //PlatnoscInnePrawa.Equals(other.PlatnoscInnePrawa);

            return a;
        }
    }
}

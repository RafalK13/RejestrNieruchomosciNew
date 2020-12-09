using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RejestrNieruchomosciNew.Model
{
    public class Zagosp : IZagosp, INotifyPropertyChanged
    {
        public int ZagospId { get; set; }
        public int? DzialkaId { get; set; }

        private int? _ZagospStatusId;
        public int? ZagospStatusId { get=> _ZagospStatusId;
            set {
                _ZagospStatusId = value;
                NotifyPropertyChanged();
                if (zmiana != null)
                    zmiana(null, EventArgs.Empty);

            } }

        public int? istObiektySloId { get; set; }       //1
        public int? zadInwestSloId { get; set; }        //2
        public string PlanowaneZagosp { get; set; }     //3
        public string DodatkoweZagosp { get; set; }     //4
        public string DoWylaczenia { get; set; }        //5
       
        public string WylaczenieProt { get; set; }      //6

        public string WylacznieProtokolPath             //7
        {
            get =>  System.Configuration.ConfigurationManager.AppSettings["zalacznikPath"] + "\\Dzialka\\" + DzialkaId + "\\Zagospodarowanie\\Protokol\\";
        }

        public string WylacznieInfo { get; set; }       //8

        public string WylacznieInfoPath                 //9
        {
            get => System.Configuration.ConfigurationManager.AppSettings["zalacznikPath"] + "\\Dzialka\\" + DzialkaId + "\\Zagospodarowanie\\Info\\";
        }
        public Dzialka Dzialka { get; set; }
        public ZagospStatus ZagospStatus{ get; set; }

        #region Konstruktor
        public Zagosp(int _dzialkaId)
        {
            DzialkaId = _dzialkaId;
        }
        #endregion

        #region Z przeda zmiany
        //public int? obiektyKomSloId { get; set; }
        //public string zagospKomercyjne { get; set; }
        //public string celeKom { get; set; }
        //public int? przedstSloId { get; set; }
        #endregion

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Zagosp()
        {

        }

        public Zagosp(IZagosp z)
        {
            ZagospId = z.ZagospId;
            DzialkaId = z.DzialkaId;
            ZagospStatusId = z.ZagospStatusId;
            istObiektySloId = z.istObiektySloId;    //1
            zadInwestSloId = z.zadInwestSloId;      //2
            PlanowaneZagosp = z.PlanowaneZagosp;    //3
            DodatkoweZagosp = z.DodatkoweZagosp;    //4
            DoWylaczenia = z.DodatkoweZagosp;       //5
            WylaczenieProt = z.WylaczenieProt;      //6
            WylacznieInfo = z.WylacznieInfo;        //8
        }

        public override bool Equals(object other)
        {
            IZagosp obj = other as IZagosp;

            if (obj == null)
                return false;

            return ZagospId.Equals(obj.ZagospId) &&
                    DzialkaId.Equals(obj.DzialkaId) &&
                    ZagospStatusId.Equals(obj.ZagospStatusId) &&
                    istObiektySloId.Equals(obj.istObiektySloId) &&
                    zadInwestSloId.Equals(obj.zadInwestSloId) &&

                    string.Equals(PlanowaneZagosp, obj.PlanowaneZagosp) &&
                    string.Equals(DodatkoweZagosp, obj.DodatkoweZagosp) &&
                    string.Equals(DoWylaczenia, obj.DoWylaczenia) &&
                    string.Equals(WylacznieProtokolPath, obj.WylacznieProtokolPath) &&
                    string.Equals(WylacznieInfo, obj.WylacznieInfo) &&
                    string.Equals(WylacznieInfoPath, obj.WylacznieInfoPath);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (ZagospId.GetHashCode());

                return hash;
            }
        }
        public event EventHandler zmiana;

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

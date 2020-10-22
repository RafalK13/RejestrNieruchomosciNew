using RejestrNieruchomosciNew.Model.Interfaces;
using System;

namespace RejestrNieruchomosciNew.Model
{
    public class Zagosp : IZagosp
    {
        public int ZagospId { get; set; }
        public int DzialkaId { get; set; }

        public int? ZagospStatusSloId { get; set; }
        public int? ZagospFunkcjaSloId { get; set; }

        public int? istObiektySloId { get; set; }
        public int? obiektyKomSloId { get; set; }
        public string zagospKomercyjne { get; set; }
        public int? zadInwestSloId { get; set; }
        public string celeKom { get; set; }

        public int? przedstSloId { get; set; }

        public Dzialka Dzialka { get; set; }
        public ZagospFunkcjaSlo ZagospFunkcjaSlo { get; set; }
        public ZagospStatusSlo ZagospStatusSlo { get; set; }

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
            ZagospStatusSloId = z.ZagospStatusSloId;
            ZagospFunkcjaSloId = z.ZagospFunkcjaSloId;
            istObiektySloId = z.istObiektySloId;
            obiektyKomSloId = z.obiektyKomSloId;
            zadInwestSloId = z.zadInwestSloId;
            przedstSloId = z.przedstSloId;
            zagospKomercyjne = z.zagospKomercyjne;
            celeKom = z.celeKom;
        }

        public override bool Equals(object other)
        {
            IZagosp obj = other as IZagosp;

            if (obj == null)
                return false;

            return ZagospId.Equals(obj.ZagospId) &&
                    DzialkaId.Equals(obj.DzialkaId) &&
                    ZagospStatusSloId.Equals(obj.ZagospStatusSloId) &&
                    ZagospFunkcjaSloId.Equals(obj.ZagospFunkcjaSloId) &&
                    istObiektySloId.Equals(obj.istObiektySloId) &&
                    obiektyKomSloId.Equals(obj.obiektyKomSloId) &&
                    zadInwestSloId.Equals(obj.zadInwestSloId) &&
                    przedstSloId.Equals(obj.przedstSloId) &&
                    string.Equals(zagospKomercyjne, zagospKomercyjne) &&
                    string.Equals(celeKom, obj.celeKom);

        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                //const int HashingBase = (int)2166;
                //const int HashingMultiplier = 1677;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (ZagospId.GetHashCode());
                //hash = (hash * HashingMultiplier) ^ (Object.ReferenceEquals(null, DzialkaId) ? 0 : DzialkaId.GetHashCode());
                //hash = (hash * HashingMultiplier) ^ (Object.ReferenceEquals(null, ZagospStatusSloId) ? 0 : ZagospStatusSloId.GetHashCode());
                //hash = (hash * HashingMultiplier) ^ (Object.ReferenceEquals(null, stanTech) ? 0 : stanTech.GetHashCode());

                //using (StreamWriter writer = new StreamWriter("c:\\test\\result.txt", true))
                //{
                //    writer.WriteLine( $"{hash} {Nazwa} {BudynekId} {opisKonstr} {stanTech}" );
                //}

                return hash;
            }
        }
    }
}

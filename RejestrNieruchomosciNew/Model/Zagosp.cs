using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class Zagosp : IZagosp
    {
        public int ZagospId { get; set; }
        public int DzialkaId { get; set; }
        public string Nazwa { get; set; }
        public int? ZagospStatusSloId { get; set; }
        public int? ZagospFunkcjaSloId { get; set; }

        public int? istObiektySloId { get; set; }
        public int? obiektyKomSloId { get; set; }
        public int? zadInwestSloId { get; set; }
        public int? celeKomSloId { get; set; }


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
            Nazwa = z.Nazwa;
            ZagospStatusSloId = z.ZagospStatusSloId;
            ZagospFunkcjaSloId = z.ZagospFunkcjaSloId;
            istObiektySloId = z.istObiektySloId;
            obiektyKomSloId = z.obiektyKomSloId;
            zadInwestSloId = z.zadInwestSloId;
            celeKomSloId = z.celeKomSloId;
            przedstSloId = z.przedstSloId;
        }
    }
}

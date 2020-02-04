using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class Zagosp : IZagosp
    {
        public int ZagospId { get; set; }
        public int DzialkaId { get; set; }
        public string Nazwa { get; set; }
        public int ZagospStatusSloId { get; set; }
        public int ZagospFunkcjaSloId { get; set; }
        public int istObiektySloId { get; set; }
        public int obiektyKomSloId { get; set; }
        public int zadInwestSloId { get; set; }
        public int celeKomSloId { get; set; }
        public int przedstSloId { get; set; }

        public Dzialka Dzialka { get; set; }
        public ZagospFunkcjaSlo ZagospFunkcjaSlo { get; set; }
        public ZagospStatusSlo ZagospStatusSlo { get; set; }
}
}

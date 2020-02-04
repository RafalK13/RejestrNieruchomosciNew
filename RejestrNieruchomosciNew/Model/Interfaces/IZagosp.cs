namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IZagosp
    {
        int ZagospId { get; set; }
        int DzialkaId { get; set; }

        string Nazwa { get; set; }

        int ZagospStatusSloId { get; set; }
        int ZagospFunkcjaSloId { get; set; }

        int istObiektySloId { get; set; }
        int obiektyKomSloId { get; set; }
        int zadInwestSloId { get; set; }
        int celeKomSloId { get; set; }

        int przedstSloId { get; set; }
    }
}

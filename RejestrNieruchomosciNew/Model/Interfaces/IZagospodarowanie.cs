namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IZagospodarowanie
    {
        int ZagospodarowanieId { get; set; }

        int ZagospodarowanieStatusSloId { get; set; }
        int ZagospodarowanieFunkcjaSloId { get; set; }
        int UzytkiSloId { get; set; }



    }
}

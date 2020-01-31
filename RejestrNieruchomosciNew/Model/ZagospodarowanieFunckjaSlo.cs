using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospodarowanieFunckjaSlo : IZagospodarowanieFunkcjaSlo
    {
        public int ZagospodarowanieFunkcjaSloId { get; set; }
        public string Nazwa { get; set; }
    }
}

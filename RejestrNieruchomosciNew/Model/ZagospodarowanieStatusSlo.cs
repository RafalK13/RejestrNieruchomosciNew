using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospodarowanieStatusSlo : IZagospodarowanieStatusSlo
    {
        public int ZagpospodarowanieSloId { get; set; }
        public string Nazwa { get; set; }
    }
}

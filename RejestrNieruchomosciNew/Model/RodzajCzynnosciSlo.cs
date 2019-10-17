using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class RodzajCzynnosciSlo : IRodzajCzynnosciSlo
    {
        public int RodzajCzynnosciSloId { get; set; }
        public string Nazwa { get; set; }
    }
}

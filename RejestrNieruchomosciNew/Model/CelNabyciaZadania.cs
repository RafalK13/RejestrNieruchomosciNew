using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class CelNabyciaZadania : ICelNabyciaZadania
    {
        public int CelNabyciaZadaniaId { get; set; }
        public string Nazwa { get; set; }
    }
}

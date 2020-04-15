using RejestrNieruchomosciNew.Model.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace RejestrNieruchomosciNew.Model
{
    public class Adres : IAdres
    {
        public int AdresId { get; set; }

        public int? DzialkaId { get; set; }
        
        public string Numer { get; set; }

        public int MiejscowoscSloId { get; set; }
        public int UlicaSloId { get; set; }

        public Dzialka Dzialka { get; set; }
        public MiejscowoscSlo MiejscowoscSlo { get; set; }
        public UlicaSlo UlicaSlo { get; set; }
    }
}

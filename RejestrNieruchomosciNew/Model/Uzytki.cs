using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections;

namespace RejestrNieruchomosciNew.Model
{
    public class Uzytki : IUzytki
    {
        public int UzytkiId { get; set; }
        public int DzialkaId { get; set; }
        public int UzytkiSloId { get; set; }
        public double? Pow { get; set; }
        

        public Dzialka Dzialka { get; set; }
        public UzytkiSlo UzytkiSlo { get; set; }

        public Uzytki()
        {

        }
    }
}

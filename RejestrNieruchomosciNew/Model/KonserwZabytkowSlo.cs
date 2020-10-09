using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public class KonserwZabytkowSlo : IKonserwZabytkowSlo
    {
        public int KonserwZabytkowSloId { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Dzialka> Dzialka { get; set; }

    }
}

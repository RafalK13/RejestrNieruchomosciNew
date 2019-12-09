using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RejestrNieruchomosciNew.Model
{
    public class RodzajInnegoPrawaList
    {
        public List<IRodzajInnegoPrawaSlo> list { get; set; }

        public RodzajInnegoPrawaList()
        {
            using (Context c = new Context())
            {
                list = new List<IRodzajInnegoPrawaSlo>(c.RodzajInnegoPrawaSlo.ToList());
            }
        }
    }
}

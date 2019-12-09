using System.Collections.Generic;
using System.Linq;

namespace RejestrNieruchomosciNew.Model
{
    public class RodzajDokumentuList
    {
        public List<IRodzajDokumentuSlo> list { get; set; }

        public RodzajDokumentuList()
        {
            using (Context c = new Context())
            {
                list = new List<IRodzajDokumentuSlo>(c.RodzajDokumentuSlo.ToList());
            }
        }
    }
}

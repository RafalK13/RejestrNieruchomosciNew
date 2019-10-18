using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class RodzajTransakcjiList
    {
        public List<IRodzajDokumentuSlo> list { get; set; }

        public RodzajTransakcjiList()
        {
            using (Context c = new Context())
            {
                list = new List<IRodzajDokumentuSlo>(c.RodzajDokumentuSlo.ToList());
            }
        }
    }
}

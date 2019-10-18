using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

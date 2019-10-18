using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public class NazwaCzynnosciList
    {
        public List<INazwaCzynosciSlo> list { get; set; }

        public NazwaCzynnosciList()
        {
            using (Context c = new Context())
            {
                list = new List<INazwaCzynosciSlo>(c.NazwaCzynnosciSlo.ToList());
            }
        }
    }
}

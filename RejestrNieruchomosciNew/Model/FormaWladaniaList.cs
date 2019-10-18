using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class FormaWladaniaList
    {
        public List<IFormaWladaniaSlo> list { get; set; }

        public FormaWladaniaList()
        {
            using (Context c = new Context())
            {
                list = new List<IFormaWladaniaSlo>(c.FormaWladaniaSlo.ToList());
            }
        }
    }
}

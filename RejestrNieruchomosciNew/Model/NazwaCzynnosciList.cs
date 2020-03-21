using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public class NazwaCzynnosciList
    {
        public List<INazwaCzynosciSlo> list { get; set; }

        public NazwaCzynnosciList()
        {
            using (Context c = new Context())
            {
                try
                {
                    list = new List<INazwaCzynosciSlo>(c.NazwaCzynnosciSlo.ToList());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"NazwaCzynnosciList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

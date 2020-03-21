using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class RodzajTransakcjiList
    {
        public List<IRodzajDokumentuSlo> list { get; set; }

        public RodzajTransakcjiList()
        {
            using (Context c = new Context())
            {
                try
                {
                    list = new List<IRodzajDokumentuSlo>(c.RodzajDokumentuSlo.ToList());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"RodzajTransakcjiList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

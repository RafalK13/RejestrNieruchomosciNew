using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class RodzajDokumentuList
    {
        public List<IRodzajDokumentuSlo> list { get; set; }

        public RodzajDokumentuList()
        {
            using (Context c = new Context())
            {
                try
                {
                    list = new List<IRodzajDokumentuSlo>(c.RodzajDokumentuSlo.ToList());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"RodzajDokumentuList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

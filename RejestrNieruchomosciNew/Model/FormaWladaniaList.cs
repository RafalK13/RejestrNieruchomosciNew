using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class FormaWladaniaList
    {
        public List<IFormaWladaniaSlo> list { get; set; }

        public FormaWladaniaList()
        {
            using (Context c = new Context())
            {
                try
                {
                    list = new List<IFormaWladaniaSlo>(c.FormaWladaniaSlo.ToList());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"FormaWladaniaList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

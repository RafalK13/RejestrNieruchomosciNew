using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class RodzajInnegoPrawaList
    {
        public List<IRodzajInnegoPrawaSlo> list { get; set; }

        public RodzajInnegoPrawaList()
        {
            using (Context c = new Context())
            {
                try
                {
                    list = new List<IRodzajInnegoPrawaSlo>(c.RodzajInnegoPrawaSlo.ToList());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"RodzajInnegoPrawaLIst\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

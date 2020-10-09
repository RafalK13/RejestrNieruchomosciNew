using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class PrzedstawicielsSloList : IPrzedstawicielSloList
    {
        public ObservableCollection<IPrzedstawicielSlo> list { get; set; }

        public PrzedstawicielsSloList()
        {
            using (var c = new Context())
            {
                try
                {
                    list = new ObservableCollection<IPrzedstawicielSlo>(c.PrzedstawicielSlo.ToList());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"PrzedstawicielSloList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

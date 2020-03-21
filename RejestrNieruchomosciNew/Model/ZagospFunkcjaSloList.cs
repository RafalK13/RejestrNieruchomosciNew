using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospFunkcjaSloList
    {
        public ObservableCollection<IZagospFunkcjaSlo> list { get; set; }

        public ZagospFunkcjaSloList()
        {
            using (var c = new Context())
            {
                try
                {
                    list = new ObservableCollection<IZagospFunkcjaSlo>(c.ZagospFunkcjaSlo.ToList());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"ZAgospodatowanieFunkcjaLIst\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

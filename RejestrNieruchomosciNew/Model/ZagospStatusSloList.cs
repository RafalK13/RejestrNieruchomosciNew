using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospStatusSloList
    {
        public ObservableCollection<IZagospStatusSlo> list { get; set; }

        public ZagospStatusSloList()
        {
            using ( var c = new Context())
            {
                try
                {
                    list = new ObservableCollection<IZagospStatusSlo>(c.ZagospStatusSlo.ToList());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"ZagospStatusSloList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

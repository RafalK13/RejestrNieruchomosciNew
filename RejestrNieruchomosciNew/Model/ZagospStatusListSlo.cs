using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospStatusListSlo
    {
        public ObservableCollection<ZagospStatus> list { get; set; }

        public ZagospStatusListSlo()
        {

            using (var c = new Context())
            {
                try
                {
                    list = new ObservableCollection<ZagospStatus>(c.ZagospStatus.Include(r => r.ZagospStatusSlo)
                                                                                .Include(r => r.ZagospFunkcjaSlo).ToList());

                }
                catch (Exception e)
                {
                    MessageBox.Show($"ZagospStatusListSlo\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class UliceSloList
    {
        public ObservableCollection<UliceSlo>  list { get; set; }

        public UliceSloList()
        {
            using (var v = new Context())
            {
                try
                {
                    list = new ObservableCollection<UliceSlo>(v.UliceSlo);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"UliceSloList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }

    }
}

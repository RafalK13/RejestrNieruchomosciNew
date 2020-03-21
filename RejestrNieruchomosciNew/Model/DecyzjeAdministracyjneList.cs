using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class DecyzjeAdministracyjneList
    {
        public ObservableCollection<DecyzjeAdministracyjne> list { get; set; }

        public DecyzjeAdministracyjneList()
        {
            using (var c = new Context())
            {
                try
                {
                    list = new ObservableCollection<DecyzjeAdministracyjne>(c.DecyzjeAdministracyjne);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"DecyzjeAdministracyjneList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }

        public void AddRow(DecyzjeAdministracyjne newDecyzje)
        {
            using (Context c = new Context())
            {
                c.DecyzjeAdministracyjne.Add(newDecyzje);
                c.SaveChanges();
            }
            list.Add(newDecyzje);
        }

        public void ModRow(DecyzjeAdministracyjne modDecyzje)
        {
            using (Context c = new Context())
            {
                c.DecyzjeAdministracyjne.Update(modDecyzje);
                c.SaveChanges();
            }
        }
    }
}

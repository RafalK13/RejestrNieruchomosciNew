using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class KonserwPrzyrodySloList : IKonserwPrzyrodySloList
    {
        public ObservableCollection<IKonserwPrzyrodySlo> list { get; set; }

        public KonserwPrzyrodySloList()
        {
            using ( var c = new Context())
            {
                try
                {
                    list = new ObservableCollection<IKonserwPrzyrodySlo>(c.KonserwPrzyrodySlo.ToList());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"IKonserwPrzyrodySloList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

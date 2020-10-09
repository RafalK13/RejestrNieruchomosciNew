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
    public class KonserwZabytkowSloList : IKonserwZabytkowSloList
    {
        public ObservableCollection<IKonserwZabytkowSlo> list { get; set; }

        public KonserwZabytkowSloList()
        {
            using ( var c = new Context())
            {
                try
                {
                    list = new ObservableCollection<IKonserwZabytkowSlo>(c.KonserwZabytkowSlo.ToList());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"IKonserwZabytkowSloList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

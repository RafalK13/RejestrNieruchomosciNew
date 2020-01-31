using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class UzytkiSloList : IUzytkiSloList
    {
        public ObservableCollection<UzytkiSlo> list { get; set; }

        public UzytkiSloList()
        {
            fillUzytkiSloList();
        }

        private void fillUzytkiSloList()
        {
            using (var c = new Context())
            {
                list = new ObservableCollection<UzytkiSlo>(c.UzytkiSlo);
            }
        }
    }
}

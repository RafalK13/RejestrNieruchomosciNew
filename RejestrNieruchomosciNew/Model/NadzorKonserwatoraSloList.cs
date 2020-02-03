using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class NadzorKonserwatoraSloList : INadzorKonserwatoraSloList
    {
        public ObservableCollection<INadzorKonserwSlo> list { get; set; }

        public NadzorKonserwatoraSloList()
        {
            using ( var c = new Context())
            {
                list = new ObservableCollection<INadzorKonserwSlo>( c.NadzorKonserwSlo.ToList());
            }
        }
    }
}

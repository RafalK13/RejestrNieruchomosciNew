using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospStatusSloList
    {
        public ObservableCollection<IZagospStatusSlo> list { get; set; }

        public ZagospStatusSloList()
        {
            using ( var c = new Context())
            {
                list = new ObservableCollection<IZagospStatusSlo>( c.ZagospStatusSlo.ToList());
            }
        }
    }
}

using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospFunkcjaSloList
    {
        public ObservableCollection<IZagospFunkcjaSlo> list { get; set; }

        public ZagospFunkcjaSloList()
        {
            using (var c = new Context())
            {
                list = new ObservableCollection<IZagospFunkcjaSlo>(c.ZagospFunkcjaSlo.ToList());
            }
        }
    }
}

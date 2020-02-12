using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model
{
    public class UliceSloList
    {
        public ObservableCollection<UliceSlo>  list { get; set; }

        public UliceSloList()
        {
            using (var v = new Context())
            {
                list = new ObservableCollection<UliceSlo>( v.UliceSlo);
            }
        }

    }
}

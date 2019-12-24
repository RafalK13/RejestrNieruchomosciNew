using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model
{
    public class DecyzjeAdministracyjneList
    {
        public ObservableCollection<DecyzjeAdministracyjne> list { get; set; }

        public DecyzjeAdministracyjneList()
        {
            using (var c = new Context())
            {
                list = new ObservableCollection<DecyzjeAdministracyjne>(c.DecyzjeAdministracyjne);
            }
        }
    }
}

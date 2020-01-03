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

using System.Collections.ObjectModel;
using System.Linq;

namespace RejestrNieruchomosciNew.Model
{
    public class PlatnoscInnePrawaList
    {
        public ObservableCollection<PlatnoscInnePrawa> list { get; set; }

        public PlatnoscInnePrawaList()
        {
            using (Context c = new Context())
            {
                list = new ObservableCollection<PlatnoscInnePrawa>( c.PlatnoscInnePrawa.Select( r => r));
            }
        }

        public void AddRow(PlatnoscInnePrawa i)
        {
            using (var c = new Context())
            {
                c.PlatnoscInnePrawa.Add(i);
                c.SaveChanges();
            }
        }

        public void DelRow(PlatnoscInnePrawa i)
        {
            list.Remove(i);

            using (var c = new Context())
            {
                c.PlatnoscInnePrawa.Remove(i);
                c.SaveChanges();
            }
        }

        public void ModRow(PlatnoscInnePrawa i)
        {
            using (var c = new Context())
            {
                c.Update(i);
                c.SaveChanges();
            }
        }
    }
}

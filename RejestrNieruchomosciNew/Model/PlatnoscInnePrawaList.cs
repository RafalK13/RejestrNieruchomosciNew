using RejestrNieruchomosciNew.ViewModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class PlatnoscInnePrawaList
    {
        public ObservableCollection<PlatnoscInnePrawa> list { get; set; }

        public PlatnoscInnePrawaList(UserControl_PreviewViewModel userPrev )
        {
            using (Context c = new Context())
            {
                if(userPrev.dzialkaSel != null)
                    list = new ObservableCollection<PlatnoscInnePrawa>( c.PlatnoscInnePrawa.Where(r => r.DzialkaId == userPrev.dzialkaSel.DzialkaId));
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

        public void save()
        {
            foreach (var item in list)
            {
                if (item.PlatnoscInnePrawaId == 0)
                    AddRow(item);
                else
                {

                    var v = list.FirstOrDefault(r => r.DzialkaId == item.DzialkaId &&
                                                     r.PodmiotId == item.PodmiotId);
                    int a = 14;
                    if (v != null)
                    {
                        int b = 13;
                        if (v.Equals(item) == false)
                            ModRow(item);
                    }
                }
            }
        }
    }
}

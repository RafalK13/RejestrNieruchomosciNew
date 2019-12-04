using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfControlLibraryRaf;

namespace RejestrNieruchomosciNew.Model
{
    public class PodmiotList : IPodmiotList
    {
        public List<IPodmiot> list { get; set; }
        public List<WpfControlLibraryRaf.Podmiot> listView { get; set; }

        public PodmiotList()
        {
            initPodmiotList();
            listView = list.ConvertAll(r => new WpfControlLibraryRaf.Podmiot { id = r.PodmiotId, nazwa = r.Name });
        }

        private void initPodmiotList()
        {
            Task task = Task.Run(() => fillPodmiotListAsync());

            task.Wait();
        }

        private async Task fillPodmiotListAsync()
        {
            using (var c = new Context())
            {
                list = new List<IPodmiot>( await c.PodmiotView.ToListAsync());
                
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class PodmiotList : IPodmiotList
    {
        public List<IPodmiot> list { get; set; }

        public PodmiotList()
        {
            initPodmiotList();
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
                list = new List<IPodmiot>( await c.MK_REJNIER_PERSONS.ToListAsync());
            
            }
        }
    }
}

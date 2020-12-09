using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
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
                try
                {
                    list = new List<IPodmiot>(await c.PodmiotView.AsNoTracking().ToListAsync());
                }
                catch (Exception e)
                {
                    MessageBox.Show($"PodmiotList\r\n{e.Message}\r\n{e.Source}\r\n{e.StackTrace}");
                    Environment.Exit(0);
                }

            }
        }
    }
}

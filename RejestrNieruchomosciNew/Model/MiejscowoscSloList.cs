using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class MiejscowoscSloList : IMiejscowoscSloList
    {
        public ObservableCollection<IMiejscowoscSlo> listAll { get ; set; }
        public ObservableCollection<IMiejscowoscSlo> list { get; set; }

        public MiejscowoscSloList()
        {
            initMiejscowosciList();
        }

        private void initMiejscowosciList()
        {
            try
            {
                Task task = Task.Run(() => fillAdresList());
                task.Wait();
            }

            catch (Exception e)
            {
                MessageBox.Show($"MiejscowosciList\r\n{e.Message}");
                Environment.Exit(0);
            }
        }

        private async Task fillAdresList()
        {
            using (var c = new Context())
            {
                listAll = new ObservableCollection<IMiejscowoscSlo>(await c.MiejscowoscSlo.ToListAsync());
            }
        }

        private void initList(IDzialka dzialka)
        {
            if (dzialka != null)
                list = new ObservableCollection<IMiejscowoscSlo>(listAll.Where(r => r.GminaSloId == dzialka.Obreb.GminaSloId));
        }

        public void getList(IDzialka dzialkaSel)
        {
            initList(dzialkaSel);
        }
    }
}

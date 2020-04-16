using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class AdresList : IAdresList
    {
        public ObservableCollection<IAdres> listAll { get; set; }

        public AdresList()
        {
            initAdresList();
        }

        private void initAdresList()
        {
            try
            {
                Task task = Task.Run(() => fillAdresList());
                task.Wait();
            }
            catch (Exception e)
            {
                MessageBox.Show($"AdresList\r\n{e.Message}");
                Environment.Exit(0);
            }
        }

        private async Task fillAdresList()
        {
            using (var c = new Context())
            {
                listAll = new ObservableCollection<IAdres>(await c.Adres.ToListAsync());
            }
        }

        public IAdres getAdres(IDzialka dzialkaSel)
        {
            return listAll.FirstOrDefault(r => r.AdresId == dzialkaSel.AdresId);
        }

        public void save()
        {
        }
    }
}

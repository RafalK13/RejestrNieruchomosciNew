using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class DzialkaList : ViewModelBase, IDzialkaList
    {
        private List<IDzialka> _dzialkaList;
        public List<IDzialka> dzialkaList
        {
            get => _dzialkaList;
            set
            {
                _dzialkaList = value;
                RaisePropertyChanged("dzialkaList");
            }
        }

        public IObrebList obrebList { get; set; }

        private void initDzialkaList()
        {
            Task task = Task.Run(() => fillDzialkaList());
            task.Wait();
        }

        private async Task fillDzialkaList()
        {
            using (var c = new Context())
            {
                dzialkaList = new List<IDzialka>(await c.Dzialka.Include( a => a.Obreb).ThenInclude(a => a.GminaSlo).ToListAsync());
            }
        }

        public void deleteRow(IDzialka dz)
        {
            dzialkaList.Remove(dz);

            using (var c = new Context())
            {
                c.Dzialka.Remove((Dzialka)dz);
                c.SaveChanges();
            }
        }

        public void AddRow(IDzialka dz)
        {
            using (var c = new Context())
            {
                c.Dzialka.Add((Dzialka)dz);
                c.SaveChanges();
            }

            dz.Obreb = obrebList.obrebList.FirstOrDefault(r => r.ObrebId == dz.ObrebId);
            dzialkaList.Add(dz);
        }

        public DzialkaList()
        {
            initDzialkaList();
        }
    }
}

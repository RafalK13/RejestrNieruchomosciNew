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
        private List<IDzialka> _list;
        public List<IDzialka> list
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged("list");
            }
        }

        public IObrebList obrebList { get; set; }

        public DzialkaList()
        {
            initDzialkaList();
        }

        private void initDzialkaList()
        {
            Task task = Task.Run(() => fillDzialkaList());
            task.Wait();
        }

        private async Task fillDzialkaList()
        {
            using (var c = new Context())
            {
                list = new List<IDzialka>(await c.Dzialka.Include( a => a.Obreb).ThenInclude(a => a.GminaSlo)
                                                         .Include( r=> r.PlatnoscUW).ToListAsync());
            }
        }

        public void DelRow(IDzialka dz)
        {
            list.Remove(dz);

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
                int a = 13;
                c.Dzialka.Add((Dzialka)dz);
                c.SaveChanges();
            }
            
            dz.Obreb = obrebList.obrebList.FirstOrDefault(r => r.ObrebId == dz.ObrebId);
            list.Add(dz);
        }

        public void ModRow(IDzialka dz)
        {
            using (var c = new Context())
            {
                Dzialka d = (Dzialka)dz;

                d.PlatnoscUW = c.PlatnoscUW.FirstOrDefault(r => r.DzialkaId == dz.DzialkaId);
                
                c.Update( d);
                c.SaveChanges();
            }

            var v =list.FindIndex( r=>r.DzialkaId == dz.DzialkaId);
            dz.Obreb = obrebList.obrebList.FirstOrDefault(r => r.ObrebId == dz.ObrebId);
            list[v] = dz;

        }
    }
}


using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class DzialkaList : ViewModelBase, IDzialkaList
    {
        public event EventHandler zmianaDzialkiList;
        private List<IDzialka> _list;
        public List<IDzialka> list
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged();
            }
        }

        public IObrebList obrebList { get; set; }

        public DzialkaList()
        {
            initDzialkaList();
        }

        private void initDzialkaList()
        {
            try
            {

                MessageBox.Show("DzialkaList");
                Task task = Task.Run(() => fillDzialkaList());
                task.Wait();
            }
            catch (Exception e)
            {
                MessageBox.Show( $"DzialkaList\r\n{e.Message}");
                Environment.Exit(0);
            }
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
                var r1 = c.Dzialka_Budynek.Where(n => n.DzialkaId == dz.DzialkaId);
                foreach (var item in r1)
                {
                    if (c.Budynek.Where(r2 => r2.BudynekId == item.BudynekId).Count() == 1)
                    {
                        try
                        {
                            c.Budynek.Remove(c.Budynek.FirstOrDefault(d => d.BudynekId == item.BudynekId));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
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
            list.Add(dz);
        }

        public void ModRow(IDzialka dz)
        {
            try
            {
                using (var c = new Context())
                {
                    Dzialka d = (Dzialka)dz;

                    d.PlatnoscUW = c.PlatnoscUW.FirstOrDefault(r => r.DzialkaId == dz.DzialkaId);

                    var v1 = c.Dzialka.First(r => r.DzialkaId == d.DzialkaId);
                    c.Entry(v1).CurrentValues.SetValues(d);
                    c.SaveChanges();
                }

                var v = list.FindIndex(r => r.DzialkaId == dz.DzialkaId);
                dz.Obreb = obrebList.obrebList.FirstOrDefault(r => r.ObrebId == dz.ObrebId);
                //list[v] = (IDzialka)dz.clone();

                list[v].copy(dz);

                if (zmianaDzialkiList != null)
                    zmianaDzialkiList(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show( $"Błąd modyfikacji działki\r\n{ex.Message}\r\n{ex.Source}");
            }
        }
    }
}

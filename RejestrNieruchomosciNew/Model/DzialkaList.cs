
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

        public void UpdateList()
        {
            initDzialkaList();
        }        

        private void initDzialkaList()
        {
            try
            {
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
                list = new List<IDzialka>(await c.Dzialka.Take(13).Include(a => a.Obreb).ThenInclude(a => a.GminaSlo)
                                                         .Include(r => r.PlatnoscUW)
                                                         .Include(adr => adr.Adres)
                                                         .Include(w => w.Wladanie).ThenInclude(f => f.FormaWladaniaSlo)
                                                         .Include(w => w.Wladanie).ThenInclude(t => t.TransakcjeK_Wlad)
                                                         .Include(o => o.DzialkaOchrona)
                                                         .ToListAsync());          
            }
        }

        public void DelRow(IDzialka dz)
        {
            list.Remove(dz);
           
            using (var c = new Context())
            {
                ICollection<Dzialka_Budynek> tab;
                Dzialka d = dz as Dzialka;
                if (d.Dzialka_Budynek != null)
                     tab = d.Dzialka_Budynek;
                else
                    tab = c.Dzialka_Budynek.AsNoTracking().Include(b=>b.Budynek).AsNoTracking()
                                                         .Where(n => n.DzialkaId == dz.DzialkaId).ToList();

                foreach (var item in tab)
                {
                   var budTodel = item.Budynek;
                    try
                    {
                        c.Budynek.Remove(item.Budynek);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
                dz.Obreb = null;
                dz.Adres= (Adres)dz.Adres.testAdres();
               
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

                    var v1 = c.Dzialka.First(r => r.DzialkaId == d.DzialkaId);
                    c.Entry(v1).CurrentValues.SetValues(d);
                    c.SaveChanges();

                    var v = list.FindIndex(r => r.DzialkaId == dz.DzialkaId);

                    list[v] = c.Dzialka.Include(a => a.Obreb).ThenInclude(a => a.GminaSlo)
                                                             .Include(r => r.PlatnoscUW)
                                                             .Include(adr => adr.Adres)
                                                             .FirstOrDefault(i => i.DzialkaId == d.DzialkaId);


                    //if(list[v].Adres != null)
                    //    list[v].Adres.DzialkaId = dz.DzialkaId;

                    //list[v].Obreb = obrebList.obrebList.FirstOrDefault(r => r.ObrebId == dz.ObrebId);
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show( $"Błąd modyfikacji działki\r\n{ex.Message}\r\n{ex.Source}");
            }
        }


    }
}

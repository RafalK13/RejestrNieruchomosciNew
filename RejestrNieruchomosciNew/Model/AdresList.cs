using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using XAct;

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
                listAll = new ObservableCollection<IAdres>(await c.Adres
                                                                  .Include(m => m.MiejscowoscSlo)
                                                                  .Include(u => u.UlicaSlo)
                                                                  .ToListAsync());
            }
        }

        //public IAdres getAdres(IDzialka dzialkaSel)
        //{
        //    return null;// listAll.FirstOrDefault(r => r.AdresId == dzialkaSel.AdresId);
        //}

        public void save(IAdres adr)
        {
            using (var c = new Context())
            {

                c.Update(adr);
                c.SaveChanges();
                //var a = c.Adres.FirstOrDefault(r => r.AdresId == adr.AdresId);

                //if (a == null)
                //    AddRow(adr);
                //else
                //    ModRow(adr);
            }
        }

        public void DelRow(IAdres adr)
        {
            listAll.Remove(adr);
            using (var c = new Context())
            {
                c.Adres.Remove((Adres)adr);
                c.SaveChanges();
            }
        }

        public void AddRow(IAdres adr)
        {
            using (var c = new Context())
            {
                c.Adres.Add((Adres)adr);
                c.SaveChanges();
            }
            listAll.Add(adr);
        }

        public void ModRow(IAdres adr)
        {
            try
            {
                using (var c = new Context())
                {
                   var a = c.Adres.First(r => r.AdresId == adr.AdresId);
                    c.Entry(a).CurrentValues.SetValues(adr);
                    c.SaveChanges();
                }

                var v = listAll.IndexOf(r => r.AdresId == adr.AdresId);
                listAll[v].copy(adr);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd modyfikacji działki\r\n{ex.Message}\r\n{ex.Source}");
            }
        }
    }
}

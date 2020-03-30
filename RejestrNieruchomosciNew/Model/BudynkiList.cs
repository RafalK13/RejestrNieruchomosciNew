using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class BudynkiList : ViewModelBase, IBudynkiList
    {
        public ObservableCollection<IBudynek> listAll { get; set; }

        private ObservableCollection<IBudynek> _list;
        public ObservableCollection<IBudynek> list
        {
            get => _list; set
            {
                _list = value;
                RaisePropertyChanged();
            }
        }

        private List<IBudynek> listOrg { get; set; }
        private List<IBudynek> listToAdd { get; set; }
        private List<IBudynek> listToMod { get; set; }
        private List<IBudynek> listToDel { get; set; }

        public string result;
        private IDzialka dzialkaPrv;

        public void initListAll()
        {
            using (Context c = new Context())
            {
                try
                {
                    listAll = new ObservableCollection<IBudynek>(c.Budynek.Include(f => f.Dzialka_Budynek));
                }
                catch (Exception e)
                {
                    MessageBox.Show($"BudynekList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }

        private void initList(IDzialka dzialka)
        {
            if (dzialka != null)
                list = new ObservableCollection<IBudynek>( listAll.Where(r => r.Dzialka_Budynek.FirstOrDefault(n => n.DzialkaId == dzialka.DzialkaId) != null).ToList());

            listOrg = ObservableCon<IBudynek>.ObservableToList(list);
            listToAdd = new List<IBudynek>();
            listToMod = new List<IBudynek>();
            listToDel = new List<IBudynek>();
            result = string.Empty;
        }

        public BudynkiList()
        {
            list = new ObservableCollection<IBudynek>();
        }

        public BudynkiList(UserControl_PreviewViewModel userPrev)
        {
         
            list = new ObservableCollection<IBudynek>();
            if (userPrev.dzialkaSel != null)
                initListAll();
        }

        public void getList(IDzialka dzialkaSel)
        {
            dzialkaPrv = dzialkaSel;
            int r1 = 1;
            initList(dzialkaSel);
            int r2 = 2;
        }

        public void saveBudynki()
        {
            int r1 = 13;
            foreach (var r in list)
            {
                if (listOrg.Contains(r))
                    listOrg.Remove(r);
                else
                {
                    if (listOrg.Exists(row => row.BudynekId == r.BudynekId) == true)
                    {
                        listToMod.Add((IBudynek)r.Clone());
                        var rToDel = listOrg.Find(d => d.BudynekId == r.BudynekId);
                        listOrg.Remove(rToDel);
                    }
                    else
                    {
                        listToAdd.Add((IBudynek)r.Clone());
                    }
                }
            }
            foreach (var row in listOrg)
            {
                listToDel.Add(row);
            }

            if (listToDel.Count() > 0)
                DelRows();

            if (listToAdd.Count() > 0)
                AddRows();

            if (listToMod.Count() > 0)
                ModRows();

            initListAll();
            initList(dzialkaPrv);
        }

        public void AddRows()
        {
            using (var c = new Context())
            {
                foreach (var i in listToAdd)
                {
                    c.Dzialka_Budynek.Add(new Dzialka_Budynek() { DzialkaId = dzialkaPrv.DzialkaId, Budynek = (Budynek)i });
                    //c.Budynek.Add((Budynek)i);
                }
                c.SaveChanges();
            }
        }

        public void ModRows()
        {
            using (var c = new Context())
            {
                foreach (var i in listToMod)
                {
                    var v = c.Budynek.First(r => r.BudynekId == i.BudynekId);
                    c.Entry(v).CurrentValues.SetValues(i);
                }
                c.SaveChanges();
            }
        }

        public void DelRows()
        {
            using (var c = new Context())
            {
                foreach (var i in listToDel)
                {
                    var v = c.Budynek.First(r => r.BudynekId == i.BudynekId);

                    c.Budynek.Remove(v);
                }
                c.SaveChanges();
            }
        }
    }
}
using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
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
        public ObservableCollection<IDzialka> listAll { get; set; }

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

        private void initList(IBudynek dzialka)
        {
            int rr = 1;

            if (dzialka != null)
                list = new ObservableCollection<IBudynek>(listAll.Where(r => r.DzialkaId == dzialka.DzialkaId).ToList());

            listOrg = ObservableCon<IBudynek>.ObservableToList(list);

            listToAdd = new List<IWladanie>();
            listToMod = new List<IWladanie>();
            listToDel = new List<IWladanie>();
            result = string.Empty;
        }

        public WladanieList()
        {
            int r = 1;
            //MessageBox.Show("1");

            list = new ObservableCollection<IWladanie>();

        }

        public WladanieList(UserControl_PreviewViewModel userPrev)
        {
            int r = 2;
            //MessageBox.Show("2");

            list = new ObservableCollection<IWladanie>();
            if (userPrev.dzialkaSel != null)
                initListAll();
        }

        public void getList(IDzialka dzialkaSel)
        {
            int r = -13;
            dzialkaPrv = dzialkaSel;

            initList(dzialkaPrv);
        }

        public void saveWladanie()
        {
            foreach (var r in list)
            {
                if (listOrg.Contains(r))
                    listOrg.Remove(r);
                else
                {
                    if (listOrg.Exists(row => row.WladanieId == r.WladanieId) == true)
                    {
                        listToMod.Add((IWladanie)r.Clone());
                        var rToDel = listOrg.Find(d => d.WladanieId == r.WladanieId);
                        listOrg.Remove(rToDel);
                    }
                    else
                    {
                        listToAdd.Add((IWladanie)r.Clone());
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
                    c.Wladanie.Add((Wladanie)i);
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
                    if (i.TransK_Id == 0)
                        i.TransK_Id = null;
                    var v = c.Wladanie.First(r => r.WladanieId == i.WladanieId);
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
                    var v = c.Wladanie.First(r => r.WladanieId == i.WladanieId);

                    RemaneDirs(v);

                    c.Wladanie.Remove(v);
                }
                c.SaveChanges();
            }
        }

        private void RemaneDirs(Wladanie w)
        {
            if (Directory.Exists(w.ZalPath))
            {
                Directory.Move(w.ZalPath, w.ZalPathOld);
            }
        }
    }
}
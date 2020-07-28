using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;

namespace RejestrNieruchomosciNew.Model
{
    public class Dzialka_BudynekList : ViewModelBase,  IDzialka_BudynekList
    {
        public ObservableCollection<IDzialka_Budynek> listAll { get; set; }

        private ObservableCollection<IDzialka_Budynek> _list;
        public ObservableCollection<IDzialka_Budynek> list
        {
            get => _list; set
            {
                _list = value;
                RaisePropertyChanged();
            }
        }

        private List<IDzialka_Budynek> listOrg { get; set; }
        private List<IDzialka_Budynek> listToAdd { get; set; }
        private List<IDzialka_Budynek> listToMod { get; set; }
        private List<IDzialka_Budynek> listToDel { get; set; }

        public string result;
        private IDzialka dzialkaPrv;

        public void initListAll()
        {
            //using (Context c = new Context())
            //{
            //    try
            //    {
            //        listAll = new ObservableCollection<IDzialka_Budynek>(c.Dzialka_Budynek.Include(n1 => n1.Budynek)
            //                                                                              .Include(n2 => n2.Dzialka));
            //    }
            //    catch (Exception e)
            //    {
            //        MessageBox.Show($"Dzialka_BudynekList\r\n{e.Message}");
            //        Environment.Exit(0);
            //    }
            //}
        }

        private void initList(IDzialka dzialka)
        {
        //    if (dzialka != null)
        //        list = new ObservableCollection<IDzialka_Budynek>(listAll.Where(r => r.DzialkaId == dzialka.DzialkaId).ToList());

        //    listOrg = ObservableCon<IDzialka_Budynek>.ObservableToList(list);

        //    listToAdd = new List<IDzialka_Budynek>();
        //    listToMod = new List<IDzialka_Budynek>();
        //    listToDel = new List<IDzialka_Budynek>();
        //    result = string.Empty;
        }

        public Dzialka_BudynekList()
        {
            list = new ObservableCollection<IDzialka_Budynek>();
        }

        public Dzialka_BudynekList(UserControl_PreviewViewModel userPrev)
        {

            list = new ObservableCollection<IDzialka_Budynek>();
            if (userPrev.dzialkaSel != null)
                initListAll();
        }

        public void getList(IDzialka dzialkaSel)
        {
            dzialkaPrv = dzialkaSel;

            initList(dzialkaPrv);
        }

        public void save()
        {

            int r13 = 13;
            foreach (var r in list)
            {
                if (listOrg.Contains(r))
                    listOrg.Remove(r);
                else
                {
                    if (listOrg.Exists(row => (row.BudynekId == r.BudynekId)
                                           && (row.DzialkaId == r.DzialkaId))== true)
                    {
                        listToMod.Add((IDzialka_Budynek)r.Clone());
                        var rToDel = listOrg.Find(row => (row.BudynekId == r.BudynekId)
                                              && (row.DzialkaId == r.DzialkaId));
                        listOrg.Remove(rToDel);
                    }
                    else
                    {
                        listToAdd.Add((IDzialka_Budynek)r.Clone());
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
                    c.Dzialka_Budynek.Add((Dzialka_Budynek)i);
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
                    var v = c.Dzialka_Budynek.First(r => (r.DzialkaId == i.DzialkaId) 
                                                      && (r.BudynekId == r.BudynekId));
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
                    var v = c.Dzialka_Budynek.First(r => (r.DzialkaId == i.DzialkaId)
                                                       && (r.BudynekId == i.BudynekId)); 

                    //RemaneDirs(v);

                    c.Dzialka_Budynek.Remove(v);
                }
                c.SaveChanges();
            }
        }

        //private void RemaneDirs(Wladanie w)
        //{
        //    if (Directory.Exists(w.ZalPath))
        //    {
        //        Directory.Move(w.ZalPath, w.ZalPathOld);
        //    }
        //}
    }
}
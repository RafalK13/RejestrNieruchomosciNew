using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class WladanieList : ViewModelBase, IWladanieList
    {
        public ObservableCollection<IWladanie> listAll { get; set; }

        private ObservableCollection<IWladanie> _list;
        public ObservableCollection<IWladanie> list
        {
            get => _list; set
            {
                _list = value;
                RaisePropertyChanged();
            }
        }

        private List<IWladanie> listOrg { get; set; }
        private List<IWladanie> listToAdd { get; set; }
        private List<IWladanie> listToMod { get; set; }
        private List<IWladanie> listToDel { get; set; }

        public string result;
        private IDzialka dzialkaPrv;

        public void initListAll()
        {
            using (Context c = new Context())
            {
                listAll = new ObservableCollection<IWladanie>(c.Wladanie.Include(f => f.FormaWladaniaSlo)
                                                                        .Include(t => t.TransakcjeK_Wlad));
               
                #region Old version
                //list = new ObservableCollection<IWladanie>(c.Wladanie.Where(r => r.DzialkaId == userPrev.dzialkaSel.DzialkaId
                //                                                                                      && r.TransS_Id == null)
                //                                                            );
                //listOrg = ObservableCon<IWladanie>.ObservableToList(list);

                //listToAdd = new List<IWladanie>();
                //listToMod = new List<IWladanie>();
                //listToDel = new List<IWladanie>();
                //result = string.Empty;
                #endregion
            }
        }

        private void initList(IDzialka dzialka)
        {
            int rr = 1;

            if (dzialka != null)
                list = new ObservableCollection<IWladanie>(listAll.Where(r => r.DzialkaId == dzialka.DzialkaId
                                                                                     && r.TransS_Id == null).ToList());

            listOrg = ObservableCon<IWladanie>.ObservableToList(list);

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
            //initListAll();
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
            int r =-13;
            dzialkaPrv = dzialkaSel;

            initList(dzialkaPrv);
        }

        public void saveWladanie( )
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

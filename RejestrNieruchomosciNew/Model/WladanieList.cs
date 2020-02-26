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
        public ObservableCollection<IWladanie> list { get; set; }

        private List<IWladanie> listOrg { get; set; }
        private List<IWladanie> listToAdd { get; set; }
        private List<IWladanie> listToMod { get; set; }
        private List<IWladanie> listToDel { get; set; }
        
        public string result;

        public WladanieList(UserControl_PreviewViewModel userPrev)
        {
            using (Context c = new Context())
            {
                if (userPrev.dzialkaSel != null)
                {
                    list = new ObservableCollection<IWladanie>(c.Wladanie.Where(r => r.DzialkaId == userPrev.dzialkaSel.DzialkaId
                                                                                                          && r.TransS_Id == null)
                                                                                     );
                    listOrg = ObservableCon<IWladanie>.ObservableToList(list);

                    listToAdd = new List<IWladanie>();
                    listToMod = new List<IWladanie>();
                    listToDel = new List<IWladanie>();
                    result = string.Empty;
                }
            }
        }

        public void getList(IDzialka dzialkaSel)
        {
            using (Context c = new Context())
            {
                if (dzialkaSel != null)
                {
                    list = new ObservableCollection<IWladanie>(c.Wladanie.Where(r => r.DzialkaId == dzialkaSel.DzialkaId
                                                                                                 && r.TransS_Id == null)
                                                                                                 
                                                                         .Include(f=>f.FormaWladaniaSlo));
                }
            }
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

        private void RemaneDirs( Wladanie w)
        {
            if (Directory.Exists(w.ZalPath))
            {
                Directory.Move(w.ZalPath, w.ZalPathOld);
            }
        }
    }
}

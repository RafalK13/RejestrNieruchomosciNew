using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;

namespace RejestrNieruchomosciNew.Model
{
    public class InnePrawaList : IInnePrawaList
    {
        public ObservableCollection<IInnePrawa> list { get; set; }
        private List<IInnePrawa> listOrg { get; set; }
        private List<IInnePrawa> listToAdd { get; set; }
        private List<IInnePrawa> listToMod { get; set; }
        private List<IInnePrawa> listToDel { get; set; }

        public string result;

        public InnePrawaList(UserControl_PreviewViewModel userPrev)
        {
            using (Context c = new Context())
            {
                if (userPrev.dzialkaSel != null)
                {
                    list = new ObservableCollection<IInnePrawa>(c.InnePrawa.Where(r => r.DzialkaId == userPrev.dzialkaSel.DzialkaId
                                                                                                          && r.TransS_Id == null).
                                                                                                          Include(a=>a.PlatnoscInnePrawa));
                    listOrg = ObservableCon<IInnePrawa>.ObservableToList(list);

                    listToAdd = new List<IInnePrawa>();
                    listToMod = new List<IInnePrawa>();
                    listToDel = new List<IInnePrawa>();

                    result = string.Empty;
                }
            }
        }

        public void save()
        {
            foreach (var r in list)
            {
                if (listOrg.Contains(r))
                    listOrg.Remove(r);
                else
                {
                    if (listOrg.Exists(row => row.InnePrawaId == r.InnePrawaId) == true)
                    {
                        listToMod.Add((IInnePrawa)r.Clone());
                        var rToDel = listOrg.Find(d => d.InnePrawaId == r.InnePrawaId);
                        listOrg.Remove(rToDel);
                    }
                    //if (listOrg.Exists(row => (row.PodmiotId == r.PodmiotId) && (row.DzialkaId == r.DzialkaId)) == true)
                    //{
                    //    listToMod.Add((IInnePrawa)r.Clone());
                    //    //var rToDel = listOrg.Find(d => d.InnePrawaId == r.InnePrawaId);
                    //    var rToDel = listOrg.Find(d => (d.DzialkaId == r.DzialkaId) && ( d.PodmiotId == r.PodmiotId));
                    //    listOrg.Remove(rToDel);
                    //}

                    else
                    {
                        listToAdd.Add((IInnePrawa)r.Clone());
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
                    int a = 13;
                    c.InnePrawa.Add((InnePrawa)i);
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
                    var v = c.InnePrawa.First(r => r.InnePrawaId == i.InnePrawaId);
                    c.Entry(v).CurrentValues.SetValues(i);

                    var v1 = c.PlatnoscInnePrawa.First(r => r.PlatnoscInnePrawaId == i.PlatnoscInnePrawa.PlatnoscInnePrawaId);
                    c.Entry(v1).CurrentValues.SetValues(i.PlatnoscInnePrawa);

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
                    var v = c.InnePrawa.First(r => r.InnePrawaId == i.InnePrawaId);

                    RemaneDirs( v);
                    //var v = c.InnePrawa.First(r => (r.DzialkaId == i.DzialkaId) && (r.PodmiotId==i.PodmiotId));
                    c.InnePrawa.Remove(v);
                }
                c.SaveChanges();
            }
        }

        private void RemaneDirs(InnePrawa w)
        {
            if (Directory.Exists(w.ProtPrzejPath))
            {
                Directory.Move(w.ProtPrzejPath, w.ProtPrzejPathOld);
                //Directory.Move(w.ProtZwrotPath, w.ProtZwrotPathOld);
            }
        }
    }
}

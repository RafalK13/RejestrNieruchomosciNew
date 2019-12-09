using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
                                                                                                          && r.TransS_Id == null));

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
                    c.InnePrawa.Remove(v);
                }
                c.SaveChanges();
            }
        }
    }
}

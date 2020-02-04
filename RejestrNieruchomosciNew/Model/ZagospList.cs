using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospList : IZagospList
    {
        public ObservableCollection<IZagosp> list { get; set; }
        private List<IZagosp> listOrg { get; set; }
        private List<IZagosp> listToAdd { get; set; }
        private List<IZagosp> listToMod { get; set; }
        private List<IZagosp> listToDel { get; set; }

        public string result;

        public ZagospList(UserControl_PreviewViewModel userPrev)
        {
            using ( var c = new Context())
            {
                list = new ObservableCollection<IZagosp>( c.Zagosp.Where( r => r.DzialkaId == userPrev.dzialkaSel.DzialkaId));

                listOrg = ObservableCon<IZagosp>.ObservableToList(list);

                listToAdd = new List<IZagosp>();
                listToMod = new List<IZagosp>();
                listToDel = new List<IZagosp>();

                result = string.Empty;
            }
        }

        public void saveZagosp()
        {
            foreach (var r in list)
            {
                if (listOrg.Contains(r))
                    listOrg.Remove(r);
                else
                {
                    if (listOrg.Exists(row => row.ZagospId == r.ZagospId) == true)
                    {
                        listToMod.Add((IZagosp)r.Clone());
                        var rToDel = listOrg.Find(d => d.ZagospId == r.ZagospId);
                        listOrg.Remove(rToDel);
                    }
                    else
                    {
                        listToAdd.Add((IZagosp)r.Clone());
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
                    c.Zagosp.Add((Zagosp)i);
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
                    var v = c.Zagosp.First(r => r.ZagospId == i.ZagospId);
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
                    var v = c.Zagosp.First(r => r.ZagospId == i.ZagospId);

                    c.Zagosp.Remove(v);
                }
                c.SaveChanges();
            }
        }
    }
}

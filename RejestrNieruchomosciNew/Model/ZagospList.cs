using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;

namespace RejestrNieruchomosciNew.Model
{
    public class ZagospList : ViewModelBase,  IZagospList
    {
        public ObservableCollection<IZagosp> listAll { get; set; }

        private ObservableCollection<IZagosp> _list;
        public ObservableCollection<IZagosp> list
        {
            get => _list; set
            {
                _list = value;
                RaisePropertyChanged();
            }
        }

        private List<IZagosp> listOrg { get; set; }
        private List<IZagosp> listToAdd { get; set; }
        private List<IZagosp> listToMod { get; set; }
        private List<IZagosp> listToDel { get; set; }

        public string result;
        private IDzialka dzialkaPrv;

        public void initListAll()
        {
            using (Context c = new Context())
            {
                try
                {
                    listAll = new ObservableCollection<IZagosp>(c.Zagosp);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"ZagospodatowanieList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }

        private void initList(IDzialka dzialka)
        {
            if (dzialka != null)
                list = new ObservableCollection<IZagosp>(listAll.Where(r => r.DzialkaId == dzialka.DzialkaId).ToList());

            listOrg = ObservableCon<IZagosp>.ObservableToList(list);

            listToAdd = new List<IZagosp>();
            listToMod = new List<IZagosp>();
            listToDel = new List<IZagosp>();
            result = string.Empty;
        }

        public ZagospList()
        {
            list = new ObservableCollection<IZagosp>();
        }

        public ZagospList(UserControl_PreviewViewModel userPrev)
        {
           
            list = new ObservableCollection<IZagosp>();
            if (userPrev.dzialkaSel != null)
                initListAll();
        }

        public void getList(IDzialka dzialkaSel)
        {
            dzialkaPrv = dzialkaSel;

            initList(dzialkaPrv);
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

            initListAll();
            initList(dzialkaPrv);
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
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
        
        public string result;
        private IDzialka dzialkaPrv;

        public void initListAll()
        {
            using (Context c = new Context())
            {
                try
                {
                    listAll = new ObservableCollection<IZagosp>(c.Zagosp
                                                                 .Include( s=>s.ZagospStatus));
                }
                catch (Exception e)
                {
                    MessageBox.Show($"ZagospodarowanieList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }

        private void initList(IDzialka dzialka)
        {
            if (dzialka != null)
                list = new ObservableCollection<IZagosp>(listAll.Where(r => r.DzialkaId == dzialka.DzialkaId).ToList());

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

        public void saveZagosp(Zagosp zagospLok)
        {
            int y = 1;
            zagospLok.ZagospStatus = null;
            using (var c = new Context())
            {
                c.Update(zagospLok);
                int result = c.SaveChanges();
            }
        }

        #region Old Version
        //public void saveZagosp(IDzialka dz)
        //{
        //    using (var c = new Context())
        //    {
        //        var zagospAll = c.Zagosp.AsNoTracking().Where(r => r.DzialkaId == dz.DzialkaId).ToList();

        //        foreach (var item in zagospAll)
        //        {
        //            var toDel = list.FirstOrDefault(r=>r.ZagospId == item.ZagospId);
        //            if (toDel == null)
        //                c.Remove(item);
        //        }

        //        c.UpdateRange(list);

        //        c.SaveChanges();
        //        initListAll();

        //    }

        //    using (var c = new Context())
        //    {
        //        c.Update(dz);

        //        c.SaveChanges();
        //    }
        //    #region to delete
        //    //foreach (var r in list)
        //    //{
        //    //    if (listOrg.Contains(r))
        //    //        listOrg.Remove(r);
        //    //    else
        //    //    {
        //    //        if (listOrg.Exists(row => row.ZagospId == r.ZagospId) == true)
        //    //        {
        //    //            listToMod.Add((IZagosp)r.Clone());
        //    //            var rToDel = listOrg.Find(d => d.ZagospId == r.ZagospId);
        //    //            listOrg.Remove(rToDel);
        //    //        }
        //    //        else
        //    //        {
        //    //            listToAdd.Add((IZagosp)r.Clone());
        //    //        }
        //    //    }
        //    //}
        //    //foreach (var row in listOrg)
        //    //{
        //    //    listToDel.Add(row);
        //    //}

        //    //if (listToDel.Count() > 0)
        //    //    DelRows();

        //    //if (listToAdd.Count() > 0)
        //    //    AddRows();

        //    //if (listToMod.Count() > 0)
        //    //    ModRows();

        //    //initListAll();
        //    //initList(dzialkaPrv);
        //    #endregion
        //}
        #endregion

        #region Old version
        //public void AddRows()
        //{
        //    using (var c = new Context())
        //    {
        //        foreach (var i in listToAdd)
        //        {
        //            c.Zagosp.Add((Zagosp)i);
        //        }
        //        c.SaveChanges();
        //    }
        //}

        //public void ModRows()
        //{
        //    using (var c = new Context())
        //    {
        //        foreach (var i in listToMod)
        //        {
        //            var v = c.Zagosp.First(r => r.ZagospId == i.ZagospId);
        //            c.Entry(v).CurrentValues.SetValues(i);
        //        }
        //        c.SaveChanges();
        //    }
        //}

        //public void DelRows()
        //{
        //    using (var c = new Context())
        //    {
        //        foreach (var i in listToDel)
        //        {
        //            var v = c.Zagosp.First(r => r.ZagospId == i.ZagospId);

        //            c.Zagosp.Remove(v);
        //        }
        //        c.SaveChanges();
        //    }
        //}
        #endregion
    }
}

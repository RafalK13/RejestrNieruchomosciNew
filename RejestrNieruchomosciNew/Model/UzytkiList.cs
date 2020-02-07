﻿using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class UzytkiList : IUzytkiList
    {
        public ObservableCollection<Uzytki> list { get; set; }
        private List<Uzytki> listOrg { get; set; }
        private List<Uzytki> listToAdd { get; set; }
        private List<Uzytki> listToMod { get; set; }
        private List<Uzytki> listToDel { get; set; }

        public string result;

        public UzytkiList(UserControl_PreviewViewModel userPrev)
        {
            using (Context c = new Context())
            {
                if (userPrev.dzialkaSel != null)
                {
                    list = new ObservableCollection<Uzytki>( c.Uzytki.Where(r => r.DzialkaId == userPrev.dzialkaSel.DzialkaId));
                    listOrg = ObservableCon<Uzytki>.ObservableToList(list);

                    listToAdd = new List<Uzytki>();
                    listToMod = new List<Uzytki>();
                    listToDel = new List<Uzytki>();

                    result = string.Empty;
                }   
            }
        }

        public void saveUzytki()
        {
            foreach (var r in list)
            {
                if (listOrg.Contains(r))
                    listOrg.Remove(r);
                else
                {
                    if (listOrg.Exists(row => row.UzytkiId == r.UzytkiId) == true)
                    {
                        listToMod.Add((Uzytki)r.Clone());
                        var rToDel = listOrg.Find(d => d.UzytkiId == r.UzytkiId);
                        listOrg.Remove(rToDel);
                    }
                    else
                    {
                        listToAdd.Add((Uzytki)r.Clone());
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
                    c.Uzytki.Add(i);
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
                    var v = c.Uzytki.First(r => r.UzytkiId == i.UzytkiId);
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
                    var v = c.Uzytki.First(r => r.UzytkiId == i.UzytkiId);

                    c.Uzytki.Remove(v);
                }
                c.SaveChanges();
            }
        }
    }
}

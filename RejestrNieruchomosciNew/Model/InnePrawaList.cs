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
    public class InnePrawaList : ViewModelBase, IInnePrawaList
    {
        public ObservableCollection<IInnePrawa> listAll { get; set; }

        private ObservableCollection<IInnePrawa> _list;
        public ObservableCollection<IInnePrawa> list
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged();
            }
        }

        private List<IInnePrawa> listOrg { get; set; }
        private List<IInnePrawa> listToAdd { get; set; }
        private List<IInnePrawa> listToMod { get; set; }
        private List<IInnePrawa> listToDel { get; set; }

        public string result;
        private IDzialka dzialkaPrv;

        public void initListAll()
        {
            using (Context c = new Context())
            {
                try
                {
                    listAll = new ObservableCollection<IInnePrawa>(c.InnePrawa.Include(a => a.RodzajInnegoPrawaSlo)
                                                                              .Include(t => t.TransakcjeK_InnePr).ThenInclude(l1 => l1.NazwaCzynnosciSlo)
                                                                              .Include(t => t.TransakcjeK_InnePr).ThenInclude(l1 => l1.RodzajDokumentuSlo)
                                                                              .Include(i => i.PlatnoscInnePrawa)
                                                                              .Include(d => d.DecyzjeAdministracyjne)                                                                             
                                                                              );
                }
                catch (Exception e)
                {
                    MessageBox.Show($"InnePrawaList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }

        private void initList(IDzialka dzialka)
        {            
            if (dzialka != null)
                list = new ObservableCollection<IInnePrawa>(listAll.Where(r => r.DzialkaId == dzialka.DzialkaId
                                                                            && r.TransS_Id == null).ToList());

            listOrg = ObservableCon<IInnePrawa>.ObservableToList(list);

            listToAdd = new List<IInnePrawa>();
            listToMod = new List<IInnePrawa>();
            listToDel = new List<IInnePrawa>();
            result = string.Empty;
        }

        public InnePrawaList()
        {
            //MessageBox.Show("KONSTRUKTOR InnePrawaList");
            list = new ObservableCollection<IInnePrawa>();
            initListAll();
        }

        public void getList(IDzialka dzialkaSel)
        {
            dzialkaPrv = dzialkaSel;

            initList(dzialkaPrv);
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

            initListAll();
            initList(dzialkaPrv);

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
                    if (i.TransK_Id == 0)
                        i.TransK_Id = null;

                    var v = c.InnePrawa.First(r => r.InnePrawaId == i.InnePrawaId);
                    c.Entry(v).CurrentValues.SetValues(i);

                    //if (i.PlatnoscInnePrawa != null)
                    {
                        var v1 = c.PlatnoscInnePrawa.First(r => r.PlatnoscInnePrawaId == i.PlatnoscInnePrawa.PlatnoscInnePrawaId);
                        c.Entry(v1).CurrentValues.SetValues(i.PlatnoscInnePrawa);
                    }

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
            }
        }
    }
}

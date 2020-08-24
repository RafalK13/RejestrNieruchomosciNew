using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class BudynkiList : ViewModelBase, IBudynkiList
    {
        public ObservableCollection<IBudynek> listAll { get; set; }

        private ObservableCollection<IBudynek> _list;
        public ObservableCollection<IBudynek> list
        {
            get => _list; set
            {
                _list = value;
                RaisePropertyChanged();
            }
        }

        private List<IBudynek> listOrg { get; set; }
        private List<IBudynek> listToAdd { get; set; }
        private List<IBudynek> listToMod { get; set; }
        private List<IBudynek> listToDel { get; set; }

        public string result;
        private IDzialka dzialkaPrv;

        public void initListAll()
        {
            using (Context c = new Context())
            {
                try
                {
                    listAll = new ObservableCollection<IBudynek>(c.Budynek.AsNoTracking().Include(f => f.Dzialka_Budynek).ThenInclude(d => d.Dzialka)
                                                                          .Include(a => a.Adres));
                }
                catch (Exception e)
                {
                    MessageBox.Show($"BudynekList\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }

        private void initList(IDzialka dzialka)
        {
            if (dzialka != null)
                list = new ObservableCollection<IBudynek>(listAll.Where(r => r.Dzialka_Budynek.FirstOrDefault(n => n.DzialkaId == dzialka.DzialkaId) != null).ToList());

            //int a = 1;
            //listOrg = ObservableCon<IBudynek>.ObservableToList(list);
            //listToAdd = new List<IBudynek>();
            //listToMod = new List<IBudynek>();
            //listToDel = new List<IBudynek>();
            result = string.Empty;

        }

        public BudynkiList()
        {
            list = new ObservableCollection<IBudynek>();
        }

        public BudynkiList(UserControl_PreviewViewModel userPrev)
        {

            list = new ObservableCollection<IBudynek>();
            if (userPrev.dzialkaSel != null)
                initListAll();
        }

        public void getList(IDzialka dzialkaSel)
        {
            dzialkaPrv = dzialkaSel;
            initList(dzialkaSel);
        }

        public void saveBudynki()
        {
            using (var c = new Context())
            {
                //int ddd = 13;
                int dz = dzialkaPrv.DzialkaId;
                var budAll = c.Budynek.AsNoTracking().Where(r => r.Dzialka_Budynek.FirstOrDefault(l1 => l1.DzialkaId == dz) != null).ToList();

                foreach (var itemA in budAll)
                {
                    var result = list.FirstOrDefault(r => r.BudynekId == itemA.BudynekId);
                    if (result == null)
                        c.Budynek.Remove(itemA);
                }
                
                foreach (var item in list)
                {
                    if (item.Adres != null)
                    {
                        if (item.Adres.MiejscowoscSloId == 0)
                        {
                            var adr = c.Adres.FirstOrDefault(r => r.AdresId == item.Adres.AdresId);
                            if (adr != null)
                                c.Adres.Remove(adr);
                            else
                                item.Adres = null;
                        }
                    }
                }

                c.UpdateRange(list);
                c.SaveChanges();
            }

            initListAll();
            initList(dzialkaPrv);
        }
    }
}
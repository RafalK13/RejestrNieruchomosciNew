using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_BudynekViewModel : ViewModelBase
    {

        private bool _jednrodzinny;

        public bool jednorodzinny
        {
            get { return _jednrodzinny; }
            set
            {
                _jednrodzinny = value;
                serveJednorodzinnyButton();
                //MessageBox.Show("Clicked");
                RaisePropertyChanged();
            }
        }

        private void serveJednorodzinnyButton()
        {
            if (budSel != null)
            {
                if (jednorodzinny == true)
                {
                    budSel.jednorodzinny = true;
                    widthRaf = new GridLength(0);
                }
                else
                {
                    budSel.jednorodzinny = false;
                    widthRaf = new GridLength(250);
                }
            }
        }

        private GridLength _widthRaf;

        public GridLength widthRaf
        {
            get { return _widthRaf; }
            set { Set(ref _widthRaf, value); }
        }


        private string _budName;

        public string budName
        {
            get { return _budName; }
            set => Set(ref _budName, value);
        }

        private int? _gminaId;

        [DoNotWire]
        public int? gminaId
        {
            get { return _gminaId; }
            set => Set(ref _gminaId, value);
        }

        private int _selDzialkaPrzylId;

        public int selDzialkaPrzylId
        {
            get { return _selDzialkaPrzylId; }
            set { Set(ref _selDzialkaPrzylId, value); }
        }

        private IAdresSloList _adresSloList;

        public IAdresSloList adresSloList
        {
            get => _adresSloList;
            set { Set(ref _adresSloList, value); }
        }

        public UserControl_PreviewViewModel userPrev { get; set; }

        private Visibility _sellVisibility;
        public Visibility sellVisibility
        {
            get => _sellVisibility;

            set
            {
                _sellVisibility = value;
                RaisePropertyChanged();
            }
        }

        private bool _podmiotDetail;
        public bool podmiotDetail
        {
            get => _podmiotDetail;

            set
            {
                _podmiotDetail = value;
                RaisePropertyChanged();
            }
        }

        private string _budynekName;
        public string budynekName
        {
            get => _budynekName;
            set
            {
                _budynekName = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<IBudynek> budListLok { get; set; }

        public IBudynkiList budList { get; set; }

        private int _nr;
        public int nr
        {
            get { return _nr; }
            set
            {
                _nr = value;
                RaisePropertyChanged();
            }
        }

        private Budynek _b;

        private IBudynek _budSel;
        public IBudynek budSel
        {
            get { return _budSel; }
            set
            {
                
                _budSel = value;
                testBudynekSel();
                RaisePropertyChanged();
            }
        }

        private void BudSel_zmiana1(object sender, EventArgs e)
        {
            MessageBox.Show("Rafałek");
        }

        //private void checkWidthColumn()
        //{

           
        //    int ddd = 1;
        //    if (budSel?.jednorodzinny == true)
        //        widthRaf = new GridLength(75, GridUnitType.Star);
        //    else
        //        widthRaf = new GridLength(0, GridUnitType.Star);
        //}

        //private void BudSel_zmiana(object sender, EventArgs e)
        //{
        //    checkWidthColumn();
        //}

        private ObservableCollection<IDzialka> _dzialkaListBud;
        public ObservableCollection<IDzialka> dzialkaListBud
        {
            get => _dzialkaListBud;

            set
            {
                _dzialkaListBud = value;
                RaisePropertyChanged();
            }
        }

        public List<IDzialka> dzialkaList { get; set; }

        private IDzialka _dzialkaSel;
        public IDzialka dzialkaSel
        {
            get { return _dzialkaSel; }
            set { Set(ref _dzialkaSel, value); }
        }

        private IDzialka _dzialkaPrzylSel;
        public IDzialka dzialkaPrzylSel
        {
            get { return _dzialkaPrzylSel; }
            set { Set(ref _dzialkaPrzylSel, value); }
        }

        private List<IDzialka> _dzialkaIn;

        public List<IDzialka> dzialkaIn
        {
            get { return _dzialkaIn; }
            set { Set(ref _dzialkaIn, value); }
        }

        #region Konstruktor
        public UserControl_BudynekViewModel(UserControl_PreviewViewModel userPrev,
                                           IBudynkiList _budList)
        {
            initButtons();

            dzialkaSel = userPrev.dzialkaSel;

            sellVisibility = Visibility.Hidden;

            if (userPrev.dzialkaSel != null)
            {
                _budList.getList(dzialkaSel);

                using (var c = new Context())
                {
                    budListLok = new ObservableCollection<IBudynek>(c.Budynek.Include(f => f.Dzialka_Budynek).ThenInclude(d => d.Dzialka)
                                                                             .Include(a => a.Adres)
                                                                             .Where(r => r.Dzialka_Budynek.FirstOrDefault(l => l.DzialkaId == dzialkaSel.DzialkaId) != null)
                                                                   );
                }


                if (dzialkaSel.Obreb != null)
                {
                    using (var c = new Context())
                    {
                        gminaId = dzialkaSel.Obreb.GminaSloId;
                        dzialkaIn = new List<IDzialka>(new Dzialka[] { (Dzialka)userPrev.dzialkaSel });
                        dzialkaList = c.Dzialka.AsNoTracking().Where(r => r.ObrebId == dzialkaSel.ObrebId).Select(r2 => (IDzialka)r2).ToList()
                                      .Except(dzialkaIn).ToList();
                    }
                }
            }
            //checkWidthColumn();
            podmiotDetail = false;
            budSel = null;
            
        }

        #endregion
        private void testBudynekSel()
        {
            if (budSel != null && budSel.Nazwa != null)
            {
                if (budSel.Adres == null)
                    budSel.Adres = new Adres();

                podmiotDetail = true;
                if (budSel.Dzialka_Budynek != null)
                {
                    var dzialkaListBudAll = new List<IDzialka>(budSel.Dzialka_Budynek.Select(r => r.Dzialka).ToList());


                    dzialkaListBud = new ObservableCollection<IDzialka>(dzialkaListBudAll.Except(dzialkaIn).ToList());

                }

                budName = string.Empty;

                if (budSel.jednorodzinny == true)
                    jednorodzinny = true;
                else
                    jednorodzinny = false;


               
            }
            else
                podmiotDetail = false;

            budName = "*";
            //budName = string.Empty;
        }

        private bool testWlascExist()
        {
            if (budListLok.Count == 0)
                return false;

            var v = budListLok.Where(r => r.BudynekId == budSel.BudynekId
                                        ).Count();

            return (v == 0) ? false : true;
        }

        #region Buttons
        public ICommand budynekAdd { get; set; }
        public ICommand budynekDel { get; set; }
        public ICommand dzialakBudynekAdd { get; set; }
        public ICommand dzialakBudynekCls { get; set; }
        public ICommand onTest { get; set; }
        public ICommand dzialkaPrzylAdd { get; set; }
        public ICommand dzilakaPrzylDel { get; set; }

        private void initButtons()
        {
            budynekAdd = new RelayCommand(onBudynekAdd);
            budynekDel = new RelayCommand(onBudynektDel);
            dzialakBudynekAdd = new RelayCommand(onDzialkaBudynekAdd);
            dzialakBudynekCls = new RelayCommand(onDzialkaBudynekCls);
            dzialkaPrzylAdd = new RelayCommand(onDzialkaPrzylAdd);
            dzilakaPrzylDel = new RelayCommand(onDzialkaPrzylDel);
        }
        #endregion

        private void onDzialkaPrzylDel()
        {
            var v = budSel.Dzialka_Budynek.FirstOrDefault(r => r.DzialkaId == dzialkaPrzylSel.DzialkaId && r.Budynek.BudynekId == budSel.BudynekId);

            budSel.Dzialka_Budynek.Remove(v);
            dzialkaListBud.Remove(dzialkaPrzylSel);
        }

        private void onDzialkaPrzylAdd()
        {
            if (testDzialkaPrzyl())
            {
                IDzialka d = dzialkaList.FirstOrDefault(r => r.DzialkaId == selDzialkaPrzylId);

                if (d != null)
                {
                    budSel.Dzialka_Budynek.Add(new Dzialka_Budynek
                    {
                        DzialkaId = d.DzialkaId
                                                                     ,
                        Dzialka = (Dzialka)d
                                                                     ,
                        Budynek = (Budynek)budSel
                    });
                    dzialkaListBud.Add(d);
                }
            }
            budName = "*";
        }

        private bool testDzialkaPrzyl()
        {
            bool result = dzialkaListBud.FirstOrDefault(r => r.DzialkaId == selDzialkaPrzylId) == null ? true : false;
            return result;
        }

        private void onBudynektDel()
        {
            budListLok.Remove(budSel);
        }

        private void onDzialkaBudynekCls()
        {
            budSel = null;
        }

        private void onDzialkaBudynekSell()
        {
            sellVisibility = Visibility.Visible;
        }

        private void onDzialkaBudynekAdd()
        {

            budList.list = budListLok;

            budList.saveBudynki();

        }

        private void onBudynekAdd()
        {
            if (string.IsNullOrEmpty(budynekName) == false)
                if (testIfExist())
                {
                    Budynek bud = new Budynek { Nazwa = budynekName, Dzialka_Budynek = new List<Dzialka_Budynek>() { new Dzialka_Budynek { DzialkaId = userPrev.dzialkaSel.DzialkaId, Dzialka = (Dzialka)userPrev.dzialkaSel } } };

                    budListLok.Add(bud);

                    budynekName = string.Empty;
                    budSel = null;
                }

        }

        private bool testIfExist()
        {
            return budListLok.FirstOrDefault(r => r.Nazwa == budynekName) == null ? true : false;
            //return budList.list.FirstOrDefault(r => r.Nazwa == budynekName) == null ? true : false;
        }


        //private void onBudynektDel()
        //{
        //    //inneListLok.Remove(innePrawaSel);
        //    //innePrawaSel = null;
        //}
    }
}

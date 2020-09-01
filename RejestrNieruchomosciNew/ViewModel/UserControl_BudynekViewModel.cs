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

        #region CheckBoxVisible
        private bool _isCheckBoxVisible;

        public bool isCheckBoxVisible
        {
            get { return _isCheckBoxVisible; }
            set
            {
                _isCheckBoxVisible = value;
                
                makeLokSingle();
                RaisePropertyChanged();
            }
        }

        private void makeLokSingle()
        {
            
            if (budSel != null)
            {
                if (budSel.jednorodzinny == true)
                {
                    if (budSel.Lokal.Count == 0)
                    {
                        budSel.Lokal.Add(new Lokal { Numer = "jednorodzinny" });
                    }
                    lokalSel = budSel.Lokal.First();
                }
                setWidthColumn();
            }
        }

        #endregion

        #region GridLength widthRaf
        private GridLength _widthRaf;

        public GridLength widthRaf
        {
            get { return _widthRaf; }
            set { Set(ref _widthRaf, value); }
        }
        #endregion

        #region lokalNumer
        private string _lokalNumer;

        public string lokalNumer
        {
            get { return _lokalNumer; }
            set { Set(ref _lokalNumer, value); }
        }

        #endregion

        #region budName
        private string _budName;

        public string budName
        {
            get { return _budName; }
            set => Set(ref _budName, value);
        }
        #endregion

        #region gminaId
        private int? _gminaId;

        [DoNotWire]
        public int? gminaId
        {
            get { return _gminaId; }
            set => Set(ref _gminaId, value);
        }
        #endregion

        #region selDzialkaPrzyl
        private int _selDzialkaPrzylId;

        public int selDzialkaPrzylId
        {
            get { return _selDzialkaPrzylId; }
            set { Set(ref _selDzialkaPrzylId, value); }
        }
        #endregion

        #region adresSloList
        private IAdresSloList _adresSloList;

        public IAdresSloList adresSloList
        {
            get => _adresSloList;
            set { Set(ref _adresSloList, value); }
        }
        #endregion

        #region userPrev
        public UserControl_PreviewViewModel userPrev { get; set; }
        #endregion

        #region sellVisibility
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
        #endregion

        #region bool podmiotDetail
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
        #endregion

        #region string budynekName
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
        #endregion

        #region IBudynek budSel
        private IBudynek _budSel;
        public IBudynek budSel
        {
            get { return _budSel; }
            set
            {
                _budSel = value;
                testBudynekSel();

                if (budSel != null)
                {
                    budSel.zmiana -= BudSel_zmiana;
                    budSel.zmiana += BudSel_zmiana;
                }
                RaisePropertyChanged();
            }
        }

        private void BudSel_zmiana(object sender, EventArgs e)
        {
            isCheckBoxVisible = false;
            makeLokSingle();
            

        }

        private void setWidthColumn()
        {
            if (budSel != null)
            {
                if (budSel.jednorodzinny == true)
                {
                    widthRaf = new GridLength(0);
                }
                else
                    widthRaf = new GridLength(250);

            }
        }
        #endregion

        #region List<IDzialka> dzialkaIn
        List<IDzialka> dzialkaIn;
        #endregion

        #region ObservableCollection<IDzialka> dzialkaListBud
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
        #endregion

        public List<IDzialka> dzialkaList { get; set; }

        public ObservableCollection<IBudynek> budListLok { get; set; }

        public IBudynkiList budList { get; set; }

        #region IDzialka dzialkaPrzylSel

        private IDzialka _dzialkaPrzylSel;
        public IDzialka dzialkaPrzylSel
        {
            get { return _dzialkaPrzylSel; }
            set { Set(ref _dzialkaPrzylSel, value); }
        }
        #endregion

        #region ILokal lokalSel
        private ILokal _lokalSel;

        public ILokal lokalSel
        {
            get { return _lokalSel; }
            set
            {
                _lokalSel = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region KONSTRUKTOR

        public UserControl_BudynekViewModel(UserControl_PreviewViewModel _userPrev
                                           , IBudynkiList _budList)
        {
            initButtons();

            userPrev = _userPrev;
            sellVisibility = Visibility.Hidden;

            if (_userPrev.dzialkaSel != null)
            {
                _budList.getList(userPrev.dzialkaSel);

                using (var c = new Context())
                {
                    budListLok = new ObservableCollection<IBudynek>(c.Budynek.Include(f => f.Dzialka_Budynek).ThenInclude(d => d.Dzialka)
                                                                             .Include(a => a.Adres)
                                                                             .Include(l => l.Lokal)
                                                                             .Where(r => r.Dzialka_Budynek.FirstOrDefault(l => l.DzialkaId == userPrev.dzialkaSel.DzialkaId) != null)
                                                                   );
                }

                if (userPrev.dzialkaSel.Obreb != null)
                {
                    using (var c = new Context())
                    {
                        gminaId = userPrev.dzialkaSel.Obreb.GminaSloId;
                        dzialkaIn = new List<IDzialka>(new Dzialka[] { (Dzialka)_userPrev.dzialkaSel });
                        dzialkaList = c.Dzialka.AsNoTracking().Where(r => r.ObrebId == userPrev.dzialkaSel.ObrebId).Select(r2 => (IDzialka)r2).ToList()
                                      .Except(dzialkaIn).ToList();
                    }
                }
            }
            podmiotDetail = false;
            budSel = null;
            widthRaf = new GridLength(250);
        }

        #endregion

        private void testBudynekSel()
        {
            if (budSel != null && budSel.Nazwa != null)
            {
                if (budSel.Adres == null)
                    budSel.Adres = new Adres();

                if (budSel.Lokal == null)
                {
                    budSel.Lokal = new ObservableCollection<Lokal>();
                    //lokalSel = new Lokal() { BudynekId = budSel.BudynekId };
                    //budSel.Lokal.Add((Lokal)lokalSel);
                }
                else
                {
                    //lokalSel = budSel.Lokal.FirstOrDefault();
                }
               

                isCheckBoxVisible = budSel.Lokal.Count > 0 ? false : true;

                podmiotDetail = true;
                if (budSel.Dzialka_Budynek != null)
                {
                    var dzialkaListBudAll = new List<IDzialka>(budSel.Dzialka_Budynek.Select(r => r.Dzialka).ToList());
                    dzialkaListBud = new ObservableCollection<IDzialka>(dzialkaListBudAll.Except(dzialkaIn).ToList());
                }

                budName = string.Empty;

                setWidthColumn();
                
            }
            else
                podmiotDetail = false;

            budName = "*";

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
        public ICommand dzialakBudynekSave { get; set; }
        public ICommand dzialakBudynekCls { get; set; }
        public ICommand dzialkaPrzylAdd { get; set; }
        public ICommand dzilakaPrzylDel { get; set; }
        public ICommand lokalAdd { get; set; }
        public ICommand lokalDel { get; set; }

        private void initButtons()
        {
            budynekAdd = new RelayCommand(onBudynekAdd);
            budynekDel = new RelayCommand(onBudynektDel);
            dzialakBudynekSave = new RelayCommand(onDzialakBudynekSave);
            dzialakBudynekCls = new RelayCommand(onDzialkaBudynekCls);
            dzialkaPrzylAdd = new RelayCommand(onDzialkaPrzylAdd);
            dzilakaPrzylDel = new RelayCommand(onDzialkaPrzylDel);
            lokalAdd = new RelayCommand(onLokalAdd);
            lokalDel = new RelayCommand(onlokalDel);
        }

        private void onlokalDel()
        {
            if (lokalSel != null)
                budSel.Lokal.Remove((Lokal)lokalSel);

        }

        private void onLokalAdd()
        {
            if (string.IsNullOrEmpty(lokalNumer) == false)
            {
                if (testLokalIfExist())
                {
                    Lokal lokal = new Lokal() { Numer = lokalNumer };
                    budSel.Lokal.Add(lokal);
                    lokalNumer = string.Empty;
                    lokalSel = null;
                    isCheckBoxVisible = false;
                }
            }
        }

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

        private void onDzialakBudynekSave()
        {
            budSel = null;
            budList.list = budListLok;
            budList.saveBudynki();
        }

        private void onBudynekAdd()
        {
            if (string.IsNullOrEmpty(budynekName) == false)
                if (testBudynekIfExist())
                {
                    Budynek bud = new Budynek { Nazwa = budynekName, Dzialka_Budynek = new List<Dzialka_Budynek>() { new Dzialka_Budynek { DzialkaId = userPrev.dzialkaSel.DzialkaId, Dzialka = (Dzialka)userPrev.dzialkaSel } } };

                    budListLok.Add(bud);

                    budynekName = string.Empty;
                    budSel = null;
                }

        }
        #endregion

        private bool testBudynekIfExist()
        {
            return budListLok.FirstOrDefault(r => r.Nazwa == budynekName) == null ? true : false;
        }

        private bool testLokalIfExist()
        {
            return budSel.Lokal.FirstOrDefault(r => r.Numer == lokalNumer) == null ? true : false;
        }
    }
}

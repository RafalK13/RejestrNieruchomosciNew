using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private string _budName;

        public string budName
        {
            get { return _budName; }
            set => Set( ref _budName, value);
            
        }


        private int? _gminaId;

        [DoNotWire]
        public int? gminaId
        {
            get { return _gminaId; }
            set => Set(ref _gminaId, value);
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

        private ObservableCollection<IDzialka> _dzialkaListBud;
        public ObservableCollection<IDzialka> dzialkaListBud
        {
            get => _dzialkaListBud;

            set {
                _dzialkaListBud = value;
                RaisePropertyChanged();
            }
        }

        public List<IDzialka> dzialkaList { get; set; }

        public UserControl_BudynekViewModel(UserControl_PreviewViewModel userPrev,
                                           IBudynkiList _budList)
        {
            initButtons();

            sellVisibility = Visibility.Hidden;

            if (userPrev.dzialkaSel != null)
            {
                //dzialkaId = int.Parse(userPrev.dzialkaSel.DzialkaId.ToString());
                _budList.getList(userPrev.dzialkaSel);

                budListLok = new ObservableCollection<IBudynek>(_budList.list.Select(r => new Budynek(r)).ToList());

                if (userPrev.dzialkaSel.Obreb != null)
                {
                    gminaId = userPrev.dzialkaSel.Obreb.GminaSloId;
                    dzialkaList = userPrev.dzialkiList.list.Where(d => d.ObrebId == userPrev.dzialkaSel.ObrebId).ToList();
                    
                }
            }
            
            podmiotDetail = false;
            budSel = null;
        }

        private void testBudynekSel()
        {
            if (budSel != null && budSel.Nazwa != null)
            {
                if (budSel.Adres == null)
                    budSel.Adres = new Adres();
               
                podmiotDetail = true;
               
                if (budSel.Dzialka_Budynek != null)
                {
                    var newList = new IDzialka[] { (IDzialka)userPrev.dzialkaSel };
                    var newBudList = new ObservableCollection<IDzialka>( budSel.Dzialka_Budynek.Select(r => r.Dzialka).ToList());

                    dzialkaListBud = new ObservableCollection<IDzialka>( newBudList.Except(newList));
                }

                budName = "*";
            }
            else
                podmiotDetail = false;

            budName = string.Empty;
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

        public string tekstRaf { get; set; } = "Rafałek";

        #endregion

        private void initButtons()
        {
            budynekAdd = new RelayCommand(onBudynekAdd);
            budynekDel = new RelayCommand(onBudynektDel);
            dzialakBudynekAdd = new RelayCommand(onDzialkaBudynekAdd);
            dzialakBudynekCls = new RelayCommand(onDzialkaBudynekCls);
            onTest = new RelayCommand(onTestRaf);
        }

        private void onTestRaf()
        {
            MessageBox.Show(gminaId.ToString());
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
          

            //foreach (var item in budListLok)
            //{
            //    if (item.Adres.MiejscowoscSloId == 0)
            //        item.Adres = null;
            //}

            budList.list = new ObservableCollection<IBudynek>(budListLok.Select(r => new Budynek(r)).ToList());

            budList.saveBudynki();
        }

        private void onBudynekAdd()
        {
            if (string.IsNullOrEmpty(budynekName) == false)
                if (testIfExist())
                {
                    Budynek bud = new Budynek() { Nazwa = budynekName };

                    budListLok.Add(bud);
                    budList.list.Add(bud);

                    budynekName = string.Empty;
                    budSel = null;
                }
        }

        private bool testIfExist()
        {
            return budList.list.FirstOrDefault(r => r.Nazwa == budynekName) == null ? true : false;
        }


        //private void onBudynektDel()
        //{
        //    //inneListLok.Remove(innePrawaSel);
        //    //innePrawaSel = null;
        //}
    }
}

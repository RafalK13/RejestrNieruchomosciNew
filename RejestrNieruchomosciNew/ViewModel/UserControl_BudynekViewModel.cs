using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_BudynekViewModel : ViewModelBase
    {
        private int? _gminaId;

        public int? gminaId
        {
            get { return _gminaId; }
            set => Set(ref _gminaId, value);
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

        public UserControl_BudynekViewModel(UserControl_PreviewViewModel userPrev,
                                           IBudynkiList _budList)
        {
            initButtons();

            sellVisibility = Visibility.Hidden;

            if (userPrev.dzialkaSel != null)
            {
                //dzialkaId = int.Parse(userPrev.dzialkaSel.DzialkaId.ToString());
                _budList.getList(userPrev.dzialkaSel);
                int r1 = 1;
                budListLok = new ObservableCollection<IBudynek>(_budList.list.Select(r => new Budynek(r)).ToList());
            }
            int r2 = 2;
            podmiotDetail = false;
        }

        private void testBudynekSel()
        {
            if (budSel != null)
            {
                //if (budSel.DzialkaId != 0)
                //{
                //    podmiotDetail = true;
                //}
            }
            else
                podmiotDetail = false;
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
        #endregion

        private void initButtons()
        {
            budynekAdd = new RelayCommand(onBudynekAdd);
            budynekDel = new RelayCommand(onBudynektDel);
            dzialakBudynekAdd = new RelayCommand(onDzialkaBudynekAdd);
            dzialakBudynekCls = new RelayCommand(onDzialkaBudynekCls);
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
            budList.list = new ObservableCollection<IBudynek>(budListLok.Select(r => new Budynek(r)).ToList());
            int r2 = 14;
            budList.saveBudynki();
        }

        private void onBudynekAdd()
        {
            if (testIfExist())
            {
                Budynek bud = new Budynek() { Nazwa = budynekName };

                budListLok.Add( bud);
                budList.list.Add( bud);
               
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

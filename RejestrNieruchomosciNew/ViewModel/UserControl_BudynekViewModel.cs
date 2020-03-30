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
        //private int dzialkaId;

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

        public ObservableCollection<IDzialka_Budynek> dzBudListLok { get; set; }
        public IDzialka_BudynekList dzBudList { get; set; }

        private IDzialka_Budynek _dzBudSel;
        public IDzialka_Budynek dzBudSel
        {
            get { return _dzBudSel; }
            set
            {
                _dzBudSel = value;
                testBudynekSel();
                RaisePropertyChanged();
            }
        }

        public UserControl_BudynekViewModel(UserControl_PreviewViewModel userPrev,
                                           IDzialka_BudynekList _dzialBudynekList)
        {
            initButtons();

            sellVisibility = Visibility.Hidden;

            if (userPrev.dzialkaSel != null)
            {
                //dzialkaId = int.Parse(userPrev.dzialkaSel.DzialkaId.ToString());
                _dzialBudynekList.getList(userPrev.dzialkaSel);
                

                dzBudListLok = new ObservableCollection<IDzialka_Budynek>(_dzialBudynekList.list.Select(r => new Dzialka_Budynek(r)).ToList());
            }

            podmiotDetail = false;
        }

        private void testBudynekSel()
        {
            if (dzBudSel != null)
            {
                if (dzBudSel.DzialkaId != 0)
                {
                    podmiotDetail = true;
                }
            }
            else
                podmiotDetail = false;
        }

        private bool testWlascExist()
        {
            if (dzBudListLok.Count == 0)
                return false;

            var v = dzBudListLok.Where(r => r.BudynekId == dzBudSel.BudynekId
                                         && r.DzialkaId == dzBudSel.DzialkaId).Count();

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
            dzBudListLok.Remove( dzBudSel);
        }

        private void onDzialkaBudynekCls()
        {
            dzBudSel = null;
        }


        private void onDzialkaBudynekSell()
        {
            sellVisibility = Visibility.Visible;
        }

        private void onDzialkaBudynekAdd()
        {

            dzBudList.list = new ObservableCollection<IDzialka_Budynek>(dzBudListLok.Select(r => new Dzialka_Budynek(r)).ToList());

           
            dzBudList.save();
        }

        private void onBudynekAdd()
        {
            if (testIfExist())
            {
                Budynek bud = new Budynek() { Nazwa = budynekName };

                dzBudListLok.Add(new Dzialka_Budynek() { Budynek = bud, DzialkaId = userPrev.dzialkaSel.DzialkaId });
                dzBudList.list.Add(new Dzialka_Budynek() { Budynek = bud, DzialkaId = userPrev.dzialkaSel.DzialkaId });
                budynekName = string.Empty;
                dzBudSel = null;
            }
        }

        private bool testIfExist()
        {
            return dzBudList.list.FirstOrDefault(r => r.Budynek.Nazwa == budynekName) == null ? true : false;
        }


        //private void onBudynektDel()
        //{
        //    //inneListLok.Remove(innePrawaSel);
        //    //innePrawaSel = null;
        //}
    }
}

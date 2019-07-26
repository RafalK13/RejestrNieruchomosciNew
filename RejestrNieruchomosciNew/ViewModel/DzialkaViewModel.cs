using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class DzialkaViewModel : ViewModelBase
    {
        #region Properties
        private ObrebClass _obreb;
        public ObrebClass obreb
        {
            get => _obreb;
            set
            {
                _obreb = value;
                RaisePropertyChanged("obreb");
            }
        }

        private string _dzialkaNr;
        public string dzialkaNr
        {
            get => _dzialkaNr;
            set
            {
                _dzialkaNr = value;
                RaisePropertyChanged("dzialkaNr");
                setFilter();
            }
        }

        private string _kwA;
        public string kwA
        {
            get => _kwA;
            set
            {
                _kwA = value;
                RaisePropertyChanged("kwA");
            }
        }

        private string _kwZ;
        public string kwZ
        {
            get => _kwZ;
            set
            {
                _kwZ = value;
                RaisePropertyChanged("kwZ");
            }
        }

        private decimal _pow;
        public decimal pow
        {
            get => _pow;
            set
            {
                _pow = value;
                RaisePropertyChanged("pow");
            }
        }

        public Dzialka GetDzialka 
        {
            get => new Dzialka(dzialkaNr, obreb.getId().Value, kwA, kwZ, pow);
        }

        public ICommand leftClick { get; set; }

        #endregion

        #region Konstructor
        public DzialkaViewModel()
        {
            obreb = new ObrebClass();
            leftClick = new RelayCommand(onLeftClick);
        }
        #endregion

        #region Metods
        private void onLeftClick()
        {
            setFilter();
        }

        public void setFilter()
        {
            UserControl_PreviewViewModel d = ServiceLocator.Current.GetInstance<UserControl_PreviewViewModel>();

            if (obreb.getId().HasValue && string.IsNullOrEmpty(dzialkaNr) == false)
            {
                int c = d.dzialkaList.Where(r => r.ObrebId == obreb.getId().Value &&
                                                 r.Numer == dzialkaNr).Count();

                var v = ServiceLocator.Current.GetInstance<AddViewModel>();

                v.canAdd = c == 0 ? true : false;
            }
            #endregion
        }
    }
}

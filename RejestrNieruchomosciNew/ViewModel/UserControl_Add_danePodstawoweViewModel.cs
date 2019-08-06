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
    public class UserControl_Add_danePodstawoweViewModel : ViewModelBase
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

        public Dzialka dzialka { get; set; }
      
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

        private bool _isNew;
        public bool isNew
        {
            get => _isNew;
            set
            {
                _isNew = value;
                RaisePropertyChanged("isNew");
            }
        }

        public Dzialka GetDzialka 
        {
            get => new Dzialka(dzialka.Numer, obreb.getId().Value, kwA, kwZ, pow);
        }

        public ICommand leftClick { get; set; }

        #endregion

        #region Konstructor
        public UserControl_Add_danePodstawoweViewModel()
        {
            obreb = new ObrebClass();
            isNew = false;

            leftClick = new RelayCommand(onLeftClick);
            dzialka = new Dzialka();
  
        }
        #endregion
               
        #region Metods
        private void onLeftClick()
        {         
            setFilter();
        }

        public void setFilter()
        {
            
            MainViewModel d = ServiceLocator.Current.GetInstance<MainViewModel>();

            if (obreb.getId().HasValue && string.IsNullOrEmpty(dzialka.Numer) == false)
            {
                int c = d.dzialkaList.Where(r => r.ObrebId == obreb.getId().Value &&
                                                 r.Numer == dzialkaNr).Count();
                dzialka.ObrebId = obreb.getId().Value;
                isNew = c == 0 ? true : false;
            }
            #endregion
        }
    }
}

using Castle.Core;
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
            get => _obreb; set
            {
                _obreb = value;
                RaisePropertyChanged("obreb");
            }
        }
        public IDzialka dzialka { get; set; }

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

        public ICommand leftClick { get; set; }

        public DzialkaList dzialkaList { get; set; }

        #endregion

        #region Konstructor

        public UserControl_Add_danePodstawoweViewModel()
        {
            isNew = false;

            leftClick = new RelayCommand(onLeftClick);
        }
        #endregion

        #region Metods
        private void onLeftClick()
        {
            testDzialka();
        }

        public void testDzialka()
        {
            
            if (obreb.getId().HasValue && string.IsNullOrEmpty(dzialka.Numer) == false)
            {

                int c = dzialkaList.dzialkaList.Where(r => r.ObrebId == obreb.getId().Value &&
                                                 r.Numer == dzialka.Numer).Count();
                dzialka.ObrebId = obreb.getId().Value;
                isNew = c == 0 ? true : false;
            }
            #endregion
        }
    }
}

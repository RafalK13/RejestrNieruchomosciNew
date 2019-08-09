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

        [DoNotWire]
        public ObrebClass obreb { get; set; }
        [DoNotWire]
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

        #endregion

        #region Konstructor
        public UserControl_Add_danePodstawoweViewModel(IDzialka dz, ObrebClass ob)
        {
            dzialka = dz;
            obreb = ob;
            isNew = false;

            leftClick = new RelayCommand(onLeftClick);

            obreb.fillValues(dzialka.ObrebId);
            
        }
        #endregion
            

        #region Metods
        private void onLeftClick()
        {         
            testDzialka();
        }

        public void testDzialka()
        {
            
            //MainViewModel d = ServiceLocator.Current.GetInstance<MainViewModel>();

            //if (obreb.getId().HasValue && string.IsNullOrEmpty(dzialka.Numer) == false)
            //{
            //    int c = d.dzialkaList.Where(r => r.ObrebId == obreb.getId().Value &&
            //                                     r.Numer == dzialka.Numer).Count();
            //    dzialka.ObrebId = obreb.getId().Value;
            //    isNew = c == 0 ? true : false;
            //}
            #endregion
        }
    }
}

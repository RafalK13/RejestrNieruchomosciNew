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
    public class UserControl_DanePodstawoweViewModel : ViewModelBase
    {
        #region Properties

        //public IPerson personUserAddViewModel { get; set; }

        private IDzialka _dzialka;
        public IDzialka dzialka
        {
            get => _dzialka;
            set
            {
                _dzialka = value;
                RaisePropertyChanged("dzialka");
            }
        }

        private ObrebClass _obreb;
        public ObrebClass obreb
        {
            get => _obreb; set
            {
                _obreb = value;

                RaisePropertyChanged("obreb");
                obreb.fillValues(dzialka.ObrebId);
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

        public ICommand leftClick { get; set; }

        public IDzialkaList dzialkaList { get; set; }
     
        #endregion

        #region Konstructor

        public UserControl_DanePodstawoweViewModel( )
        {
            //isNew = false;
            isNew = true;
            leftClick = new RelayCommand(onLeftClick);


            //MessageBox.Show("Kon");

        }
        #endregion

        #region Metods
        private void onLeftClick()
        {
            testDzialka();
        }

        public void testDzialka()
        {
            isNew = true;

            //if (obreb.getId().HasValue && string.IsNullOrEmpty(dzialka.Numer) == false)
            //{
            //    int c = dzialkaList.dzialkaList.Where(r => r.ObrebId == obreb.getId().Value &&
            //                                     r.Numer == dzialka.Numer).Count();
            //    dzialka.ObrebId = obreb.getId().Value;
               
            //    isNew = c == 0 ? true : false;
            //}
            #endregion
        }
    }
}

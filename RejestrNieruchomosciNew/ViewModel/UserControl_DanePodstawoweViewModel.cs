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

        public ChangeMode changeMode;

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
            }
        }

        private bool _canAdd;
        public bool canAdd
        {
            get
            {
                return _canAdd;
            }

            set
            {
                _canAdd = value;
                RaisePropertyChanged("canAdd");
            }
        }

        public bool? canMod;

        public ICommand leftClick { get; set; }

        public IDzialkaList dzialkaList { get; set; }

        #endregion

        #region Konstructor

        public UserControl_DanePodstawoweViewModel()
        {
            leftClick = new RelayCommand(onLeftClick);
        }
        #endregion

        #region Metods
        private void onLeftClick()
        {
            if (obreb.getId().HasValue)
            {
                dzialka.ObrebId = obreb.getId().Value;
                testDzialka();
            }
        }

        public void testDzialka()
        {
            if (changeMode == ChangeMode.add)
                testDzialkaToAdd();
            if (changeMode == ChangeMode.mod)
                testDzialkaToMod();

        }

        private void testDzialkaToAdd()
        {
            if (obreb.getId().HasValue && string.IsNullOrEmpty(dzialka.Numer) == false)
            {
                int c = dzialkaList.dzialkaList.Where(r => r.ObrebId == obreb.getId().Value &&
                                                 r.Numer == dzialka.Numer).Count();

                canAdd = c == 0 ? true : false;
            }
        }

        private void testDzialkaToMod()
        {
            var dz = dzialkaList.dzialkaList.First(n => n.DzialkaId == dzialka.DzialkaId);

            dz.ObrebId = obreb.getId().Value;

            if (!string.IsNullOrEmpty(dzialka.Numer))
            {
                if (string.Compare(dz.Numer, dzialka.Numer) == 0 &&
                           dz.ObrebId == dzialka.ObrebId)
                {
                    canAdd = true;
                }
                else
                {
                    int c = dzialkaList.dzialkaList.Where(r => r.ObrebId == obreb.getId().Value &&
                                                 r.Numer == dzialka.Numer).Count();
                    
                    canAdd = c == 0 ? true : false;
                }
            }
           
        }

        #endregion
    }
}

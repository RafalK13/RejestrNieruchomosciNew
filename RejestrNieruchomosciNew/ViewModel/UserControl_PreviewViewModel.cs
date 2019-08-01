using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_PreviewViewModel : ViewModelBase
    {
        #region Properties

        #region privateProperties
        public Dzialka _dzialkaSel;
        #endregion
        public ICommand dubleClick { get; set; }
        public ICommand leftClick { get; set; }
        public ICommand clsClick { get; set; }

        public ICollectionView dzialkaView
        {
            get => CollectionViewSource.GetDefaultView(dzialkaList);
        }

        public Dzialka dzialkaSel
        {
            get => _dzialkaSel; set
            {
                _dzialkaSel = value;
                RaisePropertyChanged("dzialkaSel");
            }
        }

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

        private List<Dzialka> _dzialkaList;
        public List<Dzialka> dzialkaList
        {
            get => _dzialkaList;
            set
            {
                _dzialkaList = value;
                RaisePropertyChanged("dzialkaList");
                RaisePropertyChanged("dzialkaView");
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

        private string _result;
        public string result
        {
            get => _result;
            set
            {
                _result = value;
                RaisePropertyChanged("result");
            }
        }

        private bool _allowDelete;
        public bool allowDelete
        {
            get => _allowDelete;
            set
            {
                _allowDelete = value;
                RaisePropertyChanged("allowDelete");
            }
        }
        #endregion

        #region Konstructor

        public UserControl_PreviewViewModel()
        {
            initDzialkaList();

            dubleClick = new RelayCommand(onDoubleClicked);
            leftClick = new RelayCommand(onLeftClick);
            clsClick = new RelayCommand(onClsClick);

            obreb = new ObrebClass();
            allowDelete = true;
        }

        #endregion

        #region Methods

        private void initDzialkaList()
        {
            var v = ServiceLocator.Current.GetInstance<MainViewModel>();
            dzialkaList = v.dzialkaList;
        }

        public void refillDzialkaList()
        {
            var v = ServiceLocator.Current.GetInstance<MainViewModel>();
            v.initDzialkaList();
            dzialkaList = v.dzialkaList;
            //            dzialkaView.Refresh();
        }

        //private Dzialka GetDzialka()
        //{
        //    //return new Dzialka( dzialkaNr, obreb.getId( ))
        //}

        private void onClsClick()
        {
            dzialkaNr = String.Empty;
            obreb.clsObreb();
        }

        private void onLeftClick()
        {
            setFilter();
        }

        private void onDoubleClicked()
        {
            if (allowDelete == true)
            {
                var v = ServiceLocator.Current.GetInstance<MainViewModel>();
                v.deleteDzialka();
            }
        }

        public void setFilter()
        {
            string s = String.Empty;

            dzialkaView.Filter = row =>
            {
                Dzialka d = row as Dzialka;

                bool nb = !string.IsNullOrEmpty(dzialkaNr) ? d.Numer.Contains(dzialkaNr) : true;
                bool ob = !string.IsNullOrEmpty(obreb.obrebValue) ? d.Obreb.Nazwa.Contains(obreb.obrebValue) : true;
                bool gb = !string.IsNullOrEmpty(obreb.gminaValue) ? d.Obreb.GminaSlo.Nazwa.Contains(obreb.gminaValue) : true;

                return nb && ob && gb;
            };
            result = dzialkaView.Cast<object>().Count().ToString();
        }
        #endregion
    }

}

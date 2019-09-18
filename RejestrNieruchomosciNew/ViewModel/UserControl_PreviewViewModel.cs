using Castle.Core;
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

        #region ICommand
        public ICommand doubleClick { get; set; }
        public ICommand leftClick { get; set; }
        public ICommand clsClick { get; set; }
        public ICommand unselectClick { get; set; }
        #endregion
        
        [DoNotWire]
        public DzialkaList dzialkiBase { get; set; }

        public ICollectionView dzialkaView
        {
            get => CollectionViewSource.GetDefaultView( dzialkiBase.dzialkaList);
        }

        public Dzialka _dzialkaSel;
        public Dzialka dzialkaSel
        {
            get => _dzialkaSel;
            set
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

        public UserControl_PreviewViewModel(DzialkaList _dzialkiBase)
        {
            dzialkiBase = _dzialkiBase;

            initCommands();
            allowDelete = true;
        }

        #endregion

        #region Methods

        private void initCommands()
        {
            doubleClick = new RelayCommand(onDoubleClicked);
            leftClick = new RelayCommand(onLeftClick);
            clsClick = new RelayCommand(onClsClick);
            unselectClick = new RelayCommand(onUnSelectClick);
        }

        private void onUnSelectClick()
        {
            dzialkaSel = null;
        }

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
                dzialkiBase.deleteRow((IDzialka)dzialkaSel);
                dzialkaView.Refresh();
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

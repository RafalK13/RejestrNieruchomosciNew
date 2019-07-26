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
        private string _modeMessage;
        public Dzialka _dzialkaSel;
        #endregion

        public ICommand dubleClick { get; set; }
        public ICommand leftClick { get; set; }
        public ICommand clsClick { get; set; }

        public ICollectionView dzialkaView
        {
            get
            {
                return CollectionViewSource.GetDefaultView(dzialkaList);
            }
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
        #endregion

        #region Konstructor

        public UserControl_PreviewViewModel()
        {
            initDzialkaList();
            //var v = ServiceLocator.Current.GetInstance<MainViewModel>();
            //v.modeMessage = "Przeglądanie bazy";

            dubleClick = new RelayCommand(onDoubleClicked);
            leftClick = new RelayCommand(onLeftClick);
            clsClick = new RelayCommand(onClsClick);
            obreb = new ObrebClass();
        }

        #endregion

        #region Methods

        public void initDzialkaList()
        {
            Task task = Task.Run(() => fillDzialkaList());
            task.Wait();
        }

        private async Task fillDzialkaList()
        {
            using (var c = new Context())
            {
                dzialkaList = new List<Dzialka>(await c.Dzialka.Include(a => a.Obreb).ThenInclude(a => a.GminaSlo).ToListAsync());
            }
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
            MessageBox.Show(dzialkaSel.Numer);
        }

        //private void Obreb_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    setFilter();
        //}

        public void setFilter()
        {
            string s = String.Empty;

            dzialkaView.Filter = row =>
            {
                Dzialka d = row as Dzialka;

                bool nb = !string.IsNullOrEmpty( dzialkaNr) ? d.Numer.Contains(dzialkaNr) : true;
                bool ob = !string.IsNullOrEmpty(obreb.obrebValue) ? d.Obreb.Nazwa.Contains(obreb.obrebValue) : true;
                bool gb = !string.IsNullOrEmpty(obreb.gminaValue) ? d.Obreb.GminaSlo.Nazwa.Contains(obreb.gminaValue) : true;

                return nb && ob && gb;
            };
            result = dzialkaView.Cast<object>().Count().ToString();
        }


        //internal void clearResult()
        //{
        //    dzialkaNr = string.Empty;
        //    obreb.obrebValue = string.Empty;
        //    obreb.gminaValue = string.Empty;
        //}

        //public async Task initAllDzialka()
        //{
        //    using (var c = new Context())
        //    {
        //        dzialkaList = await c.Dzialka.Include(a => a.Obreb).ThenInclude(a => a.GminaSlo).ToListAsync();
        //    }
        //    result = dzialkaView.Cast<object>().Count().ToString();
        //}

        //public void refreshView()
        //{
        //    dzialkaList.Clear();
        //    //initAllDzialka();
        //    dzialkaView.Refresh();
        //}

        #endregion
    }

}

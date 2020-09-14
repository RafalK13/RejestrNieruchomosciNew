using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_PreviewViewModel : ViewModelBase
    {
        #region ICommand
        public ICommand doubleClick { get; set; }
        public ICommand leftClick { get; set; }
        public ICommand clsClick { get; set; }
        public ICommand unselectClick { get; set; }
        #endregion

        private int _selectedIndeks;
        public int selectedIndeks
        {
            get => _selectedIndeks;
            set
            {
                _selectedIndeks = value;
                RaisePropertyChanged();
            }
        }

        [DoNotWire]
        public IDzialkaList dzialkiList { get; set; }

        public ICollectionView dzialkaView
        {
            get => CollectionViewSource.GetDefaultView(dzialkiList.list);
        }

        public event EventHandler zmianaDzialkaSel;

        public IDzialka _dzialkaSel;
        public IDzialka dzialkaSel
        {
            get => _dzialkaSel;
            set
            {
                _dzialkaSel = value;
                RaisePropertyChanged("dzialkaSel");

                clearLists();

                if (zmianaDzialkaSel != null)
                    zmianaDzialkaSel(null, EventArgs.Empty);

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

        public IViewFactory factory { get; set; }

        #region Konstructor
        public UserControl_PreviewViewModel(IDzialkaList _dzialkiList)
        {
            dzialkiList = _dzialkiList;

            dzialkiList.zmianaDzialkiList += DzialkiBase_zmianaDzialkiList;

            initCommands();
            allowDelete = false;
        }

        private void DzialkiBase_zmianaDzialkiList(object sender, EventArgs e)
        {
            dzialkaView.Refresh();
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

        private void clearLists()
        {
            selectedIndeks = -1;
        }

        private void onUnSelectClick()
        {
            dzialkaSel = null;
            clearLists();
        }

        private void onClsClick()
        {
            dzialkaNr = String.Empty;
            obreb.clsObreb();
            clearLists();
        }

        private void onLeftClick()
        {
            setFilter();
        }

        //public void addDzialka(IDzialka dz)
        //{
        //    //dzialkiList.AddRow(dz);
        //    //dzialkaView.Refresh();
        //}

        public void onDoubleClicked()
        {
            if (allowDelete == true)
                deleteDzialka();
            else
            {
                if (dzialkaSel != null)
                {                  
                    var v = factory.CreateView<ChangeView>();
                    v.DataContext = factory.CreateView<IChangeViewModel>("Mod");
                    v.ShowDialog();
                }
            }
        }

        public void deleteDzialka()
        {
            if (dzialkaSel != null)
                if (dzialkaSel.Numer != null)
                {
                    dzialkiList.DelRow(dzialkaSel);
                    dzialkaView.Refresh();
                }
        }

        public void setFilter()
        {
            string s = String.Empty;

            clearLists();

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

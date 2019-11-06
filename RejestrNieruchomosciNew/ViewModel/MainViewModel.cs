using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public enum ChangeMode { add, mod}

    public class MainViewModel : ViewModelBase
    {
        #region Properties
        private bool _btActivity;
        public bool btActivity
        {
            get => _btActivity;
            set
            {
                _btActivity = value;
                RaisePropertyChanged("btActivity");
            }
        }

        public IViewFactory factory { get; set; }
        public ISelectorModel modelSel { get; set; }
        public IChangeViewModel model { get; set; }

        public UserControl_PreviewViewModel userControl_prev { get; set; }

        public ICommand addNewDzialka { get; set; }
        public ICommand delDzialka { get; set; }
        public ICommand modDzialka { get; set; }

        public string modeMessage { get; set; }

        public IPodmiotList podmiotList { get; set; }
        #endregion

        #region Konstruktor
        public MainViewModel()
        {
            modeMessage = "Przegl¹danie podstawowe";
            initButtonCommand();
            btActivity = true;
        }
        #endregion

        #region ButtonCommands
        private void initButtonCommand()
        {
            addNewDzialka = new RelayCommand(onAddNewDzialka);
            delDzialka = new RelayCommand(onDeleteDzialka);
            modDzialka = new RelayCommand(onModifyDzialka);
        }

        private void onModifyDzialka()
        {
            if (userControl_prev.dzialkaSel != null)
            {
                var v = factory.CreateView<ChangeView>();
                v.DataContext = factory.CreateView<IChangeViewModel>("Mod");
                v.Show();
            }
        }

        private void onAddNewDzialka()
        {
            var v = factory.CreateView<ChangeView>();
            v.DataContext = factory.CreateView<IChangeViewModel>("Add");
            v.Show();
        }
        private void onDeleteDzialka()
        {
            userControl_prev.deleteDzialka();
        }
        #endregion
    }
}
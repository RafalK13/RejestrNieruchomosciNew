using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using System;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
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

        public IPerson person { get; set; }

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

        public UserControl_PreviewViewModel userControl_prev { get; set; }

        public ICommand addNewDzialka { get; set; }
        public ICommand delDzialka { get; set; }
        public ICommand modDzialka { get; set; }

        //public IViewFactory viewFactory { get; set; }

        private string _modeMessage;
        public string modeMessage
        {
            get => _modeMessage; set
            {
                _modeMessage = value;
                RaisePropertyChanged("modeMessage");
            }
        }

        #endregion

        #region Konstruktor
        public MainViewModel()
        {
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
            userControl_prev.modDzialka();
        }

        private void onDeleteDzialka()
        {
            userControl_prev.deleteDzialka();
        }

        private void onAddNewDzialka()
        {
            userControl_prev.addDzialka();
        }

        #endregion
    }
}
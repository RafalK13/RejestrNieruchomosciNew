using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Installers;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using System;
using System.ComponentModel;
using System.Windows;
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
        
        //public AddView addView { get; set; }
        public UserControl_PreviewViewModel userControl_prev { get; set; }

        public ICommand addNewDzialka { get; set; }
        public ICommand delDzialka { get; set; }

        private IViewFactory viewFactory;

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
        public MainViewModel(IViewFactory _viewFactory)
        {
            viewFactory = _viewFactory;

            initButtonCommand();
            btActivity = true;
        }
        #endregion

        #region ButtonCommands
        private void initButtonCommand()
        {
            addNewDzialka = new RelayCommand(onAddNewDzialka);
            delDzialka = new RelayCommand(onDeleteDzialka);
        }

        private void onDeleteDzialka()
        {
            deleteDzialka();
        }

        public void deleteDzialka()
        {
            Dzialka dz = userControl_prev.dzialkaSel;

            userControl_prev.dzialkiBase.deleteRow((IDzialka)dz);
            userControl_prev.dzialkaView.Refresh();
        }

        private void onAddNewDzialka()
        {
            var factory = viewFactory.CreateView<AddView>();
            factory.Show();
           // var main = factory.CreateView<AddView>();
           // main.Show();

            //{
            //    btActivity = false;

            //    //addView.Show();

            //    var addView = container.Resolve<AddView>();
            //    addView.Show();
        }

        #endregion
    }
}
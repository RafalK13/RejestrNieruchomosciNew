using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        #region private Properties
        private string _modeMessage;
        #endregion

        public string modeMessage
        {
            get => _modeMessage;
            set
            {
                _modeMessage = value;
                RaisePropertyChanged("modeMessage");
            }
        }

        public ICommand OnCloseWindow { get; set; }
        public ICommand OnAddDzialka { get; set; }

        public DzialkaViewModel dzialkaViewModel { get; set; }

        #region Konstruktor
        public AddViewModel()
        {
            dzialkaViewModel = new DzialkaViewModel();
            modeMessage = "Dodawanie nowej działki";
            OnCloseWindow = new RelayCommand(onCloseWindow);
            OnAddDzialka = new RelayCommand(onAddDzialka);
        }
        #endregion

        #region Medods
        private async void onAddDzialka()
        {
            if (dzialkaViewModel.isNew == true)
            {
                using (var c = new Context())
                {
                    Dzialka dz = dzialkaViewModel.GetDzialka;
                    c.Dzialka.Add( dz);
                    c.SaveChanges();

                    var previewViewModel = ServiceLocator.Current.GetInstance<UserControl_PreviewViewModel>();
                    await previewViewModel.refillDzialkaList();
                    previewViewModel.dzialkaView.Refresh();
                }
            }
        }

        private void onCloseWindow()
        {
            #region obsługa messenger -REM
            //Messenger.Default.Send<MessagesRaf>( new MessagesRaf() { activity=true }, "Token1" );
            #endregion

            var v = ServiceLocator.Current.GetInstance<MainViewModel>();
            v.btActivity = true;
        }
        #endregion
    }
}

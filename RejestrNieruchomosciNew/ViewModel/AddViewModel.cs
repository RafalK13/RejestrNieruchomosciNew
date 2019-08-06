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

        public UserControl_Add_danePodstawoweViewModel userControl_AddDanePod { get; set; }

        #region Konstruktor
        public AddViewModel()
        {
            userControl_AddDanePod = new UserControl_Add_danePodstawoweViewModel();
            userControl_AddDanePod.dzialka.Numer = "DziałkaNUmer";
            modeMessage = "Dodawanie nowej działki";

            OnCloseWindow = new RelayCommand(onCloseWindow);
            OnAddDzialka = new RelayCommand(onAddDzialka);
        }
        #endregion

        #region Medods
        private void onAddDzialka()
        {
            //if (userControl_AddDanePod.isNew == true)
            {
                using (var c = new Context())
                {
                    c.Dzialka.Add(userControl_AddDanePod.dzialka);
                    c.SaveChanges();
                }
                var userControl_ViewModel = ServiceLocator.Current.GetInstance<UserControl_PreviewViewModel>();
                userControl_ViewModel.refillDzialkaList();
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

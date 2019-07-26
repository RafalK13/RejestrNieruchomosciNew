using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interactivity;

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

        private string _modeMessage;
        public string modeMessage
        {
            get => _modeMessage; set
            {
                _modeMessage = value;
                RaisePropertyChanged("modeMessage");
            }
        }

        public ICommand addNewDzialka { get; set; }
        #endregion

        #region Konstruktor
        public MainViewModel()
        {
            initButtonCommand();
            btActivity = true;
            modeMessage = "Przegl�danie dzia�ek";

            #region obs�uga messenger -REM
            //Messenger.Default.Register<MessagesRaf>( this, "Token1",  getMessage  );
            #endregion
        }
        #endregion

        #region methods
        #endregion

        #region ButtonCommands
        private void initButtonCommand()
        {
            addNewDzialka = new RelayCommand(onAddNewDzialka);
        }

        private void onAddNewDzialka()
        {
            btActivity = false;
            AddView addView = new AddView();
            addView.Show();
        }
        #endregion

        #region obs�uga messenger -REM
        //private void getMessage(MessagesRaf message)
        //{
        //    btActivity = message.activity;
        //}
        #endregion
    }
}
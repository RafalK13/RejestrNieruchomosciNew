using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using System;
using System.Collections.Generic;
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

        private List<Dzialka> _dzialkaList;
        public List<Dzialka> dzialkaList
        {
            get => _dzialkaList;
            set
            {
                _dzialkaList = value;
                RaisePropertyChanged("dzialkaList");
            }
        }

        public ICommand addNewDzialka { get; set; }
        public ICommand delDzialka { get; set; }
        #endregion

        #region Konstruktor
        public MainViewModel()
        {
            initDzialkaList();

            initButtonCommand();
            btActivity = true;
            modeMessage = "Przegl¹danie dzia³ek";

            #region obs³uga messenger -REM
            //Messenger.Default.Register<MessagesRaf>( this, "Token1",  getMessage  );
            #endregion
        }
        #endregion

        #region methods
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
            var v = ServiceLocator.Current.GetInstance<UserControl_PreviewViewModel>();
            Dzialka dz = v.dzialkaSel;

            using (var c = new Context())
            {
                c.Dzialka.Remove(dz);
                c.SaveChanges();

                v.refillDzialkaList();
            }
        }

        private void onAddNewDzialka()
        {
            btActivity = false;
            AddView addView = new AddView();
            addView.Show();
        }
        #endregion

        #region obs³uga messenger -REM
        //private void getMessage(MessagesRaf message)
        //{
        //    btActivity = message.activity;
        //}
        #endregion
    }
}
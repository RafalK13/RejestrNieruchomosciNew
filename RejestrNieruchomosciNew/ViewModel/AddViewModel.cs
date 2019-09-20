using Castle.Core;
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
        public DzialkaList dzialkaList { get; set; }

        private string _modeMessage;
        public string modeMessage
        {
            get => _modeMessage;
            set
            {
                _modeMessage = value;
                RaisePropertyChanged("modeMessage");
            }
        }

        #region ICommand
        public ICommand OnCloseWindow { get; set; }
        public ICommand OnAddDzialka { get; set; }
        #endregion

        public UserControl_Add_danePodstawoweViewModel userControl_AddDanePod { get; set; }

        public UserControl_PreviewViewModel userControl_PrevViewModel { get; set; }

        //public MainViewModel mainViewModel { get; set; }

        #region Konstruktor

        public AddViewModel()
        {
            modeMessage = "Dodawanie nowej działki";

            OnCloseWindow = new RelayCommand(onCloseWindow);
            OnAddDzialka = new RelayCommand(onAddDzialka);
        }
        #endregion


        #region initCommands
        private void onAddDzialka()
        {
            if (userControl_AddDanePod.isNew == true)
            {
                MessageBox.Show(userControl_PrevViewModel.dzialkiBase.dzialkaList.Count.ToString());

                userControl_PrevViewModel.dzialkiBase.AddRow((Dzialka)userControl_AddDanePod.dzialka);
                userControl_PrevViewModel.dzialkaView.Refresh();
            }
        }

        private void onCloseWindow()
        {

        }
        #endregion

    }
}

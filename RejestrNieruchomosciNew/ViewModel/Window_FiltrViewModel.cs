using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class Window_FiltrViewModel : ViewModelBase
    {
        public ICommand onCzysc { get; set; }

        public IFiltr filtr { get; set; }

        public FormaWladaniaList formaWladList { get; set; }
        public IPodmiotList podmiotList { get; set; }

        public Window_FiltrViewModel( )
        {
            onCzysc = new RelayCommand( ocCzyscClick);
        }

        private void ocCzyscClick()
        {
           filtr.czysc();
        }
    }
}

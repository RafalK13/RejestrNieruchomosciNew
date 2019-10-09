using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class ChangeViewModel : ViewModelBase
    {
        public UserControl_DanePodstawoweViewModel userControl_AddDanePod { get; set; }
        //public UserControl_PreviewViewModel userPrv { get; set; }

        public string modeMessage { get; set; }
      
        #region ICommand
        public ICommand OnCloseWindow { get; set; }
        public ICommand OnAddDzialka { get; set; }
        #endregion

        #region Konstruktor
        public ChangeViewModel()
        {
            MessageBox.Show("CHANGEViewModel - Konstruktor");

            OnCloseWindow = new RelayCommand(onCloseWindow);
            OnAddDzialka = new RelayCommand(onAddDzialka);
        }
        //public ChangeViewModel( UserControl_DanePodstawoweViewModel _userControl_AddDanePod)
        //{
        //    userControl_AddDanePod = _userControl_AddDanePod;

        //    OnCloseWindow = new RelayCommand(onCloseWindow);
        //    OnAddDzialka = new RelayCommand(onAddDzialka);
        //}

        public virtual void onAddDzialka()
        {
            MessageBox.Show("ChangeView");
        }

        public virtual void onCloseWindow()
        {

        }
        #endregion


    }
}

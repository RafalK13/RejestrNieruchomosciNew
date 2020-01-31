using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class ChangeViewModel : ViewModelBase, IChangeViewModel
    {
        [DoNotWire]
        public UserControl_DanePodstawoweViewModel userControl_AddDanePod { get; set; }
        public UserControl_WlascicielViewModel userControl_Wlasciciel { get; set; }
        public UserControl_PreviewViewModel userControl_prevModel { get; set; }
        public UserControl_InnePrawaViewModel userControl_InnePrawa { get; set; }
        public UserControl_PlatnoscUWViewModel userControl_PlatnoscUW { get; set; }
        public UserControl_DaneDodatkoweViewModel userControl_DaneDod { get; set; }

        public bool tabsVisible { get; set; }

        public string modeMessage { get; set; }
        
        #region ICommand
        public ICommand OnCloseWindow { get; set; }
        public ICommand OnAddDzialka { get; set; }
        #endregion

        #region Konstruktor
        public ChangeViewModel()
        {
            OnCloseWindow = new RelayCommand(onCloseWindow);
            OnAddDzialka = new RelayCommand(onAddDzialka);
        }
       
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

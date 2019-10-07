using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class ChangeViewModel : ViewModelBase
    {
        public string modeMessage { get; set; }

        public IPerson personAddViewModel { get; set; }

        public UserControl_Add_danePodstawoweViewModel userControl_AddDanePod { get; set; }
        public UserControl_PreviewViewModel userControl_PrevViewModel { get; set; }

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
            IDzialka dz = userControl_PrevViewModel.dzialkaSel;

            if (dz != null)
                MessageBox.Show(dz.Numer);
            else
                MessageBox.Show("Popraw");

        }

        public virtual void onCloseWindow()
        {

        }
        #endregion


    }
}

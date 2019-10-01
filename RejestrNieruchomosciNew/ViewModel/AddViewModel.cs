using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class AddViewModel : ViewModelBase
    {
        public string modeMessage { get; set; }

        public  IPerson personAddViewModel { get; set; }

        public UserControl_Add_danePodstawoweViewModel userControl_AddDanePod { get; set; }

        public UserControl_PreviewViewModel userControl_PrevViewModel { get; set; }
       
        #region ICommand
        public ICommand OnCloseWindow { get; set; }
        public ICommand OnAddDzialka { get; set; }
        #endregion

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
                if (userControl_AddDanePod.dzialka.procDz == ProcessDzialka.add)
                    userControl_PrevViewModel.dzialkiBase.AddRow((Dzialka)userControl_AddDanePod.dzialka);
                else
                {
                    userControl_PrevViewModel.dzialkiBase.ModRow((Dzialka)userControl_AddDanePod.dzialka);
                }

                userControl_PrevViewModel.dzialkaView.Refresh();
            }
        }

        private void onCloseWindow()
        {

        }
        #endregion
    }
}

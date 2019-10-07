using System.Windows;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class AddViewModel : ChangeViewModel
    {

        public AddViewModel()
        {
            modeMessage = "Dodawanie nowej działki";
        }
        #region initCommands
        public override void onAddDzialka()
        {

            MessageBox.Show("kliknięto Dodawanie");
            //if (userControl_AddDanePod.isNew == true)
            //{
            //    if (userControl_AddDanePod.dzialka.procDz == ProcessDzialka.add)
            //        userControl_PrevViewModel.dzialkiBase.AddRow((Dzialka)userControl_AddDanePod.dzialka);
            //    else
            //    {
            //        userControl_PrevViewModel.dzialkiBase.ModRow((Dzialka)userControl_AddDanePod.dzialka);
            //    }

            //    userControl_PrevViewModel.dzialkaView.Refresh();
            //}
        }

        public override void onCloseWindow()
        {

        }
        #endregion
    }
}

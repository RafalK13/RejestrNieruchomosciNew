using System.Windows;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class ModViewModel : ChangeViewModel
    {
        public ModViewModel()
        {
            modeMessage = "Modyfikacja danych";
        }

        public override void onAddDzialka()
        {
            MessageBox.Show("kliknięto Modyfikację");
        }

        public override void onCloseWindow()
        {

        }
    }
}

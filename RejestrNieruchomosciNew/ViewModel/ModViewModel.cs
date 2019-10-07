using RejestrNieruchomosciNew.Model;
using System.Windows;

namespace RejestrNieruchomosciNew.ViewModel 
{
    public class ModViewModel : ChangeViewModel, IChangeViewModel
    {
        private IDzialka _dzialka;
        public IDzialka dzialka
        {
            get => _dzialka;
            set
            {
                _dzialka = value;
                RaisePropertyChanged("dzialka");
            }
        }

        private ObrebClass _obreb;
        public ObrebClass obreb
        {
            get => _obreb; set
            {
                _obreb = value;

                RaisePropertyChanged("obreb");
                obreb.fillValues(dzialka.ObrebId);
            }
        }

        

        public ModViewModel()
        {
            modeMessage = "Modyfikacja danych";
        }

        public override void onAddDzialka()
        {
            MessageBox.Show(dzialka.Numer);
        }

        public override void onCloseWindow()
        {

        }
    }
}

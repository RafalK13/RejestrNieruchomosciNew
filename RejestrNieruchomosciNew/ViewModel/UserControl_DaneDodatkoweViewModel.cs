using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_DaneDodatkoweViewModel : ViewModelBase
    {
        public UserControl_PreviewViewModel userPrev { get; set; }

        public IUzytkiList uzytkiList { get; set; }

        public IUzytkiSloList uzytkiSloList { get; set; }

        public ICommand daneDodAdd { get; set; }

        public IDzialkaList dzialkaList { get; set; }

        public INadzorKonserwatoraSloList nadzorKons { get; set; }

        public UserControl_DaneDodatkoweViewModel( ) 
        {
            daneDodAdd = new RelayCommand( onDaneDodAdd);
        }

        private void onDaneDodAdd()
        {
            uzytkiList.saveUzytki();
            dzialkaList.ModRow(userPrev.dzialkaSel);
        }
    }
}

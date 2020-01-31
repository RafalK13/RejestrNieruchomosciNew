using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_DaneDodatkoweViewModel : ViewModelBase
    {
        public IUzytkiList uzytkiList { get; set; }
        public IUzytkiSloList uzytkiSloList { get; set; }

        public UserControl_DaneDodatkoweViewModel() 
        {
        }
    }
}

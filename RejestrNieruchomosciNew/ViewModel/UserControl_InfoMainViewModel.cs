using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using System.Windows;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InfoMainViewModel : ViewModelBase
    {
        public UserControl_InfoWladanieViewModel infoWlad { get; set; }

        public UserControl_InfoDanePodstViewModel infoPodst { get; set; }

        public UserControl_InfoMainViewModel()
        {
            
        }
    }
}

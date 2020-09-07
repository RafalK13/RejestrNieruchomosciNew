using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using System.Windows;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InfoMainViewModel : ViewModelBase
    {
        public UserControl_InfoWladanieViewModel infoWlad { get; set; }

        public UserControl_InfoInnePrawaViewModel infoInnePrawa { get; set; }

        public UserControl_InfoDanePodstViewModel infoPodst { get; set; }

        public UserControl_InfoDaneDodViewModel infoDod { get; set; }
            
        public UserControl_PreviewViewModel prevModel { get; set; }

        public UserControl_InfoPlatnoscUWViewModel infoPlat { get; set; }

        public UserControl_InfoZagospViewModel infoZagosp { get; set; }

        public UserControl_InfoBudynkiViewModel infoBudynek { get; set; }

        public UserControl_InfoMainViewModel()
        {
           
        }
    }
}

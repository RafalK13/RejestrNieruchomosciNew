using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class WindowTestRafViewModel : ViewModelBase
    {
        public IDzialkaList dzialkaList { get; set; }
        public ObservableCollection<IWladanie> wladanie { get; set; }

        public WindowTestRafViewModel(IWladanieList wladanieList )
        {
            wladanie = new ObservableCollection<IWladanie>( wladanieList.listAll);
        }
    }
}

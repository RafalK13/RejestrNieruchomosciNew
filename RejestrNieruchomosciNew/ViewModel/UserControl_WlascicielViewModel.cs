using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_WlascicielViewModel : ViewModelBase
    {
        

        private string _tekstCls;
        public string tekstCls
        {
            get => _tekstCls;
            set
            {
                _tekstCls = value;
                RaisePropertyChanged("tekstCls");
            }
        }

        public IWladanie wladanie { get; set; }

        public IWladanieList wladanieList { get; set; }

        public IPodmiotList podmiotList { get; set; }

        public ICommand wlascAdd { get; set; }

        private int dzialkaId;

        private WpfControlLibraryRaf.Podmiot _wlascSel;
        public WpfControlLibraryRaf.Podmiot wlascSel
        {
            get => _wlascSel;
            set
            {
                _wlascSel = value;
                RaisePropertyChanged("wlascSel");
            }
        }

        public UserControl_WlascicielViewModel(IDzialkaList dzList)
        {
            wlascAdd = new RelayCommand(onWlascAdd);
            dzialkaId = int.Parse( dzList.list.First(r => r.Numer.Contains("13") == true).DzialkaId.ToString());

           
        }

        private void onWlascAdd()
        {
            var v = wlascSel as WpfControlLibraryRaf.Podmiot;
            wladanie.PodmiodId = v.id;
            wladanieList.AddRow(wladanie);

            tekstCls = string.Empty;
        }
    }
}

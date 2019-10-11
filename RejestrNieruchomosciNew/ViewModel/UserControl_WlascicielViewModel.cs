using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_WlascicielViewModel : ViewModelBase
    {
        public IPodmiotList podmiotList { get; set; }

        public ICommand wlascAdd { get; set; }

        public UserControl_WlascicielViewModel()
        {
            wlascAdd = new RelayCommand( onWlascAdd);
        }
        private void onWlascAdd()
        {
            MessageBox.Show(podmiotList.list.Count.ToString());    
        }
    }
}

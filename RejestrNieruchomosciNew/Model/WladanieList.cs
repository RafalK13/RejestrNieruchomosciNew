using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model
{
    public class WladanieList : ViewModelBase, IWladanieList
    {
        public ObservableCollection<IWladanie> list { get; set; }
        
        public WladanieList()
        {
            list = new ObservableCollection<IWladanie>();
        }

        public void AddRow(IWladanie wlad)
        {
            list.Add(wlad);
        }
        public void DelRow(IWladanie wlad) { }
        public void ModRow(IWladanie wlad) { }
    }
}

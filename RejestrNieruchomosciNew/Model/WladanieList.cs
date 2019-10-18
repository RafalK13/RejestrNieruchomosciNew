using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model
{
    public class WladanieList : ViewModelBase, IWladanieList
    {
        public ObservableCollection<IWladanie> list { get; set; }
        
        public WladanieList()
        {
            //list = new ObservableCollection<IWladanie>();
            using (Context c = new Context())
            {
                list = new ObservableCollection<IWladanie>(c.Wladanie.Include( r=>r.Podmiot));
                int a = 13;
            }
        }

        public void AddRow(IWladanie wlad)
        {
            list.Add(wlad);
        }

        public void DelRow(IWladanie wlad) { }
        public void ModRow(IWladanie wlad) { }
    }
}

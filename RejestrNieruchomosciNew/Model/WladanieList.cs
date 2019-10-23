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
            using (Context c = new Context())
            {
                list = new ObservableCollection<IWladanie>(c.Wladanie.Include( r=>r.Podmiot));
            }
        }

        public void AddRow(IWladanie wlad)
        {
            list.Add( new Wladanie( wlad.DzialkaId, wlad.PodmiodId, wlad.Podmiot.Name));
        }

        public void DelRow(IWladanie wlad) { }
        public void ModRow(IWladanie wlad)
        {
            using (Context c = new Context())
            {

            }
        }
    }
}

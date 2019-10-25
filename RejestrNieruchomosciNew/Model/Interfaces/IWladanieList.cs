using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IWladanieList
    {
        ObservableCollection<IWladanie> list { get; set; }
        void AddRow(IWladanie wlad);
        void DelRow(IWladanie wlad);
        void ModRow(IWladanie wlad);

        void saveWladanie();
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IMiejscowoscSloList
    {
        ObservableCollection<IMiejscowoscSlo> listAll { get; set; }
        ObservableCollection<IMiejscowoscSlo> list { get; set; }

        void getList(IDzialka dzialkaSel);
        void getList(int gminaId);
        //event EventHandler listZmiana;
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    interface IBudynkiList
    {
        ObservableCollection<IBudynek> listAll { get; set; }
        ObservableCollection<IBudynek> list { get; set; }

        void saveBudynki();
        void getList(IDzialka dzialkaSel);
    }
}

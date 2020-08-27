using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface ILokalList
    {
        ObservableCollection<ILokal> listAll { get; set; }
        ObservableCollection<ILokal> list { get; set; }

        void saveLokale();
        void getList(IBudynek budSel);
    }
}

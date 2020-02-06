using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface ICelNabyciaList
    {
        ObservableCollection<ICelNabycia> list { get; set; }
        ObservableCollection<ICelNabycia> obIstnList { get; set; }
        ObservableCollection<ICelNabycia> obKomList { get; set; }
        ObservableCollection<ICelNabycia> zadInwestList { get; set; }
        ObservableCollection<ICelNabycia> CelKomList { get; set; }
    }
}

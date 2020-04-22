using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    interface IObrebClass //: IObrebList
    {
        ICollectionView gminaView { get; set; }
        ICollectionView obrebView { get; set; }

        string obrebValue { get; set; }
        string gminaValue { get; set; }

        Obreb getObreb();
    }
}

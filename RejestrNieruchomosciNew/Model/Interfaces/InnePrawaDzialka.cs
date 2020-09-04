using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public class InnePrawaDzialka : ViewModelBase
    {
        public ObservableCollection<IPodmiot> podmiotList { get; set; }

        public InnePrawaDzialka(IInnePrawaList innePrawaList
                                , UserControl_PreviewViewModel userPrev
                                , IPodmiotList _podmiotList
                                )
        {
            innePrawaList.getList(userPrev.dzialkaSel);
            podmiotList = new ObservableCollection<IPodmiot>(innePrawaList.list.Join(_podmiotList.list
                                                            , innePrawa => innePrawa.PodmiotId
                                                            , podmiot => podmiot.PodmiotId
                                                            , (innePrawa, podmiot) => new Podmiot { PodmiotId = innePrawa.PodmiotId, Name = podmiot.Name }
                                                            ));

        }

    }
}

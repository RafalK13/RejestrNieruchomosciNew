using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IKonserwPrzyrodySloList
    {
        ObservableCollection<IKonserwPrzyrodySlo> list { get; set; }
    }
}

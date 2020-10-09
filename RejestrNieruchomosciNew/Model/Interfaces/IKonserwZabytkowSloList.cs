using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IKonserwZabytkowSloList
    {
        ObservableCollection<IKonserwZabytkowSlo> list { get; set; }
    }
}

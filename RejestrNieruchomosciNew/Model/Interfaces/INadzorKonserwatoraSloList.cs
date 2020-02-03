using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface INadzorKonserwatoraSloList
    {
        ObservableCollection<INadzorKonserwSlo> list { get; set; }
    }
}

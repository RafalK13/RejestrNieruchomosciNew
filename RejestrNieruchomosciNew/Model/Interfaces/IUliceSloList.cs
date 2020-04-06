using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IUliceSloList
    {
        ObservableCollection<UliceSlo> listAll { get; set; }
        ObservableCollection<UliceSlo> list { get; set; }
    }
}

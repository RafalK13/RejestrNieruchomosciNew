using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IUzytkiList
    {
        ObservableCollection<Uzytki> list { get; set; }

        void saveUzytki();
    }
}

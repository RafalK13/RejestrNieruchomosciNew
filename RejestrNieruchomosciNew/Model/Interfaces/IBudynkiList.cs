using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IBudynkiList
    {
        ObservableCollection<IBudynek> listAll { get; set; }
        ObservableCollection<IBudynek> list { get; set; }

        void saveBudynki();
        void getList(IDzialka dzialkaSel);
    }
}

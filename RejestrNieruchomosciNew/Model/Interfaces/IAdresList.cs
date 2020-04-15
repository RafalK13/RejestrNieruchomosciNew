using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IAdresList
    {
        ObservableCollection<IAdres> listAll { get; set; }

        void save();
        IAdres getAdres(IDzialka dzialkaSel);
    }
}

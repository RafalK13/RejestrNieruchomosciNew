using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IZagospList
    {
        ObservableCollection<IZagosp> list { get; set; }

        void saveZagosp();
    }
}

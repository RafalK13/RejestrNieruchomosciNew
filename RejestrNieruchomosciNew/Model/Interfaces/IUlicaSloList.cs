using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IUlicaSloList
    {
        ObservableCollection<IUlicaSlo> listAll { get; set; }
        ObservableCollection<IUlicaSlo> list { get; set; }

        void getList(IMiejscowoscSlo miejscowosc);
    }
}

using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IDzialka_BudynekList
    {
        ObservableCollection<IDzialka_Budynek> listAll { get; set; }
        ObservableCollection<IDzialka_Budynek> list { get; set; }

        void save();
        void getList(IDzialka dzialkaSel);
    }
}

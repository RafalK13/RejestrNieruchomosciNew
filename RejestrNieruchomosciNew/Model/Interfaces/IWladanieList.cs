using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model
{
    public interface IWladanieList
    {
        ObservableCollection<IWladanie> list { get; set; }

        void saveWladanie();
    }
}

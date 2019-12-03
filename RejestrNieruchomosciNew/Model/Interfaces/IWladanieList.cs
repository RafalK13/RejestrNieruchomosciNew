using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model
{
    public interface IWladanieList
    {
        ObservableCollection<IWladanie> list { get; set; }
        void AddRow(IWladanie wlad);
        void DelRow(IWladanie wlad);
        void ModRow(IWladanie wlad);

        void saveWladanie();
    }
}

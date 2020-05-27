using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IAdresList
    {
        ObservableCollection<IAdres> listAll { get; set; }

        void save(IAdres adr);
        //IAdres getAdres(IDzialka dzialkaSel);

        void DelRow(IAdres adr);
        void AddRow(IAdres adr);
        void ModRow(IAdres adr);
    }
}

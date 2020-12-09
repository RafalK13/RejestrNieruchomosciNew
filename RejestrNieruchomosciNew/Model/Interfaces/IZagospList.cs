using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IZagospList
    {
        ObservableCollection<IZagosp> listAll { get; set; }
        ObservableCollection<IZagosp> list { get; set; }

        //void saveZagosp(IDzialka dz);
        void saveZagosp(Zagosp zagospLok);
        void getList(IDzialka dzialkaSel);
    }
}

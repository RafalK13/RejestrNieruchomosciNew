using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model
{
    public class UzytkiList : IUzytkiList
    {
        public ObservableCollection<Uzytki> list { get; set; }

        public UzytkiList()
        {
        //    list = new ObservableCollection<Uzytki>(){
        //    new  Uzytki() { UzytkiId = 2, DzialkaId = 2, UzytkiSloId = 2, Pow=  13.2 },
        //    new  Uzytki() { UzytkiId = 3, DzialkaId = 2, UzytkiSloId = 3, Pow = 13.2 },
        //    new  Uzytki() { UzytkiId = 4, DzialkaId = 2, UzytkiSloId = 4, Pow = 13.2 },
        //    new  Uzytki() { UzytkiId = 0, DzialkaId = 0, UzytkiSloId = 0, Pow = 13.2 }
        //};
        fillUzytkiList();
    }

    private void fillUzytkiList()
    {
        using (var c = new Context())
        {
            list = new ObservableCollection<Uzytki>(c.Uzytki);
        }
    }
}
}

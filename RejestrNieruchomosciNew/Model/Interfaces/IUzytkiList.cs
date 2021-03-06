﻿using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IUzytkiList
    {
        ObservableCollection<Uzytki> listAll { get; set; }
        ObservableCollection<Uzytki> list { get; set; }

        void saveUzytki();
        void getList(IDzialka dzialkaSel);
    }
}

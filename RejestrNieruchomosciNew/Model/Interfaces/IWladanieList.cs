﻿using System;
using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model
{
    public interface IWladanieList
    {
        ObservableCollection<IWladanie> listAll { get; set; }
        ObservableCollection<IWladanie> list { get; set; }

        void saveWladanie();
        void getList(IDzialka dzialkaSel);
    }
}

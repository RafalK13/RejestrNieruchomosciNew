﻿using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface IInnePrawaList
    {
        ObservableCollection<IInnePrawa> list { get; set; }

        void saveWladanie();
    }
}
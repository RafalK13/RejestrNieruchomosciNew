﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface ITransakcjeList
    {
        ObservableCollection<ITransakcje> list { get; set; }
    }
}

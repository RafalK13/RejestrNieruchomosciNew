﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface INazwaCzynosciSlo
    {
        int NazwaCzynnosciSloId { get; set; }
        string Nazwa { get; set; }
    }
}

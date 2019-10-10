﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IPodmiot
    {
        int Id { get; set; }
        string Name { get; set; }
        string PostCode { get; set; }
        string City { get; set; }
        string Street { get; set; }
        string House { get; set; }
    }
}
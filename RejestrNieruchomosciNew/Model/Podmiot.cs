﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class Podmiot : IPodmiot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
    }
}

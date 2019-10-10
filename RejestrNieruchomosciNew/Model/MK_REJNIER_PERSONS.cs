using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class MK_REJNIER_PERSONS : IPodmiot
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string House { get; set; }

        public Wladanie Wladanie { get; set; }
    }
}

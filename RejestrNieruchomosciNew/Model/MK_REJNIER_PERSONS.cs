using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew
{
    public partial class MK_REJNIER_PERSONS : IPodmiot
    {
        //public int Id { get; set; }
        //public string Name { get; set;}
        //public string PostCode { get; set; }
        //public string City { get; set; }
        //public string Street { get; set; }
        //public string House { get; set; }

        //public Wladanie Wladanie { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }
        public string Fax { get; set; }
        public string Kontakt { get; set; }
        public string TaxNumber { get; set; }
        public string House { get; set; }
        public string Country { get; set; }
    }
}

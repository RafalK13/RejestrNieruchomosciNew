using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public interface IPodmiot
    {
        int PodmiotId { get; set; }
        string Name { get; set; }
        //string PostCode { get; set; }
        //string City { get; set; }
        //string Street { get; set; }
        //string House { get; set; }

        //ICollection<Lokal_Podmiot> Lokal_Podmiot { get; set; }


    }
}

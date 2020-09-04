using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RejestrNieruchomosciNew.Model.Interfaces
{
    public interface ILokal
    {
         int LokalId { get; set; }
         
         string Numer { get; set; }
         double? pow { get; set; }
         double? powPomPrzyn { get; set; }
         string opis { get; set; }
         string kondygnacja { get; set; }
         string KWlok { get; set; }
         int NajemcaId { get; set; }

         int? BudynekId { get; set; }
         Budynek Budynek { get; set; }

         ObservableCollection<Lokal_Podmiot> Lokal_Podmiot { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using RejestrNieruchomosciNew.Model.Interfaces;

namespace RejestrNieruchomosciNew.Model
{
    public class Transakcje : ITransakcje
    {
        public int TransakcjeId { get; set; }
        public int? RodzajTransakcjiId { get; set; }
        public int? RodzajCzynnosciId { get; set; }
        public int? RodzajDokumentuId { get; set; }
        public string Numer { get; set; }
        public DateTime? Data { get; set; }
        public string Tytul { get; set; }
        public string Skan { get; set; }

        [ForeignKey("TransK_Id")]
        public ICollection<Wladanie> Wladanie1 { get; set; }
        [ForeignKey("TransS_Id")]
        public ICollection<Wladanie> Wladanie2 { get; set; }
    }
}

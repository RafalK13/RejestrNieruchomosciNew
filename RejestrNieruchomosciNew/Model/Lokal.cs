using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class Lokal : ILokal
    {
        public int LokalId { get; set; }

        public string Numer { get; set; }
        public double? pow { get; set; }
        public double? powPomPrzyn { get; set; }
        public string opis { get; set; }
        public string kondygnacja { get; set; }
        public string KWlok { get; set; }
        public int NajemcaId { get; set; }

        public int? BudynekId { get; set; }
        public Budynek Budynek { get; set; }

        public ObservableCollection<Lokal_Podmiot> Lokal_Podmiot { get; set; }

        public string ZalPath
        {
            get
            {
                int DzialkaId;
                string BudynekNazwa;

                var result = Budynek?.Dzialka_Budynek?.FirstOrDefault();

                if (result == null)
                    return null;
                
                DzialkaId = result.DzialkaId;
                BudynekNazwa = result.Budynek?.Nazwa;

                if(BudynekNazwa == null)
                    return null;

                if(Numer == null)
                    return null;

                return ConfigurationManager.AppSettings["zalacznikPath"] + "\\Dzialka\\" + DzialkaId + "\\Budynek\\" + BudynekNazwa + "\\Lokal\\" + Numer;
            }
        }

        public Lokal()
        {

        }

        public Lokal(Lokal lok)
        {
            LokalId = lok.LokalId;
            Numer = lok.Numer;
            pow = lok.pow;
            powPomPrzyn = lok.powPomPrzyn;
            opis = lok.opis;
            kondygnacja = lok.kondygnacja;
            KWlok = lok.KWlok;
            NajemcaId = lok.NajemcaId;
            BudynekId = lok.BudynekId;
            Budynek = lok.Budynek;
        }

        public override bool Equals(object other)
        {
            ILokal obj = other as ILokal;

            if (obj == null)
                return false;

            return object.Equals( Numer, obj.Numer) &&
                   LokalId == obj.LokalId &&
                   BudynekId == obj.BudynekId;
            //return Numer.Equals(obj.Numer);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                //const int HashingBase = (int)2166;
                //const int HashingMultiplier = 1677;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (LokalId.GetHashCode());
                hash = (hash * HashingMultiplier) ^ (BudynekId.GetHashCode());
                hash = (hash * HashingMultiplier) ^ (object.ReferenceEquals(null, Numer) ? 0 : Numer.GetHashCode());
                return hash;
            }

        }
    }
}

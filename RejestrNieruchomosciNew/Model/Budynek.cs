using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public class Budynek : IBudynek
    {
        public int BudynekId { get; set; }
        public int DzialkaId { get; set; }

        public string Nazwa { get; set; }
        public double powBezPiwnic { get; set; }
        public double powPiwnic { get; set; }
        public double powCalk { get; set; }
        public double powZabud { get; set; }
        public double kubatura { get; set; }
        public int iloscKond { get; set; }
        public double numerEwid { get; set; }
        public bool wpisRejZab { get; set; }
        public int MediaId { get; set; }
        public string stanTech { get; set; }

        public ICollection<Dzialka_Budynek> Dzialka_Budynek { get; set; }

        public Budynek()
        {

        }

        public Budynek(IBudynek budynek)
        {
            int BudynekId = budynek.BudynekId;
            int DzialkaId = budynek.DzialkaId;

            string Nazwa = budynek.Nazwa;
 
            double powBezPiwnic = budynek.powBezPiwnic;
            double powPiwnic = budynek.powPiwnic;
            double powCalk = budynek.powCalk;
            double powZabud = budynek.powZabud;
            double kubatura = budynek.kubatura;
            int iloscKond = budynek.iloscKond;
            double numerEwid = budynek.numerEwid;
            bool wpisRejZab = budynek.wpisRejZab;
            int MediaId = budynek.MediaId;
            string stanTech = budynek.stanTech;
    }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public bool Equals(IBudynek other)
        {
            return BudynekId.Equals(other.BudynekId) &&
                   DzialkaId.Equals(other.DzialkaId) &&
                   string.Equals(Nazwa, other.Nazwa) &&
                   powBezPiwnic.Equals(other.powBezPiwnic) &&
                   powPiwnic.Equals(other.powPiwnic) &&
                   powCalk.Equals(other.powCalk) &&
                   powZabud.Equals(other.powZabud) &&                  
                   kubatura.Equals(other.kubatura) &&
                   iloscKond.Equals(other.iloscKond) &&
                   numerEwid.Equals(other.numerEwid) &&
                   wpisRejZab.Equals(other.wpisRejZab) &&
                   MediaId.Equals(other.MediaId) &&
                   string.Equals(stanTech, other.stanTech);
        }
    }
}

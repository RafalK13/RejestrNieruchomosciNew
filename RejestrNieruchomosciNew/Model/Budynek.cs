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
             BudynekId = budynek.BudynekId;
             DzialkaId = budynek.DzialkaId;

             Nazwa = budynek.Nazwa;
 
             powBezPiwnic = budynek.powBezPiwnic;
             powPiwnic = budynek.powPiwnic;
             powCalk = budynek.powCalk;
             powZabud = budynek.powZabud;
             kubatura = budynek.kubatura;
             iloscKond = budynek.iloscKond;
             numerEwid = budynek.numerEwid;
             wpisRejZab = budynek.wpisRejZab;
             MediaId = budynek.MediaId;
             stanTech = budynek.stanTech;
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

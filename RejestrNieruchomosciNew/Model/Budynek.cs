using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace RejestrNieruchomosciNew.Model
{
    public class Budynek : IBudynek
    {
        public int BudynekId { get; set; }

        public string Nazwa { get; set; }

        public int AdresId { get; set; }

        public double powBezPiwnic { get; set; }
        public double powZPiwnic { get; set; }
        public double powCalk { get; set; }
        public double powZabud { get; set; }
        public double kubatura { get; set; }

        public int iloscKond { get; set; }
        public double numerEwid { get; set; }
        public bool wpisRejZab { get; set; }

        public bool prad { get; set; }
        public bool woda { get; set; }
        public bool kanSan { get; set; }
        public bool kanLok { get; set; }
        public bool kanDeszcz { get; set; }
        public bool tel { get; set; }
        public bool co { get; set; }
        public bool gaz { get; set; }
        public bool internet { get; set; }
        public bool tv { get; set; }

        public string opisKonstr { get; set; }
        public string stanTech { get; set; }

        public ICollection<Dzialka_Budynek> Dzialka_Budynek { get; set; }
        public Adres Adres { get; set; }

        public Budynek()
        {

        }

        public Budynek(IBudynek budynek)
        {
             BudynekId = budynek.BudynekId;

             Nazwa = budynek.Nazwa;
 
             powBezPiwnic = budynek.powBezPiwnic;
             powZPiwnic = budynek.powZPiwnic;
             powCalk = budynek.powCalk;
             powZabud = budynek.powZabud;
             kubatura = budynek.kubatura;
             iloscKond = budynek.iloscKond;
             numerEwid = budynek.numerEwid;
             wpisRejZab = budynek.wpisRejZab;

            prad = budynek.prad;
            woda = budynek.woda;
            kanSan = budynek.kanSan;
            kanLok = budynek.kanLok;
            kanDeszcz = budynek.kanDeszcz;
            tel = budynek.tel;
            co = budynek.co;
            gaz = budynek.gaz;
            internet = budynek.internet;
            tv = budynek.tv;

            opisKonstr = budynek.opisKonstr;
            stanTech = budynek.stanTech;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public bool Equals(IBudynek other)
        {
            return BudynekId.Equals(other.BudynekId) &&
                   
                   string.Equals(Nazwa, other.Nazwa) &&
                   powBezPiwnic.Equals(other.powBezPiwnic) &&
                   powZPiwnic.Equals(other.powZPiwnic) &&
                   powCalk.Equals(other.powCalk) &&
                   powZabud.Equals(other.powZabud) &&                  
                   kubatura.Equals(other.kubatura) &&
                   iloscKond.Equals(other.iloscKond) &&
                   numerEwid.Equals(other.numerEwid) &&
                   wpisRejZab.Equals(other.wpisRejZab) &&

                   prad.Equals(other.prad) &&
                   woda.Equals(other.woda) &&
                   kanSan.Equals(other.kanSan) &&
                   kanLok.Equals(other.kanLok) &&
                   kanDeszcz.Equals(other.kanDeszcz) &&
                   tel.Equals(other.tel) &&
                   co.Equals(other.co) &&
                   gaz.Equals(other.gaz) &&
                   internet.Equals(other.internet) &&
                   tv.Equals(other.tv) &&
                   
                   string.Equals(opisKonstr, other.opisKonstr) &&
                   string.Equals(stanTech, other.stanTech);
        }
    }
}

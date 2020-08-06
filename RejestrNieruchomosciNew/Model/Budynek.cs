using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RejestrNieruchomosciNew.Model
{
    public class Budynek : IBudynek
    {
        public int BudynekId { get; set; }

        public string Nazwa { get; set; }

        public int powBezPiwnic { get; set; }
        public int powZPiwnic { get; set; }
        public int powCalk { get; set; }
        public int powZabud { get; set; }
        public int kubatura { get; set; }

        public int iloscKond { get; set; }
        public string numerEwid { get; set; }
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

            Adres = budynek.Adres;

            Dzialka_Budynek = budynek.Dzialka_Budynek;
        }

        public object Clone()
        {
            Budynek bud = (Budynek)this.MemberwiseClone();
            if (bud.Adres != null)
                bud.Adres = (Adres)Adres.Clone(Adres);

            if (bud.Dzialka_Budynek != null)
                bud.Dzialka_Budynek = Dzialka_Budynek.Select(r => (Dzialka_Budynek)r.Clone()).ToList();

            return bud;
        }

        public override bool Equals(Object other)
        {
            IBudynek obj = other as IBudynek;

            if (obj == null)
                return false;

            return BudynekId.Equals(obj.BudynekId) &&

                   string.Equals(Nazwa, obj.Nazwa) &&
                   powBezPiwnic.Equals(obj.powBezPiwnic) &&
                   powZPiwnic.Equals(obj.powZPiwnic) &&
                   powCalk.Equals(obj.powCalk) &&
                   powZabud.Equals(obj.powZabud) &&
                   kubatura.Equals(obj.kubatura) &&
                   iloscKond.Equals(obj.iloscKond) &&
                   string.Equals(numerEwid, obj.numerEwid) &&
                   wpisRejZab.Equals(obj.wpisRejZab) &&

                   prad.Equals(obj.prad) &&
                   woda.Equals(obj.woda) &&
                   kanSan.Equals(obj.kanSan) &&
                   kanLok.Equals(obj.kanLok) &&
                   kanDeszcz.Equals(obj.kanDeszcz) &&
                   tel.Equals(obj.tel) &&
                   co.Equals(obj.co) &&
                   gaz.Equals(obj.gaz) &&
                   internet.Equals(obj.internet) &&
                   tv.Equals(obj.tv) &&

                   string.Equals(opisKonstr, obj.opisKonstr) &&
                   string.Equals(stanTech, obj.stanTech) &&

                   (object.ReferenceEquals(Adres, obj.Adres) || Adres != null && Adres.Equals(obj.Adres));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ ( BudynekId.GetHashCode() );
                hash = (hash * HashingMultiplier) ^ ( Object.ReferenceEquals(null, Nazwa) ? 0: Nazwa.GetHashCode());

                int a = 12;
                return hash;
            }
        }
    }
}

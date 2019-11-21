using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew
{
    public partial class PlatnoscUW : IPlatnoscUW
    {
        public int PlatnoscUWId { get; set; }
        public int? DzialkaId { get; set; }
        public double? Stawka { get; set; }
        public int? Okres { get; set; }
        public double? Wartosc { get; set; }
        public double? Wysokosc { get; set; }

        public int? rok1 { get; set; }
        public int? rok2 { get; set; }
        public int? rok3 { get; set; }

        public Dzialka Dzialka { get; set; }

        public PlatnoscUW() { }

        public PlatnoscUW(UserControl_PreviewViewModel prev)
        {
            using (Context c = new Context())
            {
                var p = c.PlatnoscUW.FirstOrDefault(row => row.DzialkaId == prev.dzialkaSel.DzialkaId);
                if (p != null)
                {
                    PlatnoscUWId = p.PlatnoscUWId;
                    DzialkaId = p.DzialkaId;
                    Stawka = p.Stawka;
                    Okres = p.Okres;
                    Wartosc = p.Wartosc;
                    Wysokosc = p.Wysokosc;

                    rok1 = p.rok1;
                    rok2 = p.rok2;
                    rok3 = p.rok3;
                }
                else
                    DzialkaId = prev.dzialkaSel.DzialkaId;
            }
        }

        private bool isEqual(IPlatnoscUW p)
        {
            return this.Stawka == Stawka &&
                   this.Okres == Okres &&
                   this.Wartosc == Wartosc &&
                   this.Wysokosc == Wysokosc &&
                   this.rok1 == rok1 &&
                   this.rok2 == rok2 &&
                   this.rok3 == rok3;
        }

        public IPlatnoscUW clone()
        {


            return (IPlatnoscUW)this.MemberwiseClone();
        }

        public bool isNull()
        {
            return ( Stawka == null || Stawka.Value == 0) &&
                   ( Okres == null || Okres.Value == 0) &&
                   ( Wartosc == null || Wartosc.Value == 0) &&
                   ( Wysokosc == null || Wysokosc.Value == 0) &&
                   ( rok1 == null || rok1.Value == 0) &&
                   ( rok2 == null || rok2.Value == 0) &&
                   ( rok3 == null || rok3.Value ==0);
        }

        public void save()
        {
            if (PlatnoscUWId == 0)
            {
                if( isNull() == false)
                    addRow(this);
            }
            else
            {
                using (Context c = new Context())
                {
                    if (isNull())
                    {
                        c.PlatnoscUW.Remove( this);
                        c.SaveChanges();
                    }
                    else
                    {
                        var v = c.PlatnoscUW.FirstOrDefault(row => row.PlatnoscUWId == PlatnoscUWId);
                        
                        if ( v != null)
                        {
                            c.Entry(v).CurrentValues.SetValues(this);
                            c.SaveChanges();
                        }
                    }
                }
            }
        }

        private void addRow(IPlatnoscUW platnoscUW)
        {
            using (Context c = new Context())
            {
                c.PlatnoscUW.Add((PlatnoscUW)platnoscUW);
                c.SaveChanges();
            }
        }

        private void modRow(IPlatnoscUW platnoscUW)
        {
            using (Context c = new Context())
            {
                c.PlatnoscUW.Update((PlatnoscUW)platnoscUW);
                c.SaveChanges();
            }
        }

        private void delRow(IPlatnoscUW platnoscUW)
        {
            using (Context c = new Context())
            {
                c.PlatnoscUW.Remove((PlatnoscUW)platnoscUW);
                c.SaveChanges();
            }
        }
    }
}

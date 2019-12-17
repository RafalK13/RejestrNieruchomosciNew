using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew
{
    public partial class PlatnoscUW : ViewModelBase, IPlatnosc
    {
        public int PlatnoscUWId { get; set; }
        
        private double? _Stawka;
        public double? Stawka
        {
            get => _Stawka; set
            {
                _Stawka = value;
                RaisePropertyChanged("Stawka");
            }
        }

        private int? _Okres;
        public int? Okres
        {
            get => _Okres;
            set
            {
                _Okres = value;
                RaisePropertyChanged("Okres");
            }
        }

        private double? _Wartosc;
        public double? Wartosc
        {
            get => _Wartosc;
            set
            {
                _Wartosc = value;
                RaisePropertyChanged("Wartosc");
            }
        }
        private double? _Wysokosc;
        public double? Wysokosc
        {
            get => _Wysokosc;
            set
            {
                _Wysokosc = value;
                RaisePropertyChanged("Wysokosc");
            }
        }

        public int? _rok1;
        public int? rok1
        {
            get => _rok1;
            set
            {
                _rok1 = value;
                RaisePropertyChanged("rok1");
            }
        }
        public int? _rok2;
        public int? rok2
        {
            get => _rok2;
            set
            {
                _rok2 = value;
                RaisePropertyChanged("rok2");
            }
        }
        private int? _rok3;
        public int? rok3
        {
            get => _rok3;
            set
            {
                _rok3 = value;
                RaisePropertyChanged("rok3");
            }
        }

        public int? DzialkaId { get; set; }
        public Dzialka Dzialka { get; set; }

        public PlatnoscUW() { }

        public void save(PlatnoscUW p)
        {
            using (var c = new Context())
            {
                c.PlatnoscUW.Update(p);
                c.SaveChanges();
            }
        }

        //public PlatnoscUW(Dzialka d)
        //{
        //    if (d != null)
        //    {
        //        using (Context c = new Context())
        //        {
        //            var p = c.PlatnoscUW.FirstOrDefault(row => row.DzialkaId == d.DzialkaId);
        //            if (p != null)
        //            {
        //                PlatnoscUWId = p.PlatnoscUWId;
        //                DzialkaId = p.DzialkaId;
        //                Stawka = p.Stawka;
        //                Okres = p.Okres;
        //                Wartosc = p.Wartosc;
        //                Wysokosc = p.Wysokosc;

        //                rok1 = p.rok1;
        //                rok2 = p.rok2;
        //                rok3 = p.rok3;
        //            }
        //        }
        //    }
        //}

        //public PlatnoscUW(UserControl_PreviewViewModel prev)
        //{
        //    if (prev.dzialkaSel != null)
        //    {
        //        using (Context c = new Context())
        //        {
        //            var p = c.PlatnoscUW.FirstOrDefault(row => row.DzialkaId == prev.dzialkaSel.DzialkaId);
        //            if (p != null)
        //            {
        //                PlatnoscUWId = p.PlatnoscUWId;
        //                DzialkaId = p.DzialkaId;
        //                Stawka = p.Stawka;
        //                Okres = p.Okres;
        //                Wartosc = p.Wartosc;
        //                Wysokosc = p.Wysokosc;

        //                rok1 = p.rok1;
        //                rok2 = p.rok2;
        //                rok3 = p.rok3;
        //            }
        //            else
        //                DzialkaId = prev.dzialkaSel.DzialkaId;

        //        }
        //    }
        //}

        private bool isEqual(PlatnoscUW p)
        {
            return this.Stawka == Stawka &&
                   this.Okres == Okres &&
                   this.Wartosc == Wartosc &&
                   this.Wysokosc == Wysokosc &&
                   this.rok1 == rok1 &&
                   this.rok2 == rok2 &&
                   this.rok3 == rok3;
        }

        public PlatnoscUW clone()
        {
            return (PlatnoscUW)this.MemberwiseClone();
        }

        public void cleanObj()
        {
            //this.DzialkaId = null;
            this.Okres = null;
            this.rok1 = null;
            this.rok2 = null;
            this.rok3 = null;
            this.Stawka = null;
            this.Wartosc = null;
            this.Wysokosc = null;
        }

        public bool isNull()
        {
            return (Stawka == null || Stawka.Value == 0) &&
                   (Okres == null || Okres.Value == 0) &&
                   (Wartosc == null || Wartosc.Value == 0) &&
                   (Wysokosc == null || Wysokosc.Value == 0) &&
                   (rok1 == null || rok1.Value == 0) &&
                   (rok2 == null || rok2.Value == 0) &&
                   (rok3 == null || rok3.Value == 0);
        }

        //public void save()
        //{
        //    if (PlatnoscUWId == 0)
        //    {
        //        if (isNull() == false)
        //            addRow(this);
        //    }
        //    else
        //    {
        //        using (Context c = new Context())
        //        {
        //            if (isNull())
        //            {
        //                //c.PlatnoscUW.Remove(this);
        //                //c.SaveChanges();
        //            }
        //            else
        //            {
        //                var v = c.PlatnoscUW.FirstOrDefault(row => row.PlatnoscUWId == PlatnoscUWId);

        //                if (v != null)
        //                {
        //                    c.Entry(v).CurrentValues.SetValues(this);
        //                    c.SaveChanges();
        //                }
        //            }
        //        }
        //    }
        //}

    //    private void addRow(PlatnoscUW platnoscUW)
    //    {
    //        using (Context c = new Context())
    //        {
    //            c.PlatnoscUW.Add((PlatnoscUW)platnoscUW);
    //            c.SaveChanges();
    //        }
    //    }

    //    private void modRow(PlatnoscUW platnoscUW)
    //    {
    //        using (Context c = new Context())
    //        {
    //            c.PlatnoscUW.Update((PlatnoscUW)platnoscUW);
    //            c.SaveChanges();
    //        }
    //    }

    //    private void delRow(PlatnoscUW platnoscUW)
    //    {
    //        using (Context c = new Context())
    //        {
    //            c.PlatnoscUW.Remove((PlatnoscUW)platnoscUW);
    //            c.SaveChanges();
    //        }
    //    }
    }
}

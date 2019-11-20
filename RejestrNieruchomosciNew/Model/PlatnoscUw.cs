using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
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

        public int rok1 { get; set; }
        public int rok2 { get; set; }
        public int rok3 { get; set; }

        public Dzialka Dzialka { get; set; }

        public PlatnoscUW()
        {
            MessageBox.Show("Konstruktor  PlatnosciUW");
        }

        public PlatnoscUW( IDzialka dz)
        {
            MessageBox.Show("{PlatUW: " + dz.Numer);
        }
    }
}

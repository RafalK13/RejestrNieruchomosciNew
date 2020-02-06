﻿using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class CelNabyciaList : ViewModelBase, ICelNabyciaList
    {
        public ObservableCollection<ICelNabycia> list { get; set; }

        public ObservableCollection<ICelNabycia> obIstnList { get; set; }
        public ObservableCollection<ICelNabycia> obKomList { get; set; }
        public ObservableCollection<ICelNabycia> zadInwestList { get; set; }
        public ObservableCollection<ICelNabycia> CelKomList { get; set; }

        public CelNabyciaList()
        {
            using (var c = new Context())
            {
                list = new ObservableCollection<ICelNabycia>(c.CelNabyciaView);
            }

            obIstnList = new ObservableCollection<ICelNabycia>( list.Where( r=>r.Rodzaj == "Obiekt"));
            obKomList = new ObservableCollection<ICelNabycia>(list.Where(r => r.Rodzaj == "ObKom"));
            zadInwestList = new ObservableCollection<ICelNabycia>(list.Where(r => r.Rodzaj == "Zadanie"));
            CelKomList = new ObservableCollection<ICelNabycia>(list.Where(r => r.Rodzaj == "Cel"));
        }
    }
}

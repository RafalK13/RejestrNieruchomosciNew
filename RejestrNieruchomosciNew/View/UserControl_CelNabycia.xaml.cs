using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_CelNabycia : UserControl
    {
        public UserControl_CelNabycia()
        {
            InitializeComponent();
            DataContext = this;

            onCzysc = new RelayCommand( onCzyscClick);
        }

        #region Command

        public ICommand onCzysc { get; set; }

        private void onCzyscClick()
        {
            selectedName = string.Empty;
            selectedId = null;
        }

        #endregion

        #region Names
        public string selectedName
        {
            get { return (string)GetValue(selectedNameProperty); }
            set { SetValue(selectedNameProperty, value); }
        }

        public static readonly DependencyProperty selectedNameProperty =
            DependencyProperty.Register("selectedName", typeof(string), typeof(UserControl_CelNabycia));
        
        public string istObName
        {
            get { return (string)GetValue(istObNameProperty); }
            set { SetValue(istObNameProperty, value); }
        }

        public static readonly DependencyProperty istObNameProperty =
            DependencyProperty.Register("istObName", typeof(string), typeof(UserControl_CelNabycia), new PropertyMetadata(onChangeIstOb));

        private static void onChangeIstOb(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //UserControl_CelNabycia u = d as UserControl_CelNabycia;
            //u.zadInwestName = string.Empty;
            //u.obiektKomName = string.Empty;

            //u.selectedName = u.istObName;
            //u.selectedId = u.istnObSelId;
        }

        public string zadInwestName
        {
            get { return (string)GetValue(zadInwestNameProperty); }
            set { SetValue(zadInwestNameProperty, value); }
        }

        public static readonly DependencyProperty zadInwestNameProperty =
            DependencyProperty.Register("zadInwestName", typeof(string), typeof(UserControl_CelNabycia), new PropertyMetadata(onChangeZadInwest));

        private static void onChangeZadInwest(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //UserControl_CelNabycia u = d as UserControl_CelNabycia;
            //u.istObName = string.Empty;
            //u.obiektKomName = string.Empty;

            //u.selectedName = u.zadInwestName;
            //u.selectedId = u.zadInwestSelId;
        }

        public string obiektKomName
        {
            get { return (string)GetValue(obiektKomNameProperty); }
            set { SetValue(obiektKomNameProperty, value); }
        }

        public static readonly DependencyProperty obiektKomNameProperty =
            DependencyProperty.Register("obiektKomName", typeof(string), typeof(UserControl_CelNabycia), new PropertyMetadata(onChangeObiektKom));

        private static void onChangeObiektKom(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //UserControl_CelNabycia u = d as UserControl_CelNabycia;
            //u.istObName = string.Empty;
            //u.zadInwestName = string.Empty;

            //u.selectedName = u.obiektKomName;
            //u.selectedId = u.obiektKomSelId;
        }

        #endregion

        #region SelectedId

        public int? selectedId
        {
            get { return (int?)GetValue(selectedIdProperty); }
            set { SetValue(selectedIdProperty, value); }
        }

        public static readonly DependencyProperty selectedIdProperty =
            DependencyProperty.Register("selectedId", typeof(int?), typeof(UserControl_CelNabycia), new PropertyMetadata(onChangedSelectedId));

        private static void onChangedSelectedId(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_CelNabycia u = d as UserControl_CelNabycia;
            var v = u.celNabyciaList.list.FirstOrDefault(row => row.Id == u.selectedId);
            if (v != null)
                u.selectedName = v.Nazwa;
            else
                u.selectedName = string.Empty;
        }

        public int istnObSelId
        {
            get { return (int)GetValue(istnObSelIdProperty); }
            set { SetValue(istnObSelIdProperty, value); }
        }

        public static readonly DependencyProperty istnObSelIdProperty =
            DependencyProperty.Register("istnObSelId", typeof(int), typeof(UserControl_CelNabycia), new PropertyMetadata(onChangedSelIstOb));

        private static void onChangedSelIstOb(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_CelNabycia u = d as UserControl_CelNabycia;
            u.zadInwestName = string.Empty;
            u.obiektKomName = string.Empty;

            u.selectedName = u.istObName;
            u.selectedId = u.istnObSelId;
            
        }

        public int zadInwestSelId
        {
            get { return (int)GetValue(zadInwestSelIdProperty); }
            set { SetValue(zadInwestSelIdProperty, value); }
        }

        public static readonly DependencyProperty zadInwestSelIdProperty =
            DependencyProperty.Register("zadInwestSelId", typeof(int), typeof(UserControl_CelNabycia), new PropertyMetadata(onChangedSelZadInwest));

        private static void onChangedSelZadInwest(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_CelNabycia u = d as UserControl_CelNabycia;
            u.istObName = string.Empty;
            u.obiektKomName = string.Empty;

            u.selectedName = u.zadInwestName;
            u.selectedId = u.zadInwestSelId;
        }

        public int obiektKomSelId
        {
            get { return (int)GetValue(obiektKomSelIdProperty); }
            set { SetValue(obiektKomSelIdProperty, value); }
        }

        public static readonly DependencyProperty obiektKomSelIdProperty =
            DependencyProperty.Register("obiektKomSelId", typeof(int), typeof(UserControl_CelNabycia), new PropertyMetadata(onChangedSelObiekKom));

        private static void onChangedSelObiekKom(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_CelNabycia u = d as UserControl_CelNabycia;
            u.istObName = string.Empty;
            u.zadInwestName = string.Empty;

            u.selectedName = u.obiektKomName;
            u.selectedId = u.obiektKomSelId;
        }

        #endregion

        #region celNabyciaList
        public ICelNabyciaList celNabyciaList
        {
            get { return (ICelNabyciaList)GetValue(celNabyciaListProperty); }
            set { SetValue(celNabyciaListProperty, value); }
        }

        public static readonly DependencyProperty celNabyciaListProperty =
            DependencyProperty.Register("celNabyciaList", typeof(ICelNabyciaList), typeof(UserControl_CelNabycia));
        #endregion

        #region listy
        public List<ICelNabycia> istnOb
        {
            get { return (List<ICelNabycia>)GetValue(istnObProperty); }
            set { SetValue(istnObProperty, value); }
        }

        public static readonly DependencyProperty istnObProperty =
            DependencyProperty.Register("istnOb", typeof(List<ICelNabycia>), typeof(UserControl_CelNabycia));

        public List<ICelNabycia> zadInwest
        {
            get { return (List<ICelNabycia>)GetValue(zadInwestProperty); }
            set { SetValue(zadInwestProperty, value); }
        }

        public static readonly DependencyProperty zadInwestProperty =
            DependencyProperty.Register("zadInwest", typeof(List<ICelNabycia>), typeof(UserControl_CelNabycia));

        public List<ICelNabycia> obiektKom
        {
            get { return (List<ICelNabycia>)GetValue(obiektKomProperty); }
            set { SetValue(obiektKomProperty, value); }
        }

        public static readonly DependencyProperty obiektKomProperty =
            DependencyProperty.Register("obiektKom", typeof(List<ICelNabycia>), typeof(UserControl_CelNabycia));
        #endregion

        #region Eventy

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            if (celNabyciaList != null)
            {
                istnOb = celNabyciaList.list.Where(r => r.Rodzaj == "Obiekt").ToList();
                zadInwest = celNabyciaList.list.Where(r => r.Rodzaj == "Zadanie").ToList();
                obiektKom = celNabyciaList.list.Where(r => r.Rodzaj == "ObKom").ToList();
                int a = 13;
                //MessageBox.Show( $"{istnOb.Count}\r\n{zadInwest.Count}\r\n{obiektKom.Count}");
            }
        }
        #endregion

    }
}

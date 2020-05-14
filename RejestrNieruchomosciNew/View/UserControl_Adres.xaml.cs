using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_Adres : UserControl
    {
        public UserControl_Adres()
        {
            InitializeComponent();
        
            DataContext = this;
            
            Loaded += UserControl_Adres_Loaded;
        }
               
        public bool correctAdr
        {
            get { return (bool)GetValue(correctAdrProperty); }
            set { SetValue(correctAdrProperty, value); }
        }

        public static readonly DependencyProperty correctAdrProperty =
            DependencyProperty.Register("correctAdr", typeof(bool), typeof(UserControl_Adres), new PropertyMetadata(true));

        private void UserControl_Adres_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("UserControl_Adres_Loaded");
            int a = 1;
            if (adres != null)
            {
                //adres.miejscList.getList(adres.Dzialka);
                miejscList = adres.miejscList;
                ulicaList = adres.ulicaList;
                calculateMiejsc();
                correctAdr = true;

                dzialka.zmiana += Dzialka_zmiana;

                //adres.Dzialka.zmianaObreb += Dzialka_zmianaObreb;

                adres.zmiana += Adres_zmiana;
            }
        }

        private void Adres_zmiana(object sender, EventArgs e)
        {
            //MessageBox.Show("Zmiana");
            calculateMiejsc();
        }

        private void Dzialka_zmiana(object sender, EventArgs e)
        {
            calculateMiejsc();
        }

        private void Dzialka_zmianaObreb(object sender, EventArgs e)
        {
            calculateMiejsc();
        }

        public IDzialka dzialka
        {
            get { return (IDzialka)GetValue(dzialkaProperty); }
            set { SetValue(dzialkaProperty, value); }
        }

        public static readonly DependencyProperty dzialkaProperty =
            DependencyProperty.Register("dzialka", typeof(IDzialka), typeof(UserControl_Adres), new PropertyMetadata(null, new PropertyChangedCallback( onDzialkaChange)));

        private static void onDzialkaChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //MessageBox.Show("Dzilaka CHange");
        }

        private void calculateMiejsc()
        {
            int? gminaId = dzialka?.Obreb?.GminaSloId;
            if (gminaId != null)
            {
                if (miejscList != null)
                    miejscList.getList(gminaId.Value);
            }
            else
            {
                miejscList.list = null;
                ulicaList.list = null;
            }
        }

        //public int? gminaId
        //{
        //    get { return (int?)GetValue(gminaIdProperty); }
        //    set { SetValue(gminaIdProperty, value); }
        //}

        //public static readonly DependencyProperty gminaIdProperty =
        //    DependencyProperty.Register("gminaId", typeof(int?), typeof(UserControl_Adres), new PropertyMetadata(null, new PropertyChangedCallback(onGminaChanged)));

        //private static void onGminaChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    UserControl_Adres u = d as UserControl_Adres;
        //    u.calculateMiejsc();
            
        //}

        //private void Dzialka_zmianaObreb(object sender, EventArgs e)
        //{
        //    miejscList.list = null;

        //    if (adres.Dzialka?.Obreb != null)
        //    {
        //        miejscList.getList(adres.Dzialka);
        //    }
        //}

        #region Dimensions
        public int rowHight
        {
            get { return (int)GetValue(rowHightProperty); }
            set { SetValue(rowHightProperty, value); }
        }
        public static readonly DependencyProperty rowHightProperty =
            DependencyProperty.Register("rowHight", typeof(int), typeof(UserControl_Adres), new PropertyMetadata(35));

        public int userWidth
        {
            get { return (int)GetValue(userWidthProperty); }
            set { SetValue(userWidthProperty, value); }
        }
        public static readonly DependencyProperty userWidthProperty =
            DependencyProperty.Register("userWidth", typeof(int), typeof(UserControl_Adres), new PropertyMetadata(270));

        public int userHeight
        {
            get { return (int)GetValue(userHeightProperty); }
            set { SetValue(userHeightProperty, value); }
        }
        public static readonly DependencyProperty userHeightProperty =
            DependencyProperty.Register("userHeight", typeof(int), typeof(UserControl_Adres), new PropertyMetadata(250));

        public int column1Width
        {
            get { return (int)GetValue(column1WidthProperty); }
            set { SetValue(column1WidthProperty, value); }
        }

        public static readonly DependencyProperty column1WidthProperty =
            DependencyProperty.Register("column1Width", typeof(int), typeof(UserControl_Adres), new PropertyMetadata(130));

        public int column2Width
        {
            get { return (int)GetValue(column2WidthProperty); }
            set { SetValue(column2WidthProperty, value); }
        }

        public static readonly DependencyProperty column2WidthProperty =
            DependencyProperty.Register("column2Width", typeof(int), typeof(UserControl_Adres), new PropertyMetadata(130));

        public int comboHight
        {
            get { return (int)GetValue(comboHightProperty); }
            set { SetValue(comboHightProperty, value); }
        }

        public static readonly DependencyProperty comboHightProperty =
            DependencyProperty.Register("comboHight", typeof(int), typeof(UserControl_Adres), new PropertyMetadata(30));
        #endregion

        #region Combo Miejscowosc
        public IMiejscowoscSloList miejscList
        {
            get { return (IMiejscowoscSloList)GetValue(miejscListProperty); }
            set { SetValue(miejscListProperty, value); }
        }

        public static readonly DependencyProperty miejscListProperty =
            DependencyProperty.Register("miejscList", typeof(IMiejscowoscSloList), typeof(UserControl_Adres));




        public IMiejscowoscSlo miejscSelVal
        {
            get { return (IMiejscowoscSlo)GetValue(miejscSelValProperty); }
            set { SetValue(miejscSelValProperty, value); }
        }

        public static readonly DependencyProperty miejscSelValProperty =
            DependencyProperty.Register("miejscSelVal", typeof(IMiejscowoscSlo), typeof(UserControl_Adres), new PropertyMetadata( null, new PropertyChangedCallback( onSelectMiejsc)));

        private static void onSelectMiejsc(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Adres u = d as UserControl_Adres;
           
            if (u.miejscSelVal != null)
            {
                u.adres.ulicaList.getList(u.miejscSelVal);
                u.adres.MiejscowoscSloId = u.miejscSelVal.MiejscowoscSloId;

                u.ulicaList = null;
                u.adres.UlicaSloId = 0;
                u.ulicaList = u.adres.ulicaList;

                u.correctAdr =true;
                //MessageBox.Show("correctAdr");
            }
            else
                u.correctAdr = false;
        }

        //private bool validate()
        //{
        //    if (adres.MiejscowoscSloId > 0)
        //    {
        //        return true;
        //        // wyremowane - warunek konieczny aby podać nuemr adresowy
        //        //if (ulicaList?.list?.FirstOrDefault(r => r?.MiejscowoscUlice == adres?.MiejscowoscSloId) == null)
        //        //    return true;
        //        //else
        //        //{
        //        //    if (string.IsNullOrEmpty(adres.Numer) != true)
        //        //        return true;
        //        //}
        //    }
        //    return false;
        //}

        public string miejscSelValPath
        {
            get { return (string)GetValue(miejscSelValPathProperty); }
            set { SetValue(miejscSelValPathProperty, value); }
        }

        public static readonly DependencyProperty miejscSelValPathProperty =
            DependencyProperty.Register("miejscSelValPath", typeof(string), typeof(UserControl_Adres));

        #endregion

        #region Combo Ulica
        public IUlicaSloList ulicaList
        {
            get { return (IUlicaSloList)GetValue(ulicaListProperty); }
            set { SetValue(ulicaListProperty, value); }
        }

        public static readonly DependencyProperty ulicaListProperty =
            DependencyProperty.Register("ulicaList", typeof(IUlicaSloList), typeof(UserControl_Adres));

        public IUlicaSlo ulicaSelVal
        {
            get { return (IUlicaSlo)GetValue(ulicaSelValProperty); }
            set { SetValue(ulicaSelValProperty, value); }
        }

        public static readonly DependencyProperty ulicaSelValProperty =
            DependencyProperty.Register("ulicaSelVal", typeof(IUlicaSlo), typeof(UserControl_Adres), new PropertyMetadata( null, new PropertyChangedCallback( onUliceChange)));

        private static void onUliceChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Adres u = d as UserControl_Adres;
            if (u.ulicaSelVal != null)
                u.adres.UlicaSloId = u.ulicaSelVal.UlicaSloId;

            //u.correctAdr = u.validate();
        }

        public string ulicaSelValPath
        {
            get { return (string)GetValue(ulicaSelValPathProperty); }
            set { SetValue(ulicaSelValPathProperty, value); }
        }

        public static readonly DependencyProperty ulicaSelValPathProperty =
            DependencyProperty.Register("ulicaSelValPath", typeof(string), typeof(UserControl_Adres));

        #endregion

        #region NumerUlicy
        public string NumerUlicy
        {
            get { return (string)GetValue(NumerUlicyProperty); }
            set { SetValue(NumerUlicyProperty, value); }
        }

        public static readonly DependencyProperty NumerUlicyProperty =
            DependencyProperty.Register("NumerUlicy", typeof(string), typeof(UserControl_Adres), new PropertyMetadata( null, new PropertyChangedCallback( numerChange)));

        private static void numerChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Adres u = d as UserControl_Adres;
            u.adres.Numer = u.NumerUlicy;

            //u.correctAdr = u.validate();
        }
        #endregion

        public IAdres adres
        {
            get { return (IAdres)GetValue(adresProperty); }
            set { SetValue(adresProperty, value); }
        }

        public static readonly DependencyProperty adresProperty =
            DependencyProperty.Register("adres", typeof(IAdres), typeof(UserControl_Adres), new PropertyMetadata(null, new PropertyChangedCallback(onAdesChange)));

        private static void onAdesChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //MessageBox.Show("AdresDB");
        }
    }
}

using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_Adres : UserControl
    {
        public UserControl_Adres()
        {
            InitializeComponent();

            DataContext = this;

            onCzyscClick = new RelayCommand(onCzysc);
            Loaded += UserControl_Adres_Loaded;
        }

        private void onCzysc()
        {
            //MessageBox.Show( "onClcked" + gminaId);

            miejscSelVal = null;
            ulicaSelVal = null;
            NumerUlicy = string.Empty;

            //adres = null;
            adres.MiejscowoscSloId = 0;
            adres.UlicaSloId = null;
            adres.Numer = string.Empty;

            correctAdr = true;

        }

        public ICommand onCzyscClick { get; set; }

        private void calculateVal()
        {
            if (adres != null)
            {
                miejscSelVal = miejscList?.list?.FirstOrDefault(r => r.MiejscowoscSloId == adres.MiejscowoscSloId);
                ulicaSelVal = ulicaList?.list?.FirstOrDefault(r => r.UlicaSloId == adres.UlicaSloId);
                NumerUlicy = adres?.Numer;
            }
        }

        #region correctAdr
        public bool correctAdr
        {
            get { return (bool)GetValue(correctAdrProperty); }
            set { SetValue(correctAdrProperty, value); }
        }

        public static readonly DependencyProperty correctAdrProperty =
            DependencyProperty.Register("correctAdr", typeof(bool), typeof(UserControl_Adres), new PropertyMetadata(true));
        #endregion

        #region Loaded
        private void UserControl_Adres_Loaded(object sender, RoutedEventArgs e)
        {
            if (adresSlo != null)
            {
                if (adres == null)
                {
                    adres = new Adres();
                    adres.AdresId = 0;
                }

                miejscList = adresSlo.miejscList;
                ulicaList = adresSlo.ulicaList;

                if (gminaId != null)
                {
                    calculateMiejsc();
                    
                    calculateVal();
                  
                    correctAdr = true;
                }
            }
        }
        #endregion

        


        #region adres
        public IAdres adres
        {
            get { return (IAdres)GetValue(adresProperty); }
            set { SetValue(adresProperty, value); }
        }

        public static readonly DependencyProperty adresProperty =
            DependencyProperty.Register("adres", typeof(IAdres), typeof(UserControl_Adres), new PropertyMetadata( onChangeAdres));

        private static void onChangeAdres(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {          
            UserControl_Adres u = d as UserControl_Adres;
            u.calculateVal();
        }

        #endregion

        #region gminaId
        public int? gminaId
        {
            get { return (int?)GetValue(gminaIdProperty); }
            set { SetValue(gminaIdProperty, value); }
        }

        public static readonly DependencyProperty gminaIdProperty =
            DependencyProperty.Register("gminaId", typeof(int?), typeof(UserControl_Adres), new PropertyMetadata( new PropertyChangedCallback(onGminaIdChanged)));
        private static void onGminaIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Adres u = d as UserControl_Adres;
            u.calculateMiejsc();            
        }
        #endregion

        private void calculateMiejsc()
        {
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

        #region Dimensions
        public int rowHight
        {
            get { return (int)GetValue(rowHightProperty); }
            set { SetValue(rowHightProperty, value); }
        }
        public static readonly DependencyProperty rowHightProperty =
            DependencyProperty.Register("rowHight", typeof(int), typeof(UserControl_Adres), new PropertyMetadata(35));

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
            DependencyProperty.Register("miejscSelVal", typeof(IMiejscowoscSlo), typeof(UserControl_Adres), new PropertyMetadata(new PropertyChangedCallback(onSelectMiejsc)));

        private static void onSelectMiejsc(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Adres u = d as UserControl_Adres;

            if (u.miejscSelVal != null)
            {
                u.adresSlo.ulicaList.getList(u.miejscSelVal);
                u.adres.MiejscowoscSloId = u.miejscSelVal.MiejscowoscSloId;

                //if (u.adres.MiejscowoscSloId == 0)
                //    u.adres = null;

                u.ulicaList = null;
                //u.adres.UlicaSloId = 0;
                u.ulicaList = u.adresSlo.ulicaList;
                u.correctAdr = true;
            }
            else
                u.correctAdr = false;
        }

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
            DependencyProperty.Register("ulicaSelVal", typeof(IUlicaSlo), typeof(UserControl_Adres), new PropertyMetadata(null, new PropertyChangedCallback(onUliceChange)));

        private static void onUliceChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Adres u = d as UserControl_Adres;
            if (u.ulicaSelVal != null)
                u.adres.UlicaSloId = u.ulicaSelVal.UlicaSloId;

            u.correctAdr = true;

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
            DependencyProperty.Register("NumerUlicy", typeof(string), typeof(UserControl_Adres), new PropertyMetadata(null, new PropertyChangedCallback(numerChange)));

        private static void numerChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Adres u = d as UserControl_Adres;
            u.adres.Numer = u.NumerUlicy;
            u.correctAdr = true;

            //u.correctAdr = u.validate();
        }
        #endregion

        #region adresSlo
        public IAdresSloList adresSlo
        {
            get { return (IAdresSloList)GetValue(adresSloProperty); }
            set { SetValue(adresSloProperty, value); }
        }

        public static readonly DependencyProperty adresSloProperty =
            DependencyProperty.Register("adresSlo", typeof(IAdresSloList), typeof(UserControl_Adres));

        #endregion
    }
}

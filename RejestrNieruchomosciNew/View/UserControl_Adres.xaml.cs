using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
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

        private void UserControl_Adres_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

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
            DependencyProperty.Register("miejscList", typeof(IMiejscowoscSloList), typeof(UserControl_Adres), new PropertyMetadata(null, new PropertyChangedCallback(onMiejscList)));

        private static void onMiejscList(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int r = 13;
        }

        public IMiejscowoscSlo miejscSelVal
        {
            get { return (IMiejscowoscSlo)GetValue(miejscSelValProperty); }
            set { SetValue(miejscSelValProperty, value); }
        }

        public static readonly DependencyProperty miejscSelValProperty =
            DependencyProperty.Register("miejscSelVal", typeof(IMiejscowoscSlo), typeof(UserControl_Adres));

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
            DependencyProperty.Register("ulicaSelVal", typeof(IUlicaSlo), typeof(UserControl_Adres));

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
            DependencyProperty.Register("NumerUlicy", typeof(string), typeof(UserControl_Adres));
        #endregion

        public IAdres adres
        {
            get { return (IAdres)GetValue(adresProperty); }
            set { SetValue(adresProperty, value); }
        }

        public static readonly DependencyProperty adresProperty =
            DependencyProperty.Register("adres", typeof(IAdres), typeof(UserControl_Adres), new PropertyMetadata( null, new PropertyChangedCallback(onAdres)));

        private static void onAdres(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int r = 13;
        }

        public IDzialka dzialka
        {
            get { return (IDzialka)GetValue(dzialkaProperty); }
            set { SetValue(dzialkaProperty, value); }
        }

        public static readonly DependencyProperty dzialkaProperty =
            DependencyProperty.Register("dzialka", typeof(IDzialka), typeof(UserControl_Adres));





    }
}

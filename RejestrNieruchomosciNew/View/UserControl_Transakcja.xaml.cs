using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_Transakcja : UserControl
    {
        public UserControl_Transakcja()
        {
            InitializeComponent();
            DataContext = this;

            clickOK = new RelayCommand( onClickOK);
        }

        public Transakcje transakcje
        {
            get { return (Transakcje)GetValue(transakcjeProperty); }
            set { SetValue(transakcjeProperty, value); }
        }

        public static readonly DependencyProperty transakcjeProperty =
            DependencyProperty.Register("transakcje", typeof(Transakcje), typeof(UserControl_Transakcja), new PropertyMetadata(null, new PropertyChangedCallback(onTransakcjeChanged)) );

        private static void onTransakcjeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Transakcja u = d as UserControl_Transakcja;
            if (u.transakcje != null)
                u.transakcje.PropertyChanged += onNotify;
        }

        public RodzajDokumentuList rodzDokSlo
        {
            get { return (RodzajDokumentuList)GetValue(rodzDokSloProperty); }
            set { SetValue(rodzDokSloProperty, value); }
        }
        public static readonly DependencyProperty rodzDokSloProperty =
            DependencyProperty.Register("rodzDokSlo", typeof(RodzajDokumentuList), typeof(UserControl_Transakcja));

        public NazwaCzynnosciList nazwaCzynSlo
        {
            get { return (NazwaCzynnosciList)GetValue(nazwaCzynSloProperty); }
            set { SetValue(nazwaCzynSloProperty, value); }
        }

        public static readonly DependencyProperty nazwaCzynSloProperty =
            DependencyProperty.Register("nazwaCzynSlo", typeof(NazwaCzynnosciList), typeof(UserControl_Transakcja));

        private void onClickOK()
        {
            //MessageBox.Show($"{userControlDataGridRafALL.TekstPropALL}\r\n" +
            //                $"{userControlDataGridRafALL.selectedIdRafALL}\r\n");
        }

        public ICommand clickOK { get; set; }

        #region itemSourceTrans
        public IEnumerable itemSourceTrans
        {
            get { return (IEnumerable)GetValue(itemSourceTransProperty); }
            set { SetValue(itemSourceTransProperty, value); }
        }

        public static readonly DependencyProperty itemSourceTransProperty =
            DependencyProperty.Register("itemSourceTrans", typeof(IEnumerable), typeof(UserControl_Transakcja) );
        #endregion

        #region selectedId
        public int selectedId
        {
            get { return (int)GetValue(selectedIdProperty); }
            set { SetValue(selectedIdProperty, value); }
        }

        public static readonly DependencyProperty selectedIdProperty =
           DependencyProperty.Register("selectedId", typeof(int), typeof(UserControl_Transakcja), new PropertyMetadata(0, new PropertyChangedCallback( onSelecteIdChanged)));

        private static void onSelecteIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
            UserControl_Transakcja u = d as UserControl_Transakcja;
            if (u.selectedId > 0)
            {
                u.transakcje = u.itemSourceTrans.Cast<Transakcje>().FirstOrDefault(row => row.TransakcjeId == u.selectedId);
                u.userControlDataGridRafALL.TekstPropALL = u.transakcje.Numer;

               
            }
        }
        #endregion

        private void userControl_Transakcja1_Loaded(object sender, RoutedEventArgs e)
        {
            userControlDataGridRafALL.itemSourceRafALL = itemSourceTrans;

            //if( transakcje != null)
            //    transakcje.PropertyChanged += onNotify;
        }

        private void UserControlDataGridRafALL_UserControlChanged(object sender, EventArgs e)
        {
            MessageBox.Show( "Zdarzenie");
        }

        static void onNotify(object sender, PropertyChangedEventArgs e)
        {
            //MessageBox.Show( $"onNotify:{e.PropertyName}");
        }
    }
}

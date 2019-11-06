using GalaSoft.MvvmLight.Command;
using System;
using System.Collections;
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

        private void onClickOK()
        {
            MessageBox.Show($"{userControlDataGridRafALL.TekstPropALL}\r\n" +
                             $"{userControlDataGridRafALL.selectedIdRafALL}");
        }

        public ICommand clickOK { get; set; }

        public IEnumerable itemSourceTrans
        {
            get { return (IEnumerable)GetValue(itemSourceTransProperty); }
            set { SetValue(itemSourceTransProperty, value); }
        }

        public static readonly DependencyProperty itemSourceTransProperty =
            DependencyProperty.Register("itemSourceTrans", typeof(IEnumerable), typeof(UserControl_Transakcja) );
        
        public string numerTrans
        {
            get { return (string)GetValue(numerTransProperty); }
            set { SetValue(numerTransProperty, value); }
        }
        
        public static readonly DependencyProperty numerTransProperty =
            DependencyProperty.Register("numerTrans", typeof(string), typeof(UserControl_Transakcja));
        
        public int selectedId
        {
            get { return (int)GetValue(selectedIdProperty); }
            set { SetValue(selectedIdProperty, value); }
        }

        public static readonly DependencyProperty selectedIdProperty =
            DependencyProperty.Register("selectedId", typeof(int), typeof(UserControl_Transakcja));
        
        private void userControl_Transakcja1_Loaded(object sender, RoutedEventArgs e)
        {
            userControlDataGridRafALL.itemSourceRafALL = itemSourceTrans;
            userControlDataGridRafALL.TekstPropALL = "numer1";
        }
    }
}

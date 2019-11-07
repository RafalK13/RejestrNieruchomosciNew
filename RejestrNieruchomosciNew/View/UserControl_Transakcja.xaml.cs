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
                            $"{userControlDataGridRafALL.selectedIdRafALL}\r\n");
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
           DependencyProperty.Register("selectedId", typeof(int), typeof(UserControl_Transakcja), new PropertyMetadata(14));
        #endregion

        private void userControl_Transakcja1_Loaded(object sender, RoutedEventArgs e)
        {
            userControlDataGridRafALL.itemSourceRafALL = itemSourceTrans;
        }

        private void UserControlDataGridRafALL_UserControlChanged(object sender, EventArgs e)
        {
            MessageBox.Show( "Zdarzenie");
        }
    }
}

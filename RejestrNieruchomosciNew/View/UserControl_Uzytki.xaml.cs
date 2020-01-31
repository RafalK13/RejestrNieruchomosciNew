using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_Uzytki : UserControl
    {
        public UserControl_Uzytki()
        {
            InitializeComponent();
            DataContext = this;            
        }

        public UzytkiList uzytkiList
        {
            get { return (UzytkiList)GetValue(uzytkiListProperty); }
            set { SetValue(uzytkiListProperty, value); }
        }

        public static readonly DependencyProperty uzytkiListProperty =
            DependencyProperty.Register("uzytkiList", typeof(UzytkiList), typeof(UserControl_Uzytki));

        public UzytkiSloList uzytkiSloList
        {
            get { return (UzytkiSloList)GetValue(uzytkiSloListProperty); }
            set { SetValue(uzytkiSloListProperty, value); }
        }

        public static readonly DependencyProperty uzytkiSloListProperty =
            DependencyProperty.Register("uzytkiSloList", typeof(UzytkiSloList), typeof(UserControl_Uzytki));

        private void gridRaf_Loaded(object sender, RoutedEventArgs e)
        {
            gridRaf.ItemsSource = uzytkiList.list;
            gridColRaf.ItemsSource = uzytkiSloList.list;
        }
    }
}

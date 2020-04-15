using RejestrNieruchomosciNew.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_Ulice : UserControl
    {
        public UserControl_Ulice()
        {
            InitializeComponent();
            DataContext = this;
        }

        public int HeightRaf
        {
            get { return (int)GetValue(HeightRafProperty); }
            set { SetValue(HeightRafProperty, value); }
        }

        public static readonly DependencyProperty HeightRafProperty =
            DependencyProperty.Register("HeightRaf", typeof(int), typeof(UserControl_Ulice), new PropertyMetadata(10));


        public UlicaSloList uliceSloList
        {
            get { return (UlicaSloList)GetValue(uliceSloListProperty); }
            set { SetValue(uliceSloListProperty, value); }
        }

        public static readonly DependencyProperty uliceSloListProperty =
            DependencyProperty.Register("uliceSloList", typeof(UlicaSloList), typeof(UserControl_Ulice));

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
          
        }
    }
}

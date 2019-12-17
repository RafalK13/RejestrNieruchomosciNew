using System.Windows;
using System.Windows.Controls;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_Platnosc : UserControl
    {
        public UserControl_Platnosc()
        {
            InitializeComponent();
            DataContext = this;
        }
        
        public PlatnoscUW platnoscUW
        {
            get { return (PlatnoscUW)GetValue(platnoscUWProperty); }
            set { SetValue(platnoscUWProperty, value); }
        }

        public static readonly DependencyProperty platnoscUWProperty =
            DependencyProperty.Register("platnoscUW", typeof(PlatnoscUW), typeof(UserControl_Platnosc));


    }
}

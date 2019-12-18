using RejestrNieruchomosciNew.Model;
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
        
        public IPlatnosc platnosc
        {
            get { return (IPlatnosc)GetValue(platnoscProperty); }
            set { SetValue(platnoscProperty, value); }
        }

        public static readonly DependencyProperty platnoscProperty =
            DependencyProperty.Register("platnosc", typeof(IPlatnosc), typeof(UserControl_Platnosc));


    }
}

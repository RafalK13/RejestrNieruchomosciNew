using RejestrNieruchomosciNew.ViewModel;
using System.Windows;

namespace RejestrNieruchomosciNew.View
{
    public partial class Window2 : Window
    {
        public Window2(Window2ViewModel model)
        {
            InitializeComponent( );
            DataContext = model;
        }
    }
}

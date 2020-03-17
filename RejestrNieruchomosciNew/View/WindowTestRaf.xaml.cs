using RejestrNieruchomosciNew.ViewModel;
using System.Windows;

namespace RejestrNieruchomosciNew.View
{
    /// <summary>
    /// Interaction logic for WindowTestRaf.xaml
    /// </summary>
    public partial class WindowTestRaf : Window
    {
        public WindowTestRaf( WindowTestRafViewModel vmRaf)
        {
            InitializeComponent();
            DataContext = vmRaf;
        }
    }
}

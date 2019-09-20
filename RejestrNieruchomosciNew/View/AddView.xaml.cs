using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.ViewModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.View
{
    public partial class AddView : Window, IView
    {
        public AddView( AddViewModel addViewModel)
        {
            InitializeComponent();
            DataContext = addViewModel;
        }
    }
}

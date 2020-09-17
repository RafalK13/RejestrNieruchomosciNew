using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;
using System.Windows;

namespace RejestrNieruchomosciNew.View
{
    public partial class Window_Filtr : Window
    {
        public Window_Filtr(Window_FiltrViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

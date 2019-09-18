using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.ComponentModel;
using System.Windows;


namespace RejestrNieruchomosciNew.View
{
    public partial class MainView : Window
    {
        public MainView( MainViewModel mvm)
        {
            InitializeComponent();
            DataContext = mvm;
        }
    }
}

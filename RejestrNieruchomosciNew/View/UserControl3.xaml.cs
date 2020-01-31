using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RejestrNieruchomosciNew.View
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
            DataContext = this;
        }



        public ObservableCollection<IUzytki> daneRaf
        {
            get { return (ObservableCollection<IUzytki> )GetValue(daneRafProperty); }
            set { SetValue(daneRafProperty, value); }
        }

        public static readonly DependencyProperty daneRafProperty =
            DependencyProperty.Register("daneRaf", typeof(ObservableCollection<IUzytki> ), typeof(UserControl3));




    }
}

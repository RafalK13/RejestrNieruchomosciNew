using System;
using System.Collections.Generic;
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
    /// Interaction logic for UserControl_TestRaf.xaml
    /// </summary>
    public partial class UserControl_TestRaf : UserControl
    {
        public UserControl_TestRaf()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string testRaf
        {
            get { return (string)GetValue(testRafProperty); }
            set { SetValue(testRafProperty, value); }
        }

        // Using a DependencyProperty as the backing store for testRaf.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty testRafProperty =
            DependencyProperty.Register("testRaf", typeof(string), typeof(UserControl_TestRaf), new PropertyMetadata("RAfałek_UserControl_TestRaf"));


    }
}

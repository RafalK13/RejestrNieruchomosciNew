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
    public partial class UserControl_CheckBox : UserControl
    {
        public UserControl_CheckBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        public int widthLabelRaf
        {
            get { return (int)GetValue(widthLabelRafProperty); }
            set { SetValue(widthLabelRafProperty, value); }
        }

        public static readonly DependencyProperty widthLabelRafProperty =
            DependencyProperty.Register("widthLabelRaf", typeof(int), typeof(UserControl_CheckBox), new PropertyMetadata(70));

        public string labelRaf
        {
            get { return (string)GetValue(labelRafProperty); }
            set { SetValue(labelRafProperty, value); }
        }

        public static readonly DependencyProperty labelRafProperty =
            DependencyProperty.Register("labelRaf", typeof(string), typeof(UserControl_CheckBox), new PropertyMetadata(""));

        public int hightRaf
        {
            get { return (int)GetValue(hightRafProperty); }
            set { SetValue(hightRafProperty, value); }
        }

        public static readonly DependencyProperty hightRafProperty =
            DependencyProperty.Register("hightRaf", typeof(int), typeof(UserControl_CheckBox), new PropertyMetadata(25));

        public int heightCheckBox
        {
            get { return (int)GetValue(heightCheckBoxProperty); }
            set { SetValue(heightCheckBoxProperty, value); }
        }

        public static readonly DependencyProperty heightCheckBoxProperty =
            DependencyProperty.Register("heightCheckBox", typeof(int), typeof(UserControl_CheckBox), new PropertyMetadata(20));

        public bool isChackedRaf
        {
            get { return (bool)GetValue(isChackedRafProperty); }
            set { SetValue(isChackedRafProperty, value); }
        }

        public static readonly DependencyProperty isChackedRafProperty =
            DependencyProperty.Register("isChackedRaf", typeof(bool), typeof(UserControl_CheckBox));

    }
}

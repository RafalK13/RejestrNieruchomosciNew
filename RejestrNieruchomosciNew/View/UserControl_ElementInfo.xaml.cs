using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_ElementInfo : UserControl
    {
        public UserControl_ElementInfo()
        {
            InitializeComponent();
            DataContext = this;

            onClickZal = new RelayCommand( zalClicked);
        }

        private void zalClicked()
        {
            
        }

        public ICommand onClickZal { get; set; }

        public Visibility buttonVisibility
        {
            get { return (Visibility)GetValue(buttonVisibilityProperty); }
            set { SetValue(buttonVisibilityProperty, value); }
        }

        public static readonly DependencyProperty buttonVisibilityProperty =
            DependencyProperty.Register("buttonVisibility", typeof(Visibility), typeof(UserControl_ElementInfo), new PropertyMetadata( Visibility.Hidden));

        public int hightRaf
        {
            get { return (int)GetValue(hightRafProperty); }
            set { SetValue(hightRafProperty, value); }
        }

        public static readonly DependencyProperty hightRafProperty =
            DependencyProperty.Register("hightRaf", typeof(int), typeof(UserControl_ElementInfo), new PropertyMetadata(25));

        public int widthLabelRaf
        {
            get { return (int)GetValue(widthLabelRafProperty); }
            set { SetValue(widthLabelRafProperty, value); }
        }

        public static readonly DependencyProperty widthLabelRafProperty =
            DependencyProperty.Register("widthLabelRaf", typeof(int), typeof(UserControl_ElementInfo), new PropertyMetadata(70));

        public int widthTextRaf
        {
            get { return (int)GetValue(widthTextRafProperty); }
            set { SetValue(widthTextRafProperty, value); }
        }

        public static readonly DependencyProperty widthTextRafProperty =
            DependencyProperty.Register("widthTextRaf", typeof(int), typeof(UserControl_ElementInfo), new PropertyMetadata(130));

        public int spaceRaf
        {
            get { return (int)GetValue(spaceRafProperty); }
            set { SetValue(spaceRafProperty, value); }
        }

        public static readonly DependencyProperty spaceRafProperty =
            DependencyProperty.Register("spaceRaf", typeof(int), typeof(UserControl_ElementInfo), new PropertyMetadata(5));

        public string labelRaf
        {
            get { return (string)GetValue(labelRafProperty); }
            set { SetValue(labelRafProperty, value); }
        }

        public static readonly DependencyProperty labelRafProperty =
            DependencyProperty.Register("labelRaf", typeof(string), typeof(UserControl_ElementInfo), new PropertyMetadata(""));

        public string tekstRaf
        {
            get { return (string)GetValue(tekstRafProperty); }
            set { SetValue(tekstRafProperty, value); }
        }

        public static readonly DependencyProperty tekstRafProperty =
            DependencyProperty.Register("tekstRaf", typeof(string), typeof(UserControl_ElementInfo), new PropertyMetadata(""));

        public string zalPath
        {
            get { return (string)GetValue(zalPathProperty); }
            set { SetValue(zalPathProperty, value); }
        }

        public static readonly DependencyProperty zalPathProperty =
            DependencyProperty.Register("zalPath", typeof(string), typeof(UserControl_ElementInfo), new PropertyMetadata(""));

    }
}

using GalaSoft.MvvmLight.Command;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_Test : UserControl
    {
        public UserControl_Test()
        {
            InitializeComponent();
            DataContext = this;

            buttonClick1 = new RelayCommand(onclickButton1);
            buttonClick2 = new RelayCommand(onclickButton2);

        }

        private void onclickButton2()
        {
            button1 = true;
            button2 = true;

        }

        private void onclickButton1()
        {
            button2 = true;
            button1 = false;
        }

        public ICommand buttonClick1 { get; set; }
        public ICommand buttonClick2 { get; set; }

        public bool button1
        {
            get { return (bool)GetValue(button1Property); }
            set { SetValue(button1Property, value); }
        }

        public static readonly DependencyProperty button1Property =
            DependencyProperty.Register("button1", typeof(bool), typeof(UserControl_Test), new PropertyMetadata(true));

        public bool button2
        {
            get { return (bool)GetValue(button2Property); }
            set { SetValue(button2Property, value); }
        }

        public static readonly DependencyProperty button2Property =
            DependencyProperty.Register("button2", typeof(bool), typeof(UserControl_Test), new PropertyMetadata(false));
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Command
{
    public class ClickButtonBevaviour
    {
        public static bool GetClickButton(DependencyObject obj)
        {
            return (bool)obj.GetValue(ClickButtonProperty);
        }

        public static void SetClickButton(DependencyObject obj, bool value)
        {
            obj.SetValue(ClickButtonProperty, value);
        }

        public static readonly DependencyProperty ClickButtonProperty =
            DependencyProperty.RegisterAttached("ClickButton", typeof(bool), typeof(ClickButtonBevaviour), new PropertyMetadata(false, onButtonChanged));

        private static void onButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("OK");
        }
    }
}

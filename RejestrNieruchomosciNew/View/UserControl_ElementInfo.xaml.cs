using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

            onClickZal = new RelayCommand(zalClicked);
        }

        public bool isReadOnlyRaf
        {
            get { return (bool)GetValue(isReadOnlyRafProperty); }
            set { SetValue(isReadOnlyRafProperty, value); }
        }

        public static readonly DependencyProperty isReadOnlyRafProperty =
            DependencyProperty.Register("isReadOnlyRaf", typeof(bool), typeof(UserControl_ElementInfo), new PropertyMetadata(false));

        private void zalClicked()
        {
            int r = 13;
            if (checkIfFiles(pathZal) == true)
            {
                var view = new Window_Zalacznik();
                Window_ZalacznikViewModel m = new Window_ZalacznikViewModel(pathZal);
                view.DataContext = m;
                view.ShowDialog();
            }
            //else
            //{
            //    buttonOpis = "brak załączników";
            //    buttonEnabled = false;
            //}
        }

        public string buttonOpis
        {
            get { return (string)GetValue(buttonOpisProperty); }
            set { SetValue(buttonOpisProperty, value); }
        }

        public static readonly DependencyProperty buttonOpisProperty =
            DependencyProperty.Register("buttonOpis", typeof(string), typeof(UserControl_ElementInfo), new PropertyMetadata(""));

        public bool buttonEnabled
        {
            get { return (bool)GetValue(buttonEnabledProperty); }
            set { SetValue(buttonEnabledProperty, value); }
        }

        public static readonly DependencyProperty buttonEnabledProperty =
            DependencyProperty.Register("buttonEnabled", typeof(bool), typeof(UserControl_ElementInfo), new PropertyMetadata(false));

        public string pathZal
        {
            get { return (string)GetValue(pathZalProperty); }
            set { SetValue(pathZalProperty, value); }
        }

        public static readonly DependencyProperty pathZalProperty =
            DependencyProperty.Register("pathZal", typeof(string), typeof(UserControl_ElementInfo), new PropertyMetadata("XXX", new PropertyChangedCallback(onChangePath)));

        public async Task<bool> checkIfFilesAsync(string s)
        {
            bool result = true;
            string resultList = String.Empty;
            await Task.Run(() =>
            {
                result = Directory.Exists(s);
            });

            if (result == false)
                return false;
            else
            {
                await Task.Run(() =>
                {
                    resultList = Directory.GetFiles(s).FirstOrDefault();
                });
                if (resultList == null)
                    return false;
            }



            return true;
        }


        private bool checkIfFiles(string path)
        {
            if (Directory.Exists(path) == false)
                return false;
            if (Directory.GetFiles(path).FirstOrDefault() == null)
                return false;

            return true;
        }

        private static async void onChangePath(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int r = 13;
            //MessageBox.Show("XXX");

            //UserControl_ElementInfo u = d as UserControl_ElementInfo;
            //u.buttonOpis = "";
            //u.buttonEnabled = true;

            UserControl_ElementInfo u = d as UserControl_ElementInfo;
            if ( await u.checkIfFilesAsync(u.pathZal) == false)
            {
                u.buttonOpis = "Empty";
                u.buttonEnabled = false;
            }
            else
            {
                u.buttonOpis = "";
                u.buttonEnabled = true;
            }
        }

        public ICommand onClickZal
        {
            get { return (ICommand)GetValue(onClickZalProperty); }
            set { SetValue(onClickZalProperty, value); }
        }

        public static readonly DependencyProperty onClickZalProperty =
            DependencyProperty.Register("onClickZal", typeof(ICommand), typeof(UserControl_ElementInfo));

        public Visibility buttonVisibility
        {
            get { return (Visibility)GetValue(buttonVisibilityProperty); }
            set { SetValue(buttonVisibilityProperty, value); }
        }

        public static readonly DependencyProperty buttonVisibilityProperty =
            DependencyProperty.Register("buttonVisibility", typeof(Visibility), typeof(UserControl_ElementInfo), new PropertyMetadata(Visibility.Hidden));

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

        public Visibility comboVisibility
        {
            get { return (Visibility)GetValue(comboVisibilityProperty); }
            set { SetValue(comboVisibilityProperty, value); }
        }

        public static readonly DependencyProperty comboVisibilityProperty =
            DependencyProperty.Register("comboVisibility", typeof(Visibility), typeof(UserControl_ElementInfo), new PropertyMetadata(Visibility.Hidden));

    }
}

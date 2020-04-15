using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections;
using System.IO;
using System.Linq;
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

        public bool isReadOnlyRaf
        {
            get { return (bool)GetValue(isReadOnlyRafProperty); }
            set { SetValue(isReadOnlyRafProperty, value); }
        }

        public static readonly DependencyProperty isReadOnlyRafProperty =
            DependencyProperty.Register("isReadOnlyRaf", typeof(bool), typeof(UserControl_ElementInfo), new PropertyMetadata(false));

        private void zalClicked()
        {
             var view = new Window_Zalacznik();
             Window_ZalacznikViewModel m = new Window_ZalacznikViewModel(pathZal);
             view.DataContext = m;
             view.ShowDialog();
        }

        public string buttonOpis
        {
            get { return (string)GetValue(buttonOpisProperty); }
            set { SetValue(buttonOpisProperty, value); }
        }

        public static readonly DependencyProperty buttonOpisProperty =
            DependencyProperty.Register("buttonOpis", typeof(string), typeof(UserControl_ElementInfo));

        public bool buttonEnabled
        {
            get { return (bool)GetValue(buttonEnabledProperty); }
            set { SetValue(buttonEnabledProperty, value); }
        }

        public static readonly DependencyProperty buttonEnabledProperty =
            DependencyProperty.Register("buttonEnabled", typeof(bool), typeof(UserControl_ElementInfo));

        public string pathZal
        {
            get { return (string)GetValue(pathZalProperty); }
            set { SetValue(pathZalProperty, value); }
        }

        public static readonly DependencyProperty pathZalProperty =
            DependencyProperty.Register("pathZal", typeof(string), typeof(UserControl_ElementInfo), new PropertyMetadata(null, new PropertyChangedCallback( onChangePath)));

        private static void onChangePath(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_ElementInfo u = d as UserControl_ElementInfo;
            if (Directory.Exists(u.pathZal) == false)
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

        public Visibility comboVisibility
        {
            get { return (Visibility)GetValue(comboVisibilityProperty); }
            set { SetValue(comboVisibilityProperty, value); }
        }

        public static readonly DependencyProperty comboVisibilityProperty =
            DependencyProperty.Register("comboVisibility", typeof(Visibility), typeof(UserControl_ElementInfo), new PropertyMetadata(Visibility.Hidden));

        //#region COMBO
        //public IEnumerable comboList
        //{
        //    get { return (IEnumerable)GetValue(comboListProperty); }
        //    set { SetValue(comboListProperty, value); }
        //}

        //public static readonly DependencyProperty comboListProperty =
        //    DependencyProperty.Register("comboList", typeof(IEnumerable), typeof(UserControl_ElementInfo));

        //public string comboDispMember
        //{
        //    get { return (string)GetValue(comboDispMemberProperty); }
        //    set { SetValue(comboDispMemberProperty, value); }
        //}

        //public static readonly DependencyProperty comboDispMemberProperty =
        //    DependencyProperty.Register("comboDispMember", typeof(string), typeof(UserControl_ElementInfo));

        //public object comboSelValue
        //{
        //    get { return (object)GetValue(comboSelValueProperty); }
        //    set { SetValue(comboSelValueProperty, value); }
        //}

        //public static readonly DependencyProperty comboSelValueProperty =
        //    DependencyProperty.Register("comboSelValue", typeof(object), typeof(UserControl_ElementInfo));

        //public string comboSelValPath
        //{
        //    get { return (string)GetValue(comboSelValPathProperty); }
        //    set { SetValue(comboSelValPathProperty, value); }
        //}

        //public static readonly DependencyProperty comboSelValPathProperty =
        //    DependencyProperty.Register("comboSelValPath", typeof(string), typeof(UserControl_ElementInfo));
        //#endregion

    }
}

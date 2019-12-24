using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_DecyzjeAdmin : UserControl
    {
        public UserControl_DecyzjeAdmin()
        {
            InitializeComponent();
            DataContext = this;

            initButtons();
        }

        #region Buttons
        public ICommand clickAdd { get; set; }
        public ICommand clickCls { get; set; }
        public ICommand clickMod { get; set; }
        public ICommand clickZal { get; set; }

        #region Buttons Visibility

        public bool addButtonDec
        {
            get { return (bool)GetValue(addButtonDecProperty); }
            set { SetValue(addButtonDecProperty, value); }
        }

        public static readonly DependencyProperty addButtonDecProperty =
            DependencyProperty.Register("addButtonDec", typeof(bool), typeof(UserControl_Transakcja), new PropertyMetadata(false));

        public bool modButtonDec
        {
            get { return (bool)GetValue(modButtonDecProperty); }
            set { SetValue(modButtonDecProperty, value); }
        }

        public static readonly DependencyProperty modButtonDecProperty =
            DependencyProperty.Register("modButtonDec", typeof(bool), typeof(UserControl_Transakcja), new PropertyMetadata(false));

        public bool clsButtonDec
        {
            get { return (bool)GetValue(clsButtonDecProperty); }
            set { SetValue(clsButtonDecProperty, value); }
        }

        public static readonly DependencyProperty clsButtonDecProperty =
            DependencyProperty.Register("clsButtonDec", typeof(bool), typeof(UserControl_Transakcja), new PropertyMetadata(false));

        public bool zalButtonDec
        {
            get { return (bool)GetValue(zalButtonDecProperty); }
            set { SetValue(zalButtonDecProperty, value); }
        }

        public static readonly DependencyProperty zalButtonDecProperty =
            DependencyProperty.Register("zalButtonDec", typeof(bool), typeof(UserControl_Transakcja), new PropertyMetadata(false));

        #endregion

        private void initButtons()
        {
            clickAdd = new RelayCommand(onClickAdd);
            clickCls = new RelayCommand(onClickCls);
            clickMod = new RelayCommand(onClickMod);
            clickZal = new RelayCommand(onClickZalacznik);
        }

        private void onClickZalacznik()
        {
            throw new NotImplementedException();
        }

        private void onClickMod()
        {
            throw new NotImplementedException();
        }

        private void onClickCls()
        {
            throw new NotImplementedException();
        }

        private void onClickAdd()
        {
            throw new NotImplementedException();
        }
        #endregion

        public string  NumerDecAdmin
        {
            get { return (string )GetValue(NumerDecAdminProperty); }
            set { SetValue(NumerDecAdminProperty, value); }
        }

        public static readonly DependencyProperty NumerDecAdminProperty =
            DependencyProperty.Register("NumerDecAdmin", typeof(string ), typeof(UserControl_DecyzjeAdmin), new PropertyMetadata(null, new PropertyChangedCallback(onNumerDecAdminChange)));

        private static void onNumerDecAdminChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_DecyzjeAdmin u = d as UserControl_DecyzjeAdmin;

            if (u.NumerDecAdmin != null)
            {
               
                if (u.selectedIdDec > 0)
                {
                    u.addButtonDec = false;
                    u.clsButtonDec = true;
                }
                else
                {
                    var v = u.decyzjeList.FirstOrDefault(row => row.Numer == u.NumerDecAdmin);

                    int a = 13;
                    if (v != null)
                    {
                        u.addButtonDec = false;
                        u.clsButtonDec = true;
                    }
                    else
                    {
                        u.addButtonDec = true;
                        u.clsButtonDec = true;
                    }
                }
            }
            else
                u.selectedIdDec = null;

        }

        public DecyzjeAdministracyjne decyzjeAdmin
        {
            get { return (DecyzjeAdministracyjne)GetValue(decyzjeAdminProperty); }
            set { SetValue(decyzjeAdminProperty, value); }
        }

        public static readonly DependencyProperty decyzjeAdminProperty =
            DependencyProperty.Register("decyzjeAdmin", typeof(DecyzjeAdministracyjne), typeof(UserControl_DecyzjeAdmin), new PropertyMetadata( ondecyzjeAdminChanged));

        private static void ondecyzjeAdminChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
        }

        public int? selectedIdDec
        {
            get { return (int?)GetValue(selectedIdDecProperty); }
            set { SetValue(selectedIdDecProperty, value); }
        }

        public static readonly DependencyProperty selectedIdDecProperty =
            DependencyProperty.Register("selectedIdDec", typeof(int?), typeof(UserControl_DecyzjeAdmin), new PropertyMetadata(0, onDecyzjeChenged));

        private static void onDecyzjeChenged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_DecyzjeAdmin u = d as UserControl_DecyzjeAdmin;
            if (u.selectedIdDec != null)
            {
                if (u.selectedIdDec.Value <= 0)
                {
                    //string s = u.numerTrans;
                    u.decyzjeAdmin = new DecyzjeAdministracyjne();
                    //u.decyzjeAdmin.Numer = s;
                    u.decyzjeAdmin = null;
                    u.addButtonDec = true;
                    u.zalButtonDec = false;
                }
                else
                {
                    u.decyzjeAdmin = u.decyzjeList.FirstOrDefault(row => row.DecyzjeAdministracyjneId == u.selectedIdDec.Value);

                    //int a = 13;
                    //u.zalButtonDec = true;
                    u.decyzjeAdmin.onChange += u.Transakcje_onChange;
                }
            }
            //else
            //    u.clsDialog();
        }

        private void Transakcje_onChange(object sender, EventArgs e)
        {
            modButtonDec = true;
        }

        public ObservableCollection<DecyzjeAdministracyjne> decyzjeList
        {
            get { return (ObservableCollection<DecyzjeAdministracyjne> )GetValue(decyzjeListProperty); }
            set { SetValue(decyzjeListProperty, value); }
        }

        public static readonly DependencyProperty decyzjeListProperty =
            DependencyProperty.Register("decyzjeList", typeof(ObservableCollection<DecyzjeAdministracyjne> ), typeof(UserControl_DecyzjeAdmin));

        private void userControlDataGridRafALL_Loaded(object sender, RoutedEventArgs e)
        {
         
        }
    }
}

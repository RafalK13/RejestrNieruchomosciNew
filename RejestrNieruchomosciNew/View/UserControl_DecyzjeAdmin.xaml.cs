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
            DependencyProperty.Register("addButtonDec", typeof(bool), typeof(UserControl_DecyzjeAdmin), new PropertyMetadata(false));

        public bool modButtonDec
        {
            get { return (bool)GetValue(modButtonDecProperty); }
            set { SetValue(modButtonDecProperty, value); }
        }

        public static readonly DependencyProperty modButtonDecProperty =
            DependencyProperty.Register("modButtonDec", typeof(bool), typeof(UserControl_DecyzjeAdmin), new PropertyMetadata(false));

        public bool clsButtonDec
        {
            get { return (bool)GetValue(clsButtonDecProperty); }
            set { SetValue(clsButtonDecProperty, value); }
        }

        public static readonly DependencyProperty clsButtonDecProperty =
            DependencyProperty.Register("clsButtonDec", typeof(bool), typeof(UserControl_DecyzjeAdmin), new PropertyMetadata(false));

        public bool zalButtonDec
        {
            get { return (bool)GetValue(zalButtonDecProperty); }
            set { SetValue(zalButtonDecProperty, value); }
        }

        public static readonly DependencyProperty zalButtonDecProperty =
            DependencyProperty.Register("zalButtonDec", typeof(bool), typeof(UserControl_DecyzjeAdmin), new PropertyMetadata(false));

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

        private void onClickCls()
        {
            clsDialog();
            NumerDecAdmin = null;
            addButtonDec = false;
            modButtonDec = false;
            clsButtonDec = false;
            zalButtonDec = false;
        }

        private void onClickAdd()
        {
            decyzjeAdmin.Numer = NumerDecAdmin;
            decyzjeAdminList.AddRow(decyzjeAdmin);

            userControlDataGridRafALLDec.initItemSourceList();

            decyzjeAdmin = decyzjeAdminList.list.FirstOrDefault(row => row.Numer == NumerDecAdmin);
            selectedIdDec =decyzjeAdmin.DecyzjeAdministracyjneId;

            addButtonDec = false;
        }

        private void onClickMod()
        {
            decyzjeAdmin.Numer = NumerDecAdmin;

            decyzjeAdminList.ModRow(decyzjeAdmin);

            modButtonDec = false;
        }
        #endregion
        
        public IPodmiotList podmiotList
        {
            get { return (IPodmiotList)GetValue(podmiotListProperty); }
            set { SetValue(podmiotListProperty, value); }
        }

        public static readonly DependencyProperty podmiotListProperty =
            DependencyProperty.Register("podmiotList", typeof(IPodmiotList), typeof(UserControl_DecyzjeAdmin));

        public string PodmiotNazwa
        {
            get { return (string)GetValue(PodmiotNazwaProperty); }
            set { SetValue(PodmiotNazwaProperty, value); }
        }

        public static readonly DependencyProperty PodmiotNazwaProperty =
            DependencyProperty.Register("PodmiotNazwa", typeof(string), typeof(UserControl_DecyzjeAdmin));
        
        public int? selectedIdPodm
        {
            get { return (int?)GetValue(selectedIdPodmProperty); }
            set { SetValue(selectedIdPodmProperty, value); }
        }

        public static readonly DependencyProperty selectedIdPodmProperty =
            DependencyProperty.Register("selectedIdPodm", typeof(int?), typeof(UserControl_DecyzjeAdmin), new PropertyMetadata( onPodmiotChanged));

        private static void onPodmiotChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_DecyzjeAdmin u = d as UserControl_DecyzjeAdmin;

            //if (u.decyzjeAdmin.PodmiotId > 0)
            {
                u.decyzjeAdmin.PodmiotId = u.selectedIdPodm;
            }
            //else
            //    u.decyzjeAdmin.PodmiotId = null;
        }

        public DecyzjeAdministracyjneList decyzjeAdminList
        {
            get { return (DecyzjeAdministracyjneList)GetValue(decyzjeAdminListProperty); }
            set { SetValue(decyzjeAdminListProperty, value); }
        }

        public static readonly DependencyProperty decyzjeAdminListProperty =
            DependencyProperty.Register("decyzjeAdminList", typeof(DecyzjeAdministracyjneList), typeof(UserControl_DecyzjeAdmin));

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
                    u.modButtonDec = false;
                    u.clsButtonDec = true;
                }
                else
                {
                    var v = u.decyzjeAdminList.list.FirstOrDefault(row => row.Numer == u.NumerDecAdmin);

                    if (v != null)
                    {
                        u.addButtonDec = false;
                        u.modButtonDec = true;
                        u.clsButtonDec = true;
                    }
                    else
                    {
                        u.selectedIdDec = 0;
                        u.addButtonDec = true;
                        u.modButtonDec = false;
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
            DependencyProperty.Register("decyzjeAdmin", typeof(DecyzjeAdministracyjne), typeof(UserControl_DecyzjeAdmin));

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
                    string s = u.NumerDecAdmin;
                    u.decyzjeAdmin = new DecyzjeAdministracyjne();
                    u.decyzjeAdmin.Numer = s;
                    u.PodmiotNazwa = string.Empty;
                    u.selectedIdDec = 0;
                    u.addButtonDec = true;
                    u.zalButtonDec = false;
                }
                else
                {
                    int selIdDec = u.selectedIdDec.Value;
                    u.decyzjeAdmin = u.decyzjeAdminList.list.FirstOrDefault(row => row.DecyzjeAdministracyjneId == selIdDec);
                   
                    if (u.decyzjeAdmin.PodmiotId == 0 || u.decyzjeAdmin.PodmiotId == null)
                        u.PodmiotNazwa = string.Empty;
                    else
                        u.PodmiotNazwa = u.podmiotList.list.FirstOrDefault(r => r.PodmiotId == u.decyzjeAdmin.PodmiotId).Name;

                    u.decyzjeAdmin.onChange += u.DecyzjeAdmin_onChange;
                }
            }
            else
            {
                u.decyzjeAdmin = new DecyzjeAdministracyjne();

                u.selectedIdDec = null;
                u.PodmiotNazwa = string.Empty;
                u.NumerDecAdmin = string.Empty;
            }
        }

        private void DecyzjeAdmin_onChange(object sender, EventArgs e)
        {
            modButtonDec = true;
        }
       
        private void userControlDataGridRafALL_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        #region clsDialog
        private void clsDialog()
        {
            decyzjeAdmin = new DecyzjeAdministracyjne();

            selectedIdDec= null;
            NumerDecAdmin = string.Empty;
            PodmiotNazwa = string.Empty;
        }
        #endregion
    }
}

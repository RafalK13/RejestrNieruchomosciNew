using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_Transakcja : UserControl
    {
        public UserControl_Transakcja()
        {
            InitializeComponent();
            DataContext = this;
            clickAdd = new RelayCommand(onClickAdd);
            clickCls = new RelayCommand(onClickCls);
            clickMod = new RelayCommand(onClickMod);
            clickZal = new RelayCommand(onClickZalacznik);
        }



        public string zalPath
        {
            get { return (string)GetValue(zalPathProperty); }
            set { SetValue(zalPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for zalPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty zalPathProperty =
            DependencyProperty.Register("zalPath", typeof(string), typeof(UserControl_Transakcja), new PropertyMetadata(null));



        //private string _zalPath;
        //public string zalPath
        //{
        //    get 
        //    {
        //        return _zalPath;
        //    }

        //    set {
        //        _zalPath = value; //ConfigurationManager.AppSettings["zalacznikPath"] + "\\Transakcje\\" + selectedIdTrans;

        //        //MessageBox.Show(zalPath);
        //    }

        //    //get
        //    //{
        //    //    return ConfigurationManager.AppSettings["zalacznikPath"] + "\\Transakcje\\" + selectedIdTrans;
        //    //}
        //}

        //zalPath = ConfigurationManager.AppSettings["zalacznikPath"] + "\\Transakcje\\" + transakcje.TransakcjeId;
        #region Transakcje
        public ITransakcje transakcje
        {
            get { return (ITransakcje)GetValue(transakcjeProperty); }
            set { SetValue(transakcjeProperty, value); }
        }

        public static readonly DependencyProperty transakcjeProperty =
            DependencyProperty.Register("transakcje", typeof(ITransakcje), typeof(UserControl_Transakcja), new PropertyMetadata(null));
        #endregion

        #region TransacjeList

        public TransakcjeList transList
        {
            get { return (TransakcjeList)GetValue(transListProperty); }
            set { SetValue(transListProperty, value); }
        }

        public static readonly DependencyProperty transListProperty =
            DependencyProperty.Register("transList", typeof(TransakcjeList), typeof(UserControl_Transakcja));

        #endregion

        #region ItemSourceTrans
        public ObservableCollection<ITransakcje> itemSourceTrans
        {
            get { return (ObservableCollection<ITransakcje>)GetValue(itemSourceTransProperty); }
            set { SetValue(itemSourceTransProperty, value); }
        }

        public static readonly DependencyProperty itemSourceTransProperty =
            DependencyProperty.Register("itemSourceTrans", typeof(ObservableCollection<ITransakcje>), typeof(UserControl_Transakcja));

        #endregion

        #region NumerTrans
        public string numerTrans
        {
            get { return (string)GetValue(numerTransProperty); }
            set { SetValue(numerTransProperty, value); }
        }
        public static readonly DependencyProperty numerTransProperty =
            DependencyProperty.Register("numerTrans", typeof(string), typeof(UserControl_Transakcja), new PropertyMetadata(null, new PropertyChangedCallback(onNumerTransChange)));

        private static void onNumerTransChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Transakcja u = d as UserControl_Transakcja;

            if (u.numerTrans != null)
            {
                if (u.selectedIdTrans > 0)
                {
                    u.addButton = false;
                    u.clsButton = true;
                }
                else
                {
                    var v = u.transList.list.FirstOrDefault(row => row.Numer == u.numerTrans);

                    if (v != null)
                    {
                        u.addButton = false;
                        u.clsButton = true;
                    }
                    else
                    {
                        u.addButton = true;
                        u.clsButton = true;
                    }
                }
            }
            else
                u.selectedIdTrans = null;

        }
        #endregion

        #region SelectedIdTrans
        public int? selectedIdTrans
        {
            get { return (int?)GetValue(selectedIdTransProperty); }
            set { SetValue(selectedIdTransProperty, value); }
        }

        public static readonly DependencyProperty selectedIdTransProperty =
            DependencyProperty.Register("selectedIdTrans", typeof(int?), typeof(UserControl_Transakcja), new PropertyMetadata(0, new PropertyChangedCallback(onSelectedIdTransChanged)));

        private static void onSelectedIdTransChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_Transakcja u = d as UserControl_Transakcja;
            if (u.selectedIdTrans != null)
            {
                if (u.selectedIdTrans.Value <= 0)
                {
                    string s = u.numerTrans;
                    u.transakcje = new Transakcje();
                    u.transakcje.Numer = s;
                    u.selectedIdTrans = 0;
                    u.addButton = true;
                    u.zalButton = false;
                }
                else
                {
                    int selIdTrans = u.selectedIdTrans.Value;
                    u.transakcje = u.itemSourceTrans.FirstOrDefault(row => row.TransakcjeId == selIdTrans);
                    u.zalButton = true;
                    u.transakcje.onChange += u.Transakcje_onChange;
                }
            }
            else
                u.clsDialog();

            u.zalPath = ConfigurationManager.AppSettings["zalacznikPath"] + "\\Transakcje\\" + u.selectedIdTrans;

            //MessageBox.Show( u.selectedIdTrans.ToString());

        }
        #endregion

        #region Buttons Visibility

        public bool addButton
        {
            get { return (bool)GetValue(addButtonProperty); }
            set { SetValue(addButtonProperty, value); }
        }

        public static readonly DependencyProperty addButtonProperty =
            DependencyProperty.Register("addButton", typeof(bool), typeof(UserControl_Transakcja), new PropertyMetadata(false));

        public bool modButton
        {
            get { return (bool)GetValue(modButtonProperty); }
            set { SetValue(modButtonProperty, value); }
        }

        public static readonly DependencyProperty modButtonProperty =
            DependencyProperty.Register("modButton", typeof(bool), typeof(UserControl_Transakcja), new PropertyMetadata(false));

        public bool clsButton
        {
            get { return (bool)GetValue(clsButtonProperty); }
            set { SetValue(clsButtonProperty, value); }
        }

        public static readonly DependencyProperty clsButtonProperty =
            DependencyProperty.Register("clsButton", typeof(bool), typeof(UserControl_Transakcja), new PropertyMetadata(false));

        public bool zalButton
        {
            get { return (bool)GetValue(zalButtonProperty); }
            set { SetValue(zalButtonProperty, value); }
        }

        public static readonly DependencyProperty zalButtonProperty =
            DependencyProperty.Register("zalButton", typeof(bool), typeof(UserControl_Transakcja), new PropertyMetadata(false));

        #endregion

        #region Buttons
        #region clsDialog
        private void clsDialog()
        {
            transakcje = new Transakcje();

            selectedIdTrans = null;
            numerTrans = string.Empty;
        }
        #endregion

        public void onClickAdd()
        {
            transakcje.Numer = numerTrans;
            transList.AddRow(transakcje);

            userControlDataGridRafALL.initItemSourceList();

            transakcje = itemSourceTrans.FirstOrDefault(row => row.Numer == numerTrans);
            selectedIdTrans = transakcje.TransakcjeId.Value;

            addButton = false;
        }

        private void onClickCls()
        {
            clsDialog();
            numerTrans = null;
            addButton = false;
            modButton = false;
            clsButton = false;
            zalButton = false;
        }

        public void onClickMod()
        {
            transakcje.Numer = numerTrans;

            transList.ModRow(transakcje);

            modButton = false;
        }

        public void onClickZalacznik()
        {
            string zalPath = ConfigurationManager.AppSettings["zalacznikPath"] + "\\Transakcje\\" + transakcje.TransakcjeId;

            transakcje.Skan = zalPath;

            DirectoryInfo dir = new DirectoryInfo(zalPath);
            if (!dir.Exists)
                dir.Create();

            Process.Start(zalPath);
        }

        public ICommand clickAdd { get; set; }
        public ICommand clickCls { get; set; }
        public ICommand clickMod { get; set; }
        public ICommand clickZal { get; set; }
        #endregion

        #region Slowniki
        public RodzajDokumentuList rodzDokSlo
        {
            get { return (RodzajDokumentuList)GetValue(rodzDokSloProperty); }
            set { SetValue(rodzDokSloProperty, value); }
        }
        public static readonly DependencyProperty rodzDokSloProperty =
            DependencyProperty.Register("rodzDokSlo", typeof(RodzajDokumentuList), typeof(UserControl_Transakcja));

        public NazwaCzynnosciList nazwaCzynSlo
        {
            get { return (NazwaCzynnosciList)GetValue(nazwaCzynSloProperty); }
            set { SetValue(nazwaCzynSloProperty, value); }
        }

        public static readonly DependencyProperty nazwaCzynSloProperty =
            DependencyProperty.Register("nazwaCzynSlo", typeof(NazwaCzynnosciList), typeof(UserControl_Transakcja));

        #endregion

        #region Events
        private void Trans_Loaded(object sender, RoutedEventArgs e)
        {
            if (transList != null)
                itemSourceTrans = transList.list;
        }

        private void Transakcje_onChange(object sender, EventArgs e)
        {
            modButton = true;
        }
        #endregion
    }
}

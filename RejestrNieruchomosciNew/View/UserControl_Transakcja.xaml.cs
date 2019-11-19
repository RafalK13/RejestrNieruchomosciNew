﻿using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        }
        
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

        #region itemSourceTrans
        public ObservableCollection<ITransakcje> itemSourceTrans
        {
            get { return (ObservableCollection<ITransakcje>)GetValue(itemSourceTransProperty); }
            set { SetValue(itemSourceTransProperty, value); }
        }

        public static readonly DependencyProperty itemSourceTransProperty =
            DependencyProperty.Register("itemSourceTrans", typeof(ObservableCollection<ITransakcje>), typeof(UserControl_Transakcja));

        #endregion

        #region numerTrans
        public string numerTrans
        {
            get { return (string)GetValue(numerTransProperty); }
            set { SetValue(numerTransProperty, value); }
        }
        public static readonly DependencyProperty numerTransProperty =
            DependencyProperty.Register("numerTrans", typeof(string), typeof(UserControl_Transakcja), new PropertyMetadata( null, new PropertyChangedCallback(onNumerTransChange)));

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

        #region selectedIdTrans
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
                    u.selectedIdTrans = null;
                    u.addButton = true;
                }
                else
                {
                    u.transakcje = u.itemSourceTrans.FirstOrDefault(row => row.TransakcjeId == u.selectedIdTrans.Value);
                    u.transakcje.onChange += u.Transakcje_onChange;
                }
            }
        }
        #endregion

        #region Buttons Visible

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

        #endregion

        #region Buttons
        #region clsDialog
        private void clsDialog()
        {
            transakcje = new Transakcje();
         
            selectedIdTrans = null;
        }
        #endregion

        public void onClickAdd()
        {
            transakcje.Numer = numerTrans;
            transList.AddRow( transakcje);
            
            userControlDataGridRafALL.initItemSourceList();

            transakcje = itemSourceTrans.FirstOrDefault(row => row.Numer == numerTrans);
            selectedIdTrans = transakcje.TransakcjeId.Value;

            addButton = false;
        }
        
        private void onClickCls()
        {
            clsDialog();
            addButton = false;
            modButton = false;
            clsButton = false;
        }

        public void onClickMod()
        {
            transakcje.Numer = numerTrans;
         
            transList.ModRow( transakcje);

            modButton = false;
        }

        public ICommand clickAdd { get; set; }
        public ICommand clickCls { get; set; }
        public ICommand clickMod { get; set; }
        #endregion

        #region slowniki
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

        private void Trans_Loaded(object sender, RoutedEventArgs e)
        {
            if ( transList != null )
                itemSourceTrans = transList.list;
        }

        private void Transakcje_onChange(object sender, EventArgs e)
        {
            modButton = true;
        }
    }
}

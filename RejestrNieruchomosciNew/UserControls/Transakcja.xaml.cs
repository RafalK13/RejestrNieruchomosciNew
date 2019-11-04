using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.UserControls
{
    public partial class Transakcja : UserControl
    {
        public ICommand addClick { get; set; }
        
        public Transakcja()
        {
            InitializeComponent();
            DataContext = this;

            initCommand();
        }

        private void initCommand()
        {
            addClick = new RelayCommand(onAddClick);
        }



        public ITransakcjeList transListRaf
        {
            get { return (ITransakcjeList)GetValue(transListRafProperty); }
            set { SetValue(transListRafProperty, value); }
        }
        
        public static readonly DependencyProperty transListRafProperty =
            DependencyProperty.Register("transListRaf", typeof(ITransakcjeList), typeof(Transakcja));

        //public IEnumerable transListRaf
        //{
        //    get { return (ITransakcjeList)GetValue(transListProperty); }
        //    set { SetValue(transListProperty, value); }
        //}

        //public static readonly DependencyProperty transListProperty =
        //    DependencyProperty.Register("transListRaf", typeof(ITransakcjeList), typeof(Transakcja));

        private void onAddClick()
        {
            MessageBox.Show(transListRaf.list.Count.ToString());
        }
    }
}

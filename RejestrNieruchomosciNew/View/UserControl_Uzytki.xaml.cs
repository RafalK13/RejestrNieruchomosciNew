using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_Uzytki : UserControl
    {
        public UserControl_Uzytki()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<Uzytki> uzytkiListRaf
        {
            get { return (ObservableCollection<Uzytki>)GetValue(uzytkiListRafProperty); }
            set { SetValue(uzytkiListRafProperty, value); }
        }

        public static readonly DependencyProperty uzytkiListRafProperty =
            DependencyProperty.Register("uzytkiListRaf", typeof(ObservableCollection<Uzytki>), typeof(UserControl_Uzytki));

        public UzytkiList uzytkiList
        {
            get { return (UzytkiList)GetValue(uzytkiListProperty); }
            set { SetValue(uzytkiListProperty, value); }
        }

        public static readonly DependencyProperty uzytkiListProperty =
            DependencyProperty.Register("uzytkiList", typeof(UzytkiList), typeof(UserControl_Uzytki));

        public UzytkiSloList uzytkiSloList
        {
            get { return (UzytkiSloList)GetValue(uzytkiSloListProperty); }
            set { SetValue(uzytkiSloListProperty, value); }
        }

        public static readonly DependencyProperty uzytkiSloListProperty =
            DependencyProperty.Register("uzytkiSloList", typeof(UzytkiSloList), typeof(UserControl_Uzytki));

        private void gridRaf_Loaded(object sender, RoutedEventArgs e)
        {
            //gridRaf.ItemsSource = uzytkiListRaf;
            if (uzytkiListRaf != null)

            {
                gridColRaf.ItemsSource = uzytkiSloList.list;

                uzytkiListRaf.CollectionChanged += UzytkiListRaf_CollectionChanged;
            }

        }

        private void UzytkiListRaf_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    uzytkiListRaf[e.NewStartingIndex].DzialkaId = dzialka.DzialkaId;
                }
            }
        }

        public IDzialka dzialka
        {
            get { return (IDzialka)GetValue(dzialkaProperty); }
            set { SetValue(dzialkaProperty, value); }
        }

        public static readonly DependencyProperty dzialkaProperty =
            DependencyProperty.Register("dzialka", typeof(IDzialka), typeof(UserControl_Uzytki));

        private void GridRaf_CurrentCellChanged(object sender, EventArgs e)
        {
            powTotal = uzytkiListRaf.Sum(r => r.Pow);
      
            if (powTotal != 0 && dzialka.Pow != 0)
            {
                sizeAlert = (powTotal - dzialka.Pow) < 0.00001 ? false : true;
            }
        }

        public double? powTotal
        {
            get { return (double?)GetValue(powTotalProperty); }
            set { SetValue(powTotalProperty, value); }
        }

        public static readonly DependencyProperty powTotalProperty =
            DependencyProperty.Register("powTotal", typeof(double?), typeof(UserControl_Uzytki));

        public bool sizeAlert
        {
            get { return (bool)GetValue(sizeAlertProperty); }
            set { SetValue(sizeAlertProperty, value); }
        }

        public static readonly DependencyProperty sizeAlertProperty =
            DependencyProperty.Register("sizeAlert", typeof(bool), typeof(UserControl_Uzytki));



    }
}

using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class UzytkiSloList : ViewModelBase, IUzytkiSloList
    {
        private ObservableCollection<UzytkiSlo> _list;

        public ObservableCollection<UzytkiSlo> list
        {
            get => _list;
            set =>  Set(ref _list, value);
        }

        public UzytkiSloList()
        {
            fillUzytkiSloList();
        }

        private void fillUzytkiSloList()
        {
            using (var c = new Context())
            {
                try
                {
                    list = new ObservableCollection<UzytkiSlo>(c.UzytkiSlo);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"UzytkiSloLIst\r\n{e.Message}");
                    Environment.Exit(0);
                }
            }
        }
    }
}

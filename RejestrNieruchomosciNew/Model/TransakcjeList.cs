using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class TransakcjeList : ViewModelBase, ITransakcjeList
    {
        private ObservableCollection<ITransakcje> _list;
        public ObservableCollection<ITransakcje> list
        {
            get => _list;
            set
            {
                _list = value;
                RaisePropertyChanged("list");
            }
        }

        public TransakcjeList()
        {
            initList();
        }

        private void initList()
        {
            using (Context c = new Context())
            {
                list = new ObservableCollection<ITransakcje>(c.Transakcje);
            }
        }

        public void AddRow(ITransakcje newTrans) {
            using (Context c = new Context())
            {
                c.Transakcje.Add(((Transakcje)newTrans));
                c.SaveChanges();
            }
            list.Add(newTrans);
        }
        public void DelRow(IWladanie wlad) { }
        public void ModRow(IWladanie wlad) { }

    }
}

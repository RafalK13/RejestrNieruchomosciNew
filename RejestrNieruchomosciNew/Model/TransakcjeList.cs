using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
                try
                {
                    list = new ObservableCollection<ITransakcje>(c.Transakcje);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"TransakcjeList\r\n{e.Message}");
                    Environment.Exit(0);
                }
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
       
        public void ModRow(ITransakcje modTrans)
        {
            using (Context c = new Context())
            {
                c.Transakcje.Update((Transakcje)modTrans);
                c.SaveChanges();
            }
        }

        public void DelRow(IWladanie wlad) { }

    }
}

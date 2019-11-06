using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class TransakcjeList : ViewModelBase, ITransakcjeList
    {
        public ObservableCollection<ITransakcje> list { get; set; }

        public TransakcjeList()
        {
            using (Context c = new Context())
            {
                list = new ObservableCollection<ITransakcje>(c.Transakcje);
            }
        }

        public void AddRow(ITransakcje wlad) { }
        public void DelRow(IWladanie wlad) { }
        public void ModRow(IWladanie wlad) { }
    }
}

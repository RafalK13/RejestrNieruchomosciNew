using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model.Interfaces;
using System.Collections.ObjectModel;
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

        public void AddRow(ITransakcje wlad) {
            MessageBox.Show("RafałekADD");
        }
        public void DelRow(IWladanie wlad) { }
        public void ModRow(IWladanie wlad) { }
    }
}

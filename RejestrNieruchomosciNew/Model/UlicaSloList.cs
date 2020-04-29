using GalaSoft.MvvmLight;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class UlicaSloList : ViewModelBase, IUlicaSloList
    {
        private ObservableCollection<IUlicaSlo> _list;

        public ObservableCollection<IUlicaSlo> listAll { get; set; }
        public ObservableCollection<IUlicaSlo> list
        {
            get => _list;
            set => Set(ref _list, value);
        }

        public UlicaSloList()
        {
            initUlicaSloList();
        }

        private void initUlicaSloList()
        {
            try
            {
                Task task = Task.Run(() => fillAdresList());
                task.Wait();
            }
            catch (Exception e)
            {
                MessageBox.Show($"UliceSloList\r\n{e.Message}");
                Environment.Exit(0);
            }
        }

        private async Task fillAdresList()
        {
            using (var c = new Context())
            {
                listAll = new ObservableCollection<IUlicaSlo>(await c.UliceSlo.ToListAsync());
            }
        }

        private void initList(IMiejscowoscSlo miejscowosc)
        {
            int r1 = 13;
            if (miejscowosc != null)
                list = new ObservableCollection<IUlicaSlo>(listAll.Where(r => r.MiejscowoscUlice == miejscowosc.MiejscowoscUlice));
        }

        public void getList(IMiejscowoscSlo miejscowosc)
        {
            int r = 13;
            initList(miejscowosc);
        }

    }
}

using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model.Interfaces;
using RejestrNieruchomosciNew.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class LokalList : ILokalList
    {
        public ObservableCollection<ILokal> listAll { get; set; }
        public ObservableCollection<ILokal> list { get; set; }

        public string result;
        private IDzialka dzialkaPrv;


        public LokalList()
        {

        }

        public LokalList(UserControl_PreviewViewModel userPrev)
        {
            if (userPrev.dzialkaSel != null)
            {
                dzialkaPrv = userPrev.dzialkaSel;
                initListAll();
            }
        }

        private void initListAll()
        {
            try
            {
                Task task = Task.Run(() => fillLokalList());
                task.Wait();
            }
            catch (Exception e)
            {
                MessageBox.Show($"DzialkaList\r\n{e.Message}");
                Environment.Exit(0);
            }
        }

        private async Task fillLokalList()
        {
            using (var c = new Context())
            {
                //listAll = new ObservableCollection<ILokal>(await c.Lokal.ToListAsync());
            }
        }

        public void getList(IBudynek budSel)
        {
            list = new ObservableCollection<ILokal>( listAll.Where( r=>r.BudynekId == budSel.BudynekId ));
        }

        public void saveLokale()
        {
            throw new NotImplementedException();
        }
    }
}

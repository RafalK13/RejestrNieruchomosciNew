﻿using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class PlatnoscList
    {
        public ObservableCollection<PlatnoscUW> listPlatnoscUW { get; set; }
        public ObservableCollection<PlatnoscInnePrawa> listPlatnoscInnePr { get; set; }

        public PlatnoscList()
        {
            //initPaltnosciUW();
        }

        private void initPaltnosciUW()
        {
            Task task = Task.Run(() => fillPlatnoasciUWList());
            task.Wait();
        }

        private async Task fillPlatnoasciUWList()
        {
            using (var c = new Context())
            {
                listPlatnoscUW = new ObservableCollection<PlatnoscUW>( await c.PlatnoscUW.ToListAsync());
            }
        }
    }
}
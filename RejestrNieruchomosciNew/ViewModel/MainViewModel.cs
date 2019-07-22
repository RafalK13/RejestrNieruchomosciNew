using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class MainViewModel
    {
        #region Properties
        private string _modeMessage;
        public string modeMessage
        {
            get => _modeMessage;
            set
            {
                _modeMessage = value;
                OnPropertyChanged("modeMessage");
            }
        }

        public ObservableCollection<Dzialka> dzialkaList { get; set; }

        //public ICollectionView dzialkaView
        //{
        //    get
        //    {
        //        return CollectionViewSource.GetDefaultView(dzialkaList);
        //    }
        //}

        #endregion

        #region Konstruktor
        public MainViewModel()
        {
           
            modeMessage = "Hanka";
            
            //initDzialkaList();          
        }
        #endregion
        
        #region Metods
        private void initDzialkaList()
        {
            Task task = Task.Run(() => fillDzialkaList());
            task.Wait();
        }

        private async Task fillDzialkaList()
        {
            using (var c = new Context())
            {
                dzialkaList =  new ObservableCollection<Dzialka>( await c.Dzialka.Include(a => a.Obreb).ThenInclude(a => a.GminaSlo).ToListAsync());
            }
        }
        #endregion

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties

        #region privateProperties
        private string _modeMessage;
        public Dzialka _dzialkaSel;
        #endregion
        public string modeMessage
        {
            get => _modeMessage;
            set
            {
                _modeMessage = value;
                RaisePropertyChanged("modeMessage");
            }
        }

        public ObservableCollection<Dzialka> dzialkaList { get; set; }

        public ICollectionView dzialkaView
        {
            get
            {
                return CollectionViewSource.GetDefaultView(dzialkaList);
            }
        }

        public Dzialka dzialkaSel
        {
            get => _dzialkaSel; set
            {
                _dzialkaSel = value;
                RaisePropertyChanged("dzialkaSel");
                MessageBox.Show( $"{dzialkaSel.Numer}, {dzialkaSel.Obreb.GminaSlo.Nazwa}, {dzialkaSel.Obreb.Nazwa}" );
            }
        }

        public ICommand dubleClick { get; set; }

        #endregion
        #region Konstruktor
        public MainViewModel()
        {
            modeMessage = "Hanka";
            initDzialkaList();
            dubleClick = new RelayCommand(onClicked);
           
        }

        private void onClicked()
        {
            MessageBox.Show(dzialkaSel.Numer);
        }

        #endregion

        #region Metods
        public void initDzialkaList()
        {
            Task task = Task.Run(() => fillDzialkaList());
            task.Wait();
        }

        private async Task fillDzialkaList()
        {
            using (var c = new Context())
            {
                dzialkaList = new ObservableCollection<Dzialka>(await c.Dzialka.Include(a => a.Obreb).ThenInclude(a => a.GminaSlo).ToListAsync());
            }
        }
        #endregion        
    }
}
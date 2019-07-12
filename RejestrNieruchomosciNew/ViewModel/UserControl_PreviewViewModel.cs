using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.EntityFrameworkCore;
using RejestrNieruchomosciNew.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_PreviewViewModel : ViewModelBase
    {
        #region Properties

        #region privateProperties
        private string _modeMessage;
        public Dzialka _dzialkaSel;
        #endregion

        public ICommand dubleClick { get; set; }
        //public ObservableCollection<Dzialka> dzialkaList { get; set; }

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
                //MessageBox.Show($"{dzialkaSel.Numer}, {dzialkaSel.Obreb.GminaSlo.Nazwa}, {dzialkaSel.Obreb.Nazwa}");
            }
        }

        private ObrebClass _obreb;
        public ObrebClass obreb
        {
            get => _obreb;
            set
            {
                _obreb = value;
                RaisePropertyChanged("obreb");
               
            }
        }

        private object _obj;
        public object obj
        {
            get => _obj;
            set
            {
                _obj = value;
                RaisePropertyChanged("obj");
                setFilter();
            }
        }

        private List<Dzialka> _dzialkaList;
        public List<Dzialka> dzialkaList
        {
            get => _dzialkaList;
            set
            {
                _dzialkaList = value;
                RaisePropertyChanged("dzialkaList");
                RaisePropertyChanged("dzialkaView");
            }
        }




        private string _dzialkaNr;
        public string dzialkaNr
        {
            get => _dzialkaNr;
            set
            {
                _dzialkaNr = value;
                RaisePropertyChanged("dzialkaNr");
                setFilter();
            }
        }

        private string _result;
        public string result
        {
            get => _result;
            set
            {
                _result = value;
                RaisePropertyChanged("result");
            }
        }

        //private ObrebClass _obreb;
        //public ObrebClass obreb
        //{
        //    get => _obreb;
        //    set
        //    {
        //        _obreb = value;
        //        OnPropertyChanged("obreb");
        //    }
        //}
        #endregion

        #region Konstructor


        public UserControl_PreviewViewModel()
        {
            initDzialkaList();
            var v = ServiceLocator.Current.GetInstance<MainViewModel>();
            v.modeMessage = "Przeglądanie bazy";

            dubleClick = new RelayCommand(onClicked);

            obreb = new ObrebClass();

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
                //dzialkaList = new ObservableCollection<Dzialka>(await c.Dzialka.Include(a => a.Obreb).ThenInclude(a => a.GminaSlo).ToListAsync());
                dzialkaList = new List<Dzialka>(await c.Dzialka.Include(a => a.Obreb).ThenInclude(a => a.GminaSlo).ToListAsync());
            }
        }

        private void onClicked()
        {
            MessageBox.Show(dzialkaSel.Numer);
        }


        //private void Obreb_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    setFilter();
        //}

        public void setFilter()
        {
            dzialkaView.Filter = row =>
            {
                Dzialka d = row as Dzialka;

                bool nb = testString(dzialkaNr) ? d.Numer.Contains(dzialkaNr) : false;
                bool ob = testString(obreb.obrebValue) ? d.Obreb.Nazwa.Contains(obreb.obrebValue) : false;
                bool gb = testString(obreb.gminaValue) ? d.Obreb.GminaSlo.Nazwa.Contains(obreb.gminaValue) : false;

                return nb && ob && gb;
            };
            result = dzialkaView.Cast<object>().Count().ToString();
        }

        private bool testString(string s) => s == null ? false : true;

        //internal void clearResult()
        //{
        //    dzialkaNr = string.Empty;
        //    obreb.obrebValue = string.Empty;
        //    obreb.gminaValue = string.Empty;
        //}

        //public async Task initAllDzialka()
        //{
        //    using (var c = new Context())
        //    {
        //        dzialkaList = await c.Dzialka.Include(a => a.Obreb).ThenInclude(a => a.GminaSlo).ToListAsync();
        //    }
        //    result = dzialkaView.Cast<object>().Count().ToString();
        //}

        //public void refreshView()
        //{
        //    dzialkaList.Clear();
        //    //initAllDzialka();
        //    dzialkaView.Refresh();
        //}

        #endregion


    }

}

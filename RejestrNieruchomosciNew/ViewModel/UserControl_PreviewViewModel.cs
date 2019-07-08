using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RejestrNieruchomosciNew.ViewModel
{
    class UserControl_PreviewViewModel : INotifyPropertyChanged
    {
        #region Properties

        MainViewModel main { get; set; }

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
        
        public ICollectionView dzialkaView
        {
            get
            {
                return CollectionViewSource.GetDefaultView(main.dzialkaList);
            }
        }

        //private List<Dzialka> _dzialkaList;
        //public List<Dzialka> dzialkaList
        //{
        //    get => _dzialkaList;
        //    set
        //    {
        //        _dzialkaList = value;
        //        OnPropertyChanged("dzialkaList");
        //        OnPropertyChanged("dzialkaView");
        //    }
        //}




        //private string _dzialkaNr;
        //public string dzialkaNr
        //{
        //    get => _dzialkaNr;
        //    set
        //    {
        //        _dzialkaNr = value;
        //        OnPropertyChanged("dzialkaNr");
        //        setFilter();
        //    }
        //}

        //private string _result;
        //public string result
        //{
        //    get => _result;
        //    set
        //    {
        //        _result = value;
        //        OnPropertyChanged("result");
        //    }
        //}

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
            main = new MainViewModel();
            modeMessage = "Przeglądanie bazy";
        }

        #endregion

        #region Metods

        //private void Obreb_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    setFilter();
        //}

        //public void setFilter()
        //{
        //    dzialkaView.Filter = row =>
        //    {
        //        Dzialka d = row as Dzialka;

        //        bool nb = testString(dzialkaNr) ? d.Numer.Contains(dzialkaNr) : false;
        //        bool ob = testString(obreb.obrebValue) ? d.Obreb.Nazwa.Contains(obreb.obrebValue) : false;
        //        bool gb = testString(obreb.gminaValue) ? d.Obreb.GminaSlo.Nazwa.Contains(obreb.gminaValue) : false;

        //        return nb && ob && gb;
        //    };
        //    result = dzialkaView.Cast<object>().Count().ToString();
        //}

        //private bool testString(string s) => s == null ? false : true;

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

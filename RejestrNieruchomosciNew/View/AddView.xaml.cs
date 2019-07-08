using RejestrNieruchomosciNew.ViewModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.View
{
    public partial class AddView : Window, INotifyPropertyChanged
    {
        #region Properties
        public AddViewModel addViewModel;
        #endregion

        #region Konstruktor
        public AddView()
        {
            InitializeComponent();
            addViewModel = new AddViewModel();

            DataContext = addViewModel;
        }
        #endregion

        #region Medods
       
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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    using ( var c = new Context())
        //    {
        //        addViewModel.dzialkaViewModel.dzialka.ObrebId = addViewModel.dzialkaViewModel.obreb.getId().Value;
        //        c.Dzialka.Add(addViewModel.dzialkaViewModel.dzialka);
        //        c.SaveChanges();
        //    }

        //    addViewModel.canAdd = false;
        //    addViewModel.dzialkaViewModel.dzialka.DzialkaId = 0;
        //}
    }
}

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using System;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties
        private bool _btActivity;
        public bool btActivity
        {
            get => _btActivity;
            set
            {
                _btActivity = value;
                RaisePropertyChanged("btActivity");
            }
        }

        public IViewFactory factory { get; set; }
        public ISelectorModel modelSel { get; set; }
        public IChangeViewModel model { get; set; }

        public UserControl_PreviewViewModel userControl_prev { get; set; }

        public ICommand addNewDzialka { get; set; }
        public ICommand delDzialka { get; set; }
        public ICommand modDzialka { get; set; }

        public string modeMessage { get; set; }
        #endregion

        #region Konstruktor
        public MainViewModel()
        {
            initButtonCommand();
            btActivity = true;
        }
        #endregion

        #region ButtonCommands
        private void initButtonCommand()
        {
            addNewDzialka = new RelayCommand(onAddNewDzialka);
            delDzialka = new RelayCommand(onDeleteDzialka);
            modDzialka = new RelayCommand(onModifyDzialka);
        }

        private void onModifyDzialka()
        {
            modelSel.selectedModel = factory.CreateView<IChangeViewModel>("Mod");

            //userControl_prev.modDzialka();

            var v = factory.CreateView<ChangeView>();
            v.Show();
        }

        private void onAddNewDzialka()
        {
            modelSel.selectedModel = factory.CreateView<IChangeViewModel>("Add");
            //userControl_prev.addDzialka();

            var v = factory.CreateView<ChangeView>();
            v.Show();
        }




        private void onDeleteDzialka()
        {
            userControl_prev.deleteDzialka();
        }

       

        #endregion
    }
}
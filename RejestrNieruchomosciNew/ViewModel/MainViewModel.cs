using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public enum ChangeMode { add, mod}
    
    public class MainViewModel : ViewModelBase
    {
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
        public UserControl_InfoMainViewModel infoMain { get; set; }

        public ICommand addNewDzialka { get; set; }
        public ICommand delDzialka { get; set; }
        public ICommand modDzialka { get; set; }
        public ICommand doubleClick { get; set; }
        public ICommand testClick { get; set; }
        public ICommand updateAll { get; set; }

        public string modeMessage { get; set; }

        public IPodmiotList podmiotList { get; set; }
        public PlatnoscList platnoscList { get; set; }

        public PerformMode mode { get; set; }

        public IDzialkaList dzialkaList { get; set; }

        public UpdateClass updateClass { get; set; }

        #region Konstruktor
        public MainViewModel( PerformMode mode)
        {
            modeMessage = "Przegl¹danie bazy dzia³ek";
            
            initButtonCommand();
            if( mode.workMod == PerformMode.workMode.admin)
                btActivity = true;
            else
                btActivity = false;
        }
        #endregion

        #region ButtonCommands
        private void initButtonCommand()
        {
            addNewDzialka = new RelayCommand(onAddNewDzialka);
            delDzialka = new RelayCommand(onDeleteDzialka);
            modDzialka = new RelayCommand(onModifyDzialka);
            doubleClick = new RelayCommand(onDoubleClick);
            testClick = new RelayCommand( onTestClick);
            updateAll = new RelayCommand(onUpdateAll);
        }

        private void onUpdateAll()
        {
            int r = 13;
        }

        private void onTestClick()
        {
        }

        private void onDoubleClick()
        {
            onModifyDzialka();
        }

        private void onModifyDzialka()
        {
            if (userControl_prev.dzialkaSel != null && mode.appMod == PerformMode.appMode.main)
            {
                mode.appMod = PerformMode.appMode.dod;
                var v = factory.CreateView<ChangeView>();
                v.DataContext = factory.CreateView<IChangeViewModel>("Mod");
                v.ShowDialog();
            }
        }

        private void onAddNewDzialka()
        {
            var v = factory.CreateView<ChangeView>();
            v.DataContext = factory.CreateView<IChangeViewModel>("Add");
            v.ShowDialog();
        }
        private void onDeleteDzialka()
        {
            userControl_prev.deleteDzialka();
        }
        #endregion
    }
}
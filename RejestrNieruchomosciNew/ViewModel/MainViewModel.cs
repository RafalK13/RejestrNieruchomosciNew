using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Installers;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.View;
using System.Windows;
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

        private string _modeMessage;
        public string modeMessage
        {
            get => _modeMessage; set
            {
                _modeMessage = value;
                RaisePropertyChanged("modeMessage");
            }
        }

        public AddView addView { get; set; }
        public UserControl_PreviewViewModel userControl_prev { get; set; }

        public DzialkaList dzialkaList { get; set; }

        //private List<Dzialka> _dzialkaList;
        //public List<Dzialka> dzialkaList
        //{
        //    get => _dzialkaList;
        //    set
        //    {
        //        _dzialkaList = value;
        //        RaisePropertyChanged("dzialkaList");
        //    }
        //}

        public ICommand addNewDzialka { get; set; }
        public ICommand delDzialka { get; set; }
        #endregion

        #region Konstruktor
        public MainViewModel()
        {
            initButtonCommand();
            btActivity = true;
            modeMessage = "Przegl¹danie dzia³ek";
            #region obs³uga messenger -REM
            //Messenger.Default.Register<MessagesRaf>( this, "Token1",  getMessage  );
            #endregion
        }
        #endregion

        #region methods
       
        #endregion

        #region Bootsrtap
        private IWindsorContainer BootStrap()
        {
             return new WindsorContainer().Install( new InstallersAdd());
        }
        #endregion

        #region ButtonCommands
        private void initButtonCommand()
        {
            addNewDzialka = new RelayCommand(onAddNewDzialka);
            delDzialka = new RelayCommand(onDeleteDzialka);
        }

        private void onDeleteDzialka()
        {
            deleteDzialka();
        }

        public void deleteDzialka()
        {
            Dzialka dz = userControl_prev.dzialkaSel;

            userControl_prev.dzialkiBase.deleteRow((IDzialka)dz);
            userControl_prev.dzialkaView.Refresh();
        }

        private void onAddNewDzialka()
        {
            btActivity = false;

            addView.Show();

            //var loc = ServiceLocator.Current.GetInstance<UserControl_PreviewViewModel>();
            //IDzialka dz = loc.dzialkaSel;

            //IDzialka dz = userControl_prev.dzialkaSel;
            
            //var container = BootStrap();
            //if (dz != null)
            //    container.Register(Component.For<IDzialka>().Named("Haneczka").Instance(dz).IsDefault());

            //var v = container.Resolve<AddView>();

            //v.Show();

            //container.Dispose();
        }
        #endregion

        #region obs³uga messenger -REM
        //private void getMessage(MessagesRaf message)
        //{
        //    btActivity = message.activity;
        //}
        #endregion
    }
}
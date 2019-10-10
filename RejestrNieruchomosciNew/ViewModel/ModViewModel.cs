using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel 
{
    public class ModViewModel : ViewModelBase, IChangeViewModel
    {
        [DoNotWire]
        public UserControl_DanePodstawoweViewModel userControl_AddDanePod { get; set; }
        public UserControl_PreviewViewModel userControl_prevModel { get; set; }

        #region ICommand
        public ICommand OnCloseWindow { get; set; }
        public ICommand OnAddDzialka { get; set; }
        #endregion

        public ModViewModel(UserControl_DanePodstawoweViewModel userPodst,
                            UserControl_PreviewViewModel userPrev)
        {

            //userPodst.dzialka.Numer = userPrev.dzialkaSel.Numer;
            //userPodst.dzialka.ObrebId = userPrev.dzialkaSel.ObrebId;
            //userPodst.dzialka.DzialkaId = userPrev.dzialkaSel.DzialkaId;
            //userPodst.dzialka.Kwakt = userPrev.dzialkaSel.Kwakt;
            //userPodst.dzialka.Kwzrob = userPrev.dzialkaSel.Kwzrob;
            //userPodst.dzialka.Pow = userPrev.dzialkaSel.Pow;

            userPodst.dzialka.copy(userPrev.dzialkaSel);
            userPodst.obreb.fillValues(userPrev.dzialkaSel);

            userControl_AddDanePod = userPodst;
            userControl_AddDanePod.changeMode = ChangeMode.mod;
            
            OnCloseWindow = new RelayCommand(onCloseWindow);
            OnAddDzialka = new RelayCommand(onAddDzialka);
        }

        public void onAddDzialka()
        {
            userControl_prevModel.dzialkiBase.ModRow( userControl_AddDanePod.dzialka);
            userControl_prevModel.dzialkaView.Refresh();
        }

        public void onCloseWindow()
        {
        }
    }
}

using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel 
{
    public class ModViewModel : ChangeViewModel
    {
        #region ICommand
        public ICommand OnCloseWindow { get; set; }
        public ICommand OnAddDzialka { get; set; }
        #endregion

        public ModViewModel(UserControl_DanePodstawoweViewModel userPodst,
                            UserControl_PreviewViewModel userPrev)
        {
            tabsVisible = true;

            userPodst.dzialka.copy(userPrev.dzialkaSel);
            userPodst.obreb.fillValues(userPrev.dzialkaSel);

            userControl_AddDanePod = userPodst;
            userControl_AddDanePod.changeMode = ChangeMode.mod;
            
            OnCloseWindow = new RelayCommand(onCloseWindow);
            OnAddDzialka = new RelayCommand(onAddDzialka);
        }

        public override void onAddDzialka()
        {
            userControl_prevModel.dzialkiBase.ModRow( userControl_AddDanePod.dzialka);
            userControl_prevModel.dzialkaView.Refresh();
        }

        public override void onCloseWindow()
        {
        }
    }
}

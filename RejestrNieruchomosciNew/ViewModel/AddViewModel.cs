using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{

    public class AddViewModel : ViewModelBase, IChangeViewModel
    {
        [DoNotWire]
        public UserControl_DanePodstawoweViewModel userControl_AddDanePod { get; set; }
        public UserControl_PreviewViewModel userControl_prevModel { get; set; }
        public UserControl_WlascicielViewModel userControl_Wlasciciel { get; set; }

        public IDzialkaList dzialkaList;

        #region ICommand
        public ICommand OnCloseWindow { get; set; }
        public ICommand OnAddDzialka { get; set; }
        #endregion

        public AddViewModel(UserControl_DanePodstawoweViewModel userPodst)
        {
            userControl_AddDanePod = userPodst;

            OnCloseWindow = new RelayCommand(onCloseWindow);
            OnAddDzialka = new RelayCommand(onAddDzialka);

            userControl_AddDanePod.changeMode = ChangeMode.add;
        }

        #region initCommands
        public void onAddDzialka()
        {
            userControl_prevModel.dzialkiBase.AddRow(userControl_AddDanePod.dzialka);
            userControl_prevModel.dzialkaView.Refresh();
        }

        public void onCloseWindow()
        {
        }
        #endregion
    }
}

#region rem
//if (userControl_AddDanePod.isNew == true)
//{
//    if (userControl_AddDanePod.dzialka.procDz == ProcessDzialka.add)
//        userControl_PrevViewModel.dzialkiBase.AddRow((Dzialka)userControl_AddDanePod.dzialka);
//    else
//    {
//        userControl_PrevViewModel.dzialkiBase.ModRow((Dzialka)userControl_AddDanePod.dzialka);
//    }

//    userControl_PrevViewModel.dzialkaView.Refresh();
//}
#endregion

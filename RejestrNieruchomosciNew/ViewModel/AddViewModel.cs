using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class AddViewModel : ChangeViewModel
    {
        //public IDzialkaList dzialkaList;

        #region ICommand
        public ICommand OnCloseWindow { get; set; }
        public ICommand OnAddDzialka { get; set; }
        #endregion

        public AddViewModel(UserControl_DanePodstawoweViewModel userPodst)
        {
            userControl_AddDanePod = userPodst;

            OnCloseWindow = new RelayCommand(onCloseWindow);
            OnAddDzialka = new RelayCommand(onAddDzialka);

            tabsVisible = false;

            userControl_AddDanePod.changeMode = ChangeMode.add;
        }

        #region initCommands
        public override  void onAddDzialka()
        {
            userControl_prevModel.dzialkiBase.AddRow(userControl_AddDanePod.dzialka);
            userControl_prevModel.dzialkaView.Refresh();
        }

        public override void onCloseWindow()
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

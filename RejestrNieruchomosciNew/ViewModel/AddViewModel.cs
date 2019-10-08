using Castle.Core;
using RejestrNieruchomosciNew.Model;
using System.Windows;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class AddViewModel : ChangeViewModel, IChangeViewModel
    {
        //public UserControl_DanePodstawoweViewModel userPodst { get; set; }


        public AddViewModel(UserControl_DanePodstawoweViewModel userPodst,
                            UserControl_PreviewViewModel userPrev
                           )
        {
           
        }

        #region initCommands
        public override void onAddDzialka()
        {
           // MessageBox.Show( base.userControl_AddDanePod.dzialka.Numer);
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

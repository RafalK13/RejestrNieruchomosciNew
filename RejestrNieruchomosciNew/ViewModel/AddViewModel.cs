using Castle.Core;
using RejestrNieruchomosciNew.Model;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class AddViewModel //: ChangeViewModel
    {
        [DoNotWire]
        public UserControl_DanePodstawoweViewModel userControl_AddDanePod { get; set; }

        [DoNotWire]
        public UserControl_DaneDodatkoweViewModel userControl_DaneDod { get; set; }

        [DoNotWire]
        public IDzialka dzialka { get; set; }

        public bool tabsVisible { get; set; }
        public string modeMessage { get; set; }

        public AddViewModel(UserControl_DanePodstawoweViewModel userPodst)
        {
            userControl_AddDanePod = userPodst;

            //OnCloseWindow = new RelayCommand(onCloseWindow);
            //OnAddDzialka = new RelayCommand(onAddDzialka);

            tabsVisible = false;

            userControl_AddDanePod.changeMode = ChangeMode.add;
            userControl_AddDanePod.cannAdres = false;
        }

        //#region initCommands
        //public override  void onAddDzialka()
        //{
        //    //MessageBox.Show("Add Model");
        //    //userControl_prevModel.dzialkiBase.AddRow(userControl_AddDanePod.dzialka);
        //    //userControl_prevModel.dzialkaView.Refresh();
        //}

        //public override void onCloseWindow()
        //{
        //}
        //#endregion
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

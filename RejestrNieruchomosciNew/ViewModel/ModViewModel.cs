using Castle.Core;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class ModViewModel : ChangeViewModel
    {
        #region ICommand
        //public ICommand OnCloseWindow { get; set; }
        //public ICommand OnAddDzialka { get; set; }
        #endregion

        public string tytulNr { get; set; }
        public string tytulObr { get; set; }
        public string tytulGm { get; set; }

        public PerformMode mode { get; set; }

        public ModViewModel(UserControl_DanePodstawoweViewModel userPodst,
                            UserControl_DaneDodatkoweViewModel userDod,
                            UserControl_PreviewViewModel userPrev1,
                            IDzialka dzialkaSel)
        {
            tabsVisible = true;
           
            dzialkaSel.copy(userPrev1.dzialkaSel);

            userPodst.dzialka.copy( dzialkaSel);
            userPodst.obreb.fillValues(dzialkaSel);

            userDod.dzialka = dzialkaSel;

            userControl_AddDanePod = userPodst;
            userControl_AddDanePod.changeMode = ChangeMode.mod;

            userControl_DaneDod = userDod;

            //tabsVisible = true;

            ////userPodst.dzialka.copy(userPrev1.dzialkaSel);
            //userPodst.dzialka=userPrev1.dzialkaSel;
            //userPodst.obreb.fillValues(userPrev1.dzialkaSel);

            //userDod.dzialka = userPrev1.dzialkaSel;

            //userControl_AddDanePod = userPodst;
            //userControl_AddDanePod.changeMode = ChangeMode.mod;

            //userControl_DaneDod = userDod;
        }

        public override void onAddDzialka()
        {
            MessageBox.Show("Mod");
            //userControl_prevModel.dzialkiBase.ModRow( userControl_AddDanePod.dzialka);
            //userControl_prevModel.dzialkaView.Refresh();
        }

        public override void onCloseWindow()
        {
            mode.appMod = PerformMode.appMode.main;
        }
    }
}

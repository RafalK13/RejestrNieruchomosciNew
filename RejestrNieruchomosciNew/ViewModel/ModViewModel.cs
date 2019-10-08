using RejestrNieruchomosciNew.Model;
using System.Windows;

namespace RejestrNieruchomosciNew.ViewModel 
{
    public class ModViewModel : ChangeViewModel, IChangeViewModel
    {
        //public  UserControl_DanePodstawoweViewModel userControl_AddDanePod { get; set; }

        public ModViewModel(UserControl_DanePodstawoweViewModel userPodst,
                            UserControl_PreviewViewModel userPrev)
        {
                
            userPodst.dzialka = (Dzialka)userPrev.dzialkaSel;
            userPodst.obreb.fillValues(userPrev.dzialkaSel);

            //userControl_AddDanePod.dzialka = userPrev.dzialkaSel;
            //userControl_AddDanePod.obreb.fillValues(userPrev.dzialkaSel);

            //userControl_AddDanePod = userPodst;


        }

        public override void onAddDzialka()
        {
            //MessageBox.Show(userControl_AddDanePod.dzialka.Numer);
        }

        public override void onCloseWindow()
        {

        }
    }
}

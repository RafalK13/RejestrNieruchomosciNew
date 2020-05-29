using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class UserControl_InfoDanePodstViewModel : ViewModelBase
    {
        public INadzorKonserwatoraSloList nadzorList { get; set; }

        public IAdresSloList adresSloList { get; set; }

        public UserControl_InfoDanePodstViewModel()
        {
        }
    }
}

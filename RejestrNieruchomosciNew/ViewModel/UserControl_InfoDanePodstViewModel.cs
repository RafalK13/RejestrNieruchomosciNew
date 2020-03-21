using GalaSoft.MvvmLight;
using RejestrNieruchomosciNew.Model;
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
        public UserControl_PreviewViewModel prev { get; set; }

        public UliceSloList uliceSloList { get; set; }

        public UserControl_InfoDanePodstViewModel()
        {
        
        }
    }
}

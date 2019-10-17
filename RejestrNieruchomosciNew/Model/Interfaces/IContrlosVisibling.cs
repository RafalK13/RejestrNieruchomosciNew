using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IContrlosVisibling
    {
        bool canAdd { get; set; }
        bool canMod { get; set; }
    }

    public class ContrlosVisibling : IContrlosVisibling
    {
        public bool canAdd { get; set; }
        public bool canMod { get; set; }
    }
}

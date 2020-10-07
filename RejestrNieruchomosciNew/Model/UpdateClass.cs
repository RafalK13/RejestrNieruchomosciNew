using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class UpdateClass
    {
        public IDzialkaList dzialkaList { get; set; }

        public void updateAll()
        {
            dzialkaList.UpdateList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IDzialkaList
    {
        List<IDzialka> dzialkaList { get; set; }
        void AddRow(IDzialka dz);
        void deleteRow(IDzialka dz);
        void ModRow(IDzialka dzialka);
    }
}

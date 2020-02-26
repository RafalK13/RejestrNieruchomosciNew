using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IDzialkaList
    {
        List<IDzialka> list { get; set; }
        void AddRow(IDzialka dz);
        void DelRow(IDzialka dz);
        void ModRow(IDzialka dzialka);

    }
}

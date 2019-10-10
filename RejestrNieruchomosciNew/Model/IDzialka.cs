using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface IDzialka
    {
        int DzialkaId { get; set; }
        string Numer { get; set; }
        string Kwakt { get; set; }
        string Kwzrob { get; set; }
        decimal? Pow { get; set; }
        int ObrebId { get; set; }
        Obreb Obreb { get; set; }

        void clone( IDzialka d);
        void copy( IDzialka dzDest, IDzialka dzSource);

        IDzialka copy(IDzialka dzSource);

        ProcessDzialka procDz { get; set; }
    }
}

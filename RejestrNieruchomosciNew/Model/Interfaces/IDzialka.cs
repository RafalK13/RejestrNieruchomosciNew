using GalaSoft.MvvmLight;
using System;

namespace RejestrNieruchomosciNew.Model
{
    public interface IDzialka : IEquatable<IDzialka>
    {
        int DzialkaId { get; set; }
        string Numer { get; set; }
        string Kwakt { get; set; }
        string Kwzrob { get; set; }
        double? Pow { get; set; }
        //int? UliceSloId { get; set; }

        string lokalizacja { get; set; }
        string uzbrojenie { get; set; }
        string ksztalt { get; set; }
        string sasiedztwo { get; set; }
        string dostDoDrogi { get; set; }
        string rodzNaw { get; set; }
        
        int? NadzorKonserwSloId { get; set; }
        
        int ObrebId { get; set; }
        Obreb Obreb { get; set; }

        string ulica  { get; set; }

        PlatnoscUW PlatnoscUW { get; set; }

        void clone( IDzialka d);
        object clone();

        void copy( IDzialka dzDest, IDzialka dzSource);

        IDzialka copy(IDzialka dzSource);

        //ProcessDzialka procDz { get; set; }

        event EventHandler zmiana;
    }
}

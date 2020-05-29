using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class StaticFunctions
    {
        public static T Clone1<T>(T obj) where T : class
        {
            //var knownTypes = new List<Type> { typeof(Dzialka), typeof(Uzytki), typeof(Wladanie), typeof(InnePrawa), typeof(Zagosp), typeof(Dzialka_Budynek)};
            var knownTypes = new List<Type> { typeof(Dzialka), typeof(Adres), typeof(MiejscowoscSloList), typeof(MiejscowoscSlo), typeof(UlicaSloList), typeof(UlicaSlo) };
            var serializer = new DataContractSerializer(typeof(T), knownTypes);//, int.MaxValue, false, true, null);
            using (var ms = new System.IO.MemoryStream())
            {

                serializer.WriteObject(ms, obj);
                ms.Position = 0;
                var v = (T)serializer.ReadObject(ms);
                return v;
            }
        }
    }
}

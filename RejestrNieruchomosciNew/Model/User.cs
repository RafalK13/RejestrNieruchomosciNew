using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public class User : IUser
    {
        public int UserId { get; set; }
        public string name { get; set; }
        public bool admin { get; set; }
    }
}

using NUnit.Framework;
using RejestrNieruchomosciNew.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Tests
{
    public class FiltrTests
    {
        [Test]
        public void czysc()
        {
            var c = new Filtr();

            c.czysc();

            Assert.That(c.powP, Is.Null);
            Assert.That(c.powK, Is.Null);
           
        }
    }
}

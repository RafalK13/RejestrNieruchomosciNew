using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Class1Raf
    {
        public ObservableCollection<Person> list{ get; set; }

        public Class1Raf()
        {
            MessageBox.Show("Class1Raf");

            list = new ObservableCollection<Person>() {
                new Person(){ id = 1, name="Rafałek"},
                new Person(){ id = 1, name="Hanula"}
            };
        }
    }
}

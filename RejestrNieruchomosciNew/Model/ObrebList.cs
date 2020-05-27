using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RejestrNieruchomosciNew.Model
{
    public class ObrebList : IObrebList
    {
        public List<Obreb> obrebList { get; set; }

        public ObrebList()
        {
            using (var c = new Context())
            {
                try
                {
                    obrebList = c.Obreb.Include("GminaSlo").ToList();                 
                }
                catch (Exception e)
                {
                    MessageBox.Show($"ObrebList\r\n{e.Message}");
                    Environment.Exit(0);
                }
           
            }
        }
    }
}

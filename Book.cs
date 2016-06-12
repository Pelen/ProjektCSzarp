using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooks
{ 
    [Serializable]
    class Book : Item
    {
        public String Author { get; set; }

        public override void ShowMe()
        {
            base.ShowMe();
            Console.WriteLine("Autor: " + Author);
        }
    }
}

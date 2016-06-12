using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooks
{
    [Serializable]
    abstract class Item
    {   
        public String Title { get; set; }
        public int Year { get; set; }
        public String Desc { get; set; }

        public virtual void ShowMe()
            {

            Console.WriteLine("Tytuł: " + Title);
            Console.WriteLine("Rok: " + Year);
            Console.WriteLine("Opis: " + Desc);

        }


    }

}

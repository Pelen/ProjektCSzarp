using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooks
{
    [Serializable]
    class Program
    {
        static void Main(string[] args)
        {
            var BookList = new List<Book>();
            while (true)
            {

                int caseSwitch = Utils.Menu();
                switch (caseSwitch)
                {
                    case 1:
                        Utils.AddBook(ref BookList);
                        break;
                    case 2:
                        Utils.ShowBook(BookList);
                        Console.ReadKey();
                        break;
                    case 3:
                        Utils.Serialize(ref BookList);
                        break;
                    case 4:
                        Utils.DeSerialize(ref BookList);
                        break;

                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MovieBooks
{
    class Utils
    {
        public static void ShowBook(List<Book> BookList)
        {
            int choice = 0;
            int id = 1;

            while (true)
            {
                id = 0;
                foreach (Book book in BookList)
                {
                    id++;
                    Console.WriteLine(id + ". " + book.Title);

                }
                if (id == 0)
                {
                    Console.WriteLine("Brak Książek");
                    return;
                }
                Console.WriteLine("Wybierz Książkę: ");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Tylko wartości liczbowe");
                }
            }

            while (true)
            {
                if (id == 0)
                {
                    return;
                }
                if (choice > 0 && choice < id +1)
                {
                    BookList[choice - 1].ShowMe();
                    break;
                }
                else
                {
                    Console.WriteLine("Podaj numer z przedziału 1 do {0}", id);
                    break;
                }
            }
        }

        public static void AddBook(ref List<Book> BookList)
        {
            Book book = new Book();
            Console.WriteLine("Podaj Tytuł");
            book.Title = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("Podaj Rok");
                    book.Year = Int32.Parse(Console.ReadLine());

                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Tylko wartości liczbowe");

                }
                if (book.Year > 1000 && book.Year <= DateTime.Today.Year)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Podaj datę z przedziału 1001 do {0}", DateTime.Today.Year);
                }

            }

            Console.WriteLine("Podaj Autora");
            book.Author = Console.ReadLine();

            Console.WriteLine("Podaj Opis");
            book.Desc = Console.ReadLine();

            BookList.Add(book);

            Console.WriteLine("Dodano. Naciśnij dowolny klawisz aby kontynuować...");
            Console.ReadKey();
        }

        public static int Menu()
        {
            int choice = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Dodaj książkę");
                Console.WriteLine("2. Wyświetl książki");
                Console.WriteLine("3. Zapisz");
                Console.WriteLine("4. Wczytaj");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                    if (choice >= 1 && choice <= 4)
                    {
                        return choice;
                    }

                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Tylko wartości liczbowe. Naciśnij dowolny klawisz aby kontynuować...");
                    Console.ReadKey();
                }
            }
        }
        public static void Serialize(ref List<Book> BookList)
        {
            FileStream fs = new FileStream("Data.dat", FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, BookList);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Błąd serializacji danych: " + e.Message);

            }
            finally
            {
                fs.Close();
            }
        }

        public static void DeSerialize(ref List<Book> BookList)
        {
            FileStream fs = new FileStream("Data.dat", FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                BookList = formatter.Deserialize(fs) as List<Book>;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Błąd deserializacji danych: " + e.Message);

            }
            finally
            {
                fs.Close();
            }
        }
    }
}

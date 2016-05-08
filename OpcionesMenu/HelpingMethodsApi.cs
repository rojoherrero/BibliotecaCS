using EntitiesApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMenuApi
{
    internal class HelpingMethods
    {
        public static void OneMoreBookCopy(Dictionary<string, Book> DictionaryName, string isbn)
        {
            // Si el ISBN existe:
            Console.WriteLine(RepeatedIsbnWarning(isbn));
            // Aumento el número de ejempalares en una unidad
            DictionaryName[isbn].Copies++;
            // Informo del total de ejemplares
            Console.WriteLine(OneMoreCopyWarning(DictionaryName, isbn));
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadLine();
        }

        public static string SetIsbn()
        {
            Console.WriteLine("Introduce el ISBN del libro: ");
            string isbn = Console.ReadLine();
            return isbn;
        }

        public static string SetTitle()
        {
            Console.WriteLine("Introduce el titulo del libro: ");
            string title = Console.ReadLine();
            return title;
        }

        public static string SetAuthor()
        {
            Console.WriteLine("Introduce el autor del libro: ");
            string author = Console.ReadLine();
            return author;
        }

        public static int SetPublishYear()
        {
            int returnYear;
            bool validYear = false;

            do
            {
                Console.WriteLine("Introduce el año de publicación del libro: ");
                validYear = !int.TryParse(Console.ReadLine(), out returnYear);
            } while (validYear);
            return returnYear;
        }

        public static int SetPublishMOnth()
        {
            int returnMonth;
            bool validMonth = false;
            do
            {
                Console.WriteLine("Introduce el mes (número) de publicación del libro: ");
                validMonth = !int.TryParse(Console.ReadLine(), out returnMonth)
                    && !Enumerable.Range(1,13).Contains(returnMonth);
            } while (validMonth);        
            return returnMonth;
        }

        public static int SetPublishDay()
        {
            int returnDay;
            bool validDay = false;
            do
            {
                Console.WriteLine("Introduce el día de publicación del libro: ");
                validDay = !int.TryParse(Console.ReadLine(), out returnDay);
            } while (validDay);
            return returnDay;
        }

        private static string RepeatedIsbnWarning(string isbn)
        {
            StringBuilder message = new StringBuilder();
            message.Append("El ISBN \"");
            message.Append(isbn);
            message.Append("\" ya existe.\npor lo que se ha aumentado en una unidad el número de ejemplares");

            return message.ToString();
        }

        private static string OneMoreCopyWarning(Dictionary<string, Book> nombreDiccionario, string isbn)
        {
            StringBuilder message = new StringBuilder();
            message.Append("El número total de ejemplares es: ");
            message.Append(nombreDiccionario[isbn].Copies);

            return message.ToString();
        }
    }
}

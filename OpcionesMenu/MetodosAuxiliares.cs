using LibreriaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMenuLibros
{
    internal class MetodosAuxiliares
    {
        public static void AumentarNumEjemplares(Dictionary<string, Libro> nombreDiccionario, string isbn)
        {
            // Si el ISBN existe:
            Console.WriteLine(AvisoIsbnRepetido(isbn));
            // Aumento el número de ejempalares en una unidad
            nombreDiccionario[isbn].Ejemplares++;
            // Informo del total de ejemplares
            Console.WriteLine(AvisoAumentoEjemplares(nombreDiccionario, isbn));
            Console.WriteLine("Pulsa cualquier tecla para continuar");
            Console.ReadLine();
        }

        public static string RecogerIsbn()
        {
            Console.WriteLine("Introduce el ISBN del libro: ");
            string isbn = Console.ReadLine();
            return isbn;
        }

        public static string RecogerTitulo()
        {
            Console.WriteLine("Introduce el titulo del libro: ");
            string titulo = Console.ReadLine();
            return titulo;
        }

        public static string RecogerAutor()
        {
            Console.WriteLine("Introduce el autor del libro: ");
            string autor = Console.ReadLine();
            return autor;
        }

        public static int RecogerAnoPublicacion()
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

        public static int RecogerMesPublicacion()
        {
            int returnMonth;
            bool validMonth = false;
            do
            {
                Console.WriteLine("Introduce el mes (número) de publicación del libro: ");
                validMonth = !int.TryParse(Console.ReadLine(), out returnMonth);
            } while (validMonth);        
            return returnMonth;
        }

        public static int RecogerDiaPublicacion()
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

        private static string AvisoIsbnRepetido(string isbn)
        {
            StringBuilder informacion = new StringBuilder();
            informacion.Append("El ISBN \"");
            informacion.Append(isbn);
            informacion.Append("\" ya existe.\npor lo que se ha aumentado en una unidad el número de ejemplares");

            return informacion.ToString();
        }

        private static string AvisoAumentoEjemplares(Dictionary<string, Libro> nombreDiccionario, string isbn)
        {
            StringBuilder informacion = new StringBuilder();
            informacion.Append("El número total de ejemplares es: ");
            informacion.Append(nombreDiccionario[isbn].Ejemplares);

            return informacion.ToString();
        }
    }
}

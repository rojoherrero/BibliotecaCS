using LibreriaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMenuLibros
{
    class MetodosAuxiliares
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

        public static void AgregarLibro()
        {

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

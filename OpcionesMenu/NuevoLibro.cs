using LibreriaEntidades;
using ListarElementos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpcionesMenu
{
    public class OperacionesLibro
    {
        ListarLibros listarLibros = new ListarLibros();

        public static void NuevoLibro(Dictionary<string,Libro> nombreDiccionario)
        {
            // Inicio la recogida de los datos para crear el nuevo libro
            Console.WriteLine("Introduce el ISBN del libro: ");
            string isbn = Console.ReadLine();

            // Compruebo que no este el ISBN guardado
            if (nombreDiccionario.ContainsKey(isbn))
            {
                // Si el ISBN existe:
                Console.WriteLine("El ISBN \"" + isbn + "\" ya existe.\npor lo que se ha aumentado en una unidad el número de ejemplares");
                // Aumento el número de ejempalares en una unidad
                nombreDiccionario[isbn].Ejemplares++;
                // Informo del total de ejemplares
                Console.WriteLine("El número total de ejemplares es: " + nombreDiccionario[isbn].Ejemplares);
                Console.WriteLine("Pulsa cualquier tecla para continuar");
                Console.ReadLine();
                Console.Clear();
  
            }
            else
            {
                // Como no existe el isbn en memoria, instancio un nuevo libro
                Libro libro = new Libro();

                // TODO intentar refactorizar menu principal

                // Recogo los datos del libro y lo guardo en un libro nuevo
                libro.ISBN = isbn;
                Console.WriteLine("Introduce el titulo del libro: ");
                libro.Titulo = Console.ReadLine();
                Console.WriteLine("Introduce el autor del libro: ");
                libro.Autor = Console.ReadLine();
                Console.WriteLine("Introduce la fecha de publicación del libro.\nEl formato de la fecha tiene que ser el siguiente DD/MM/AAAA");
                libro.FechaPublicacion = DateTime.Parse(Console.ReadLine());
                libro.FechaAlta = DateTime.Today;
                libro.Ejemplares = 1;

                // añado el libro al diccionario
                nombreDiccionario.Add(isbn, libro);
            }
        }

        public static void ListarLibros(Dictionary<string, Libro> nombreDiccionario)
        {
            // Listar todos los libros
            // TODO refactorizar listar todos los libros
            Console.Clear();
            Console.WriteLine("Has elegido listar todos los libros");

            listarLibros.todosLosLibros(nombreDiccionario);

            Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
            Console.ReadLine();
            Console.Clear();
        }
    }
}

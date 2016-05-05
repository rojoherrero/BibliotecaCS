using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaEntidades;
using ListarElementos;

namespace GestionBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            // Esta variable es la que controla si se quiere salir de la aplicación
            bool seguir = true;

            // Diccionario en el que se guardan los libros 
            Dictionary<string, Libro> diccionarioLibros = new Dictionary<string, Libro>();

            // Lo instancio aquí para poder acceder a listarLibros en cualquier momento
            ListarLibros listarLibros = new ListarLibros();

            // Sólo aparece al inicio de la aplicación
            Console.WriteLine("Maara tulda");
            Console.WriteLine("Gestión de la biblioteca de Rivendel");
            
            while (seguir)
            {
                // Menú con las opciones disponibles
                Console.WriteLine("Menú de la aplicación");
                Console.WriteLine("1) Añadir Libro");
                Console.WriteLine("2) Listar Libros");
                Console.WriteLine("3) Eliminar Libro");
                Console.WriteLine("4) Modificar Libro");
                Console.WriteLine("5) Salir");

                Console.Write("Introduzca el número de la opción que desea realizar: ");
                string opcion = Console.ReadLine();


                switch (opcion)
                {
                    // Añadir Libro
                    //TODO refactorizar menu principal
                    case "1":
                        // Limpio la consola para no guarrearla mucho
                        Console.Clear();

                        // Inicio la recogida de los datos para crear el nuevo libro
                        Console.WriteLine("Introduce el ISBN del libro: ");
                        string isbn = Console.ReadLine();

                        // Compruebo que no este el ISBN guardado
                        if (diccionarioLibros.ContainsKey(isbn))
                        {
                            // Si el ISBN existe:
                            Console.WriteLine("El ISBN \"" + isbn + "\" ya existe.\npor lo que se ha aumentado en una unidad el número de ejemplares");
                            // Aumento el número de ejempalares en una unidad
                            diccionarioLibros[isbn].Ejemplares++;
                            // Informo del total de ejemplares
                            Console.WriteLine("El número total de ejemplares es: " + diccionarioLibros[isbn].Ejemplares);
                            Console.WriteLine("Pulsa cualquier tecla para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

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
                        diccionarioLibros.Add(isbn, libro);

                        // aumento el contador en una unidad
                        Console.Clear();
                        break;

                    case "2":
                        // Listar todos los libros
                        // TODO refactorizar listar todos los libros
                        Console.Clear();
                        Console.WriteLine("Has elegido listar todos los libros");
                        
                        listarLibros.todosLosLibros(diccionarioLibros);

                        Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "3":
                        // Eliminar un libro(
                        // TODO dar opción a eliminar más de un libro a la vez
                        // TODO una vez funciones todo, refactorizar la funcionalidad de eliminar
                        Console.Clear();
                        Console.WriteLine("Has elegido eliminar un libro");

                        listarLibros.todosLosLibros(diccionarioLibros);

                        string isbnEliminar;

                        // TODO refactorizar la selección del libro por ISBN
                        do
                        {
                            Console.WriteLine("Introduce el ISBN del libro que quieras eliminar");
                            isbnEliminar = Console.ReadLine();
                        } while (!diccionarioLibros.ContainsKey(isbnEliminar));

                        Console.WriteLine("Estás seguro? (S/N)");
                        string continuar = Console.ReadLine();

                        if (continuar.Equals("S") || continuar.Equals("s"))
                        {
                            diccionarioLibros.Remove(isbnEliminar);
                        }

                        listarLibros.todosLosLibros(diccionarioLibros);

                        Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "4":
                                                                       
                        bool seguirModificando = true;

                        while (seguirModificando)
                        {
                            // Modificar un libro
                            // TODO una vez funcione todo, refactorizar la funcionalidad de modificar

                            ListarLibros infoLibro = new ListarLibros();

                            Console.WriteLine("Has elegido modificar un libro");

                            listarLibros.todosLosLibros(diccionarioLibros);

                            string isbnModificar;

                            // TODO refactorizar la selección del libro por ISBN
                            do
                            {
                                Console.WriteLine("Introduce el ISBN del libro que quieras modificar");
                                isbnModificar = Console.ReadLine();
                            } while (!diccionarioLibros.ContainsKey(isbnModificar));

                            infoLibro.infoLibro(diccionarioLibros, isbnModificar);
                            
                            Console.WriteLine("¿Qué quiere modificar?");
                            string menuModificar = Console.ReadLine();

                            switch (menuModificar)
                            {
                                case "Fecha de publicacion":
                                    Console.Write("Introduce una nueva fecha de publicación (DD/MM/AAAA)");
                                    diccionarioLibros[isbnModificar].FechaPublicacion = DateTime.Parse(Console.ReadLine());
                                    break;
                                case "Fecha de alta":
                                    Console.Write("Introduce una nueva fecha de alta (DD/MM/AAAA)");
                                    diccionarioLibros[isbnModificar].FechaAlta = DateTime.Parse(Console.ReadLine());
                                    break;
                                case "Ejemplares":
                                    Console.Write("Introduce una la cantidad de ejemplares que quieras");
                                    diccionarioLibros[isbnModificar].Ejemplares = int.Parse(Console.ReadLine());
                                    break;
                                case "Autor":
                                    Console.Write("Introduce el nuevo autor");
                                    diccionarioLibros[isbnModificar].Autor = Console.ReadLine();
                                    break;
                                case "Titulo":
                                    Console.Write("Introduce el nuevo título");
                                    diccionarioLibros[isbnModificar].Titulo = Console.ReadLine();
                                    break;
                                default:
                                    Console.WriteLine("Elige una opción válida");
                                    menuModificar = Console.ReadLine();
                                    break;
                            }

                            Console.WriteLine("Quieres seguir?(S/N)");
                            string respuesta = Console.ReadLine();
                            if (respuesta.Equals("N") || respuesta.Equals("n"))
                            {
                                seguirModificando = false;
                            }
                        }

                        break;
                    case "5":
                        // Salir
                        seguir = false;
                        Console.WriteLine("Muchas gracias por haber confiado en nuestra aplicación");
                        Console.WriteLine("Namarië\nPresiona cualquiere tecla para salir");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Por favor, introduce una opción válida");
                        Console.WriteLine("Presiona cualquier tecla para continuar");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
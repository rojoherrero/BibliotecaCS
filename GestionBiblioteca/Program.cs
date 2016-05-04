using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadLibro;
using ListarElementos;

namespace GestionBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            // Esta variable es la que controla si se quiere salir de la aplicación
            bool seguir = true;
            // Esta variable controla el número de libros que se han introducido 
            int contadorLibros = 0;
            // Diccionario en el que se guardan los libros 
            Dictionary<string, Libro> diccionarioLibros = new Dictionary<string, Libro>();

            ListarLibros lb = new ListarLibros();

            // Creo aquí la cabecera para poder usarla allí donde haga falta
            StringBuilder cabecera = new StringBuilder();
            cabecera.Append("Autor");
            cabecera.Append("\t\t\t\t");
            cabecera.Append("Título");
            cabecera.Append("\t\t\t\t");
            cabecera.Append("ISBN");
            Console.WriteLine(cabecera);

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

                // Número de libros que hay guardados
                if (contadorLibros == 0)
                {
                    Console.WriteLine("No hay ningún libro. Introduce alguno");
                }
                else if (contadorLibros == 1)
                {
                    Console.WriteLine("Hay un libro");
                }
                else
                {
                    Console.WriteLine("No hay " + contadorLibros + " libros.");
                }

                Console.Write("Introduzca el número de la opción que desea realizar: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    // Añadir Libro
                    case "1":
                        // Limpio la consola para no guarrearla mucho
                        Console.Clear();
                        Console.WriteLine("Introduce el ISBN del libro: ");
                        string isbn = Console.ReadLine();

                        // Compruebo que no este el ISBN guardado
                        if (diccionarioLibros.ContainsKey(isbn))
                        {
                            //TODO Implementar número de ejemplares
                            Console.WriteLine("El ISBN \"" + isbn + "\" ya existe.\ny no puede haber dos iguales");
                            Console.WriteLine("Pulsa cualquier tecla para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            // TODO intentar refactorizar
                            // TODO implementar fecha de alta
                            // TODO implementar fecha de publicación
                            // Recogo los datos del libro y lo guardo en un libro nuevo
                            Libro libro = new Libro();
                            libro.ISBN = isbn;
                            Console.WriteLine("Introduce el titulo del libro: ");
                            libro.Titulo = Console.ReadLine();
                            Console.WriteLine("Introduce el autor del libro: ");
                            libro.Autor = Console.ReadLine();
                            libro.FechaAlta = DateTime.Today;

                            // añado el libro al diccionario
                            diccionarioLibros.Add(isbn, libro);

                            // aumento el contador en una unidad
                            contadorLibros++;
                            Console.Clear();
                        }

                        break;
                    case "2":

                        // Listar todos los libros
                        Console.Clear();
                        Console.WriteLine("Has elegido listar todos los libros");
                        
                        Console.WriteLine(cabecera);

                        lb.todosLosLibros(diccionarioLibros);

                        Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":

                        // Eliminar un libro
                        // TODO dar opción a eliminar más de un libro a la vez
                        Console.Clear();
                        Console.WriteLine("Has elegido listar todos los libros");
                        
                        Console.WriteLine(cabecera);

                        // TODO refactorizar el listado de todos los libros
                        foreach (Libro item in diccionarioLibros.Values)
                        {
                            StringBuilder libroPorPantalla = new StringBuilder();
                            libroPorPantalla.Append(item.Autor);
                            libroPorPantalla.Append("\t\t\t\t");
                            libroPorPantalla.Append(item.Titulo);
                            libroPorPantalla.Append("\t\t\t\t");
                            libroPorPantalla.Append(item.ISBN);
                            Console.WriteLine(libroPorPantalla);
                        }

                        Console.WriteLine("Introduce el ISBN del libro que quieras eliminar");
                        // TODO comprobar ISBN
                        // TODO hacer más fácil eliminar un libro
                        string isbnEliminar = Console.ReadLine();
                        diccionarioLibros.Remove(isbnEliminar);

                        Console.WriteLine(cabecera);

                        // TODO refactorizar el listado de todos los libros
                        foreach (Libro item in diccionarioLibros.Values)
                        {
                            StringBuilder libroPorPantalla = new StringBuilder();
                            libroPorPantalla.Append(item.Autor);
                            libroPorPantalla.Append("\t\t\t\t");
                            libroPorPantalla.Append(item.Titulo);
                            libroPorPantalla.Append("\t\t\t\t");
                            libroPorPantalla.Append(item.ISBN);
                            Console.WriteLine(libroPorPantalla);
                        }

                        Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "4":
                        // Modificar un libro

                        // TODO implementar la opción de modificar un libro
                        break;
                    case "5":

                        // Salir
                        seguir = false;
                        Console.WriteLine("Muchas gracias por haber confiado en nuestra aplicación");
                        Console.WriteLine("Namarië\nPresiona cualquiere tecla para salir");
                        Console.ReadLine();
                        break;
                    default:
                        break;


                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadLibro;

namespace GestionBiblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            bool seguir = true;
            int contadorLibros = 0;
            Dictionary<string, Libro> listaLibros = new Dictionary<string, Libro>();

            Console.WriteLine("Maara tulda");
            Console.WriteLine("Gestión de la biblioteca de Rivendel");

            while (seguir)
            {
                Console.WriteLine("Menú de la aplicación");
                Console.WriteLine("1) Añadir Libro");
                Console.WriteLine("2) Listar Libros");
                Console.WriteLine("3) Eliminar Libro");
                Console.WriteLine("4) Modificar Libro");
                Console.WriteLine("5) Salir");
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
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Introduce el ISBN del libro: ");
                        string isbn = Console.ReadLine();

                        if (listaLibros.ContainsKey(isbn))
                        {
                            Console.WriteLine("El ISBN \"" + isbn + "\" ya existe.\ny no puede haber dos iguales");
                            Console.WriteLine("Pulsa cualquier tecla para continuar");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Libro libro = new Libro();
                            libro.ISBN = isbn;
                            Console.WriteLine("Introduce el titulo del libro: ");
                            libro.Titulo = Console.ReadLine();
                            Console.WriteLine("Introduce el autor del libro: ");
                            libro.Autor = Console.ReadLine();
                            libro.FechaAlta = DateTime.Today;

                            listaLibros.Add(isbn, libro);
                            contadorLibros++;
                            Console.Clear();
                            break;
                        }

                        break;
                    case "2":
                        Console.WriteLine("Has elegido listar todos los libros");
                        Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
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

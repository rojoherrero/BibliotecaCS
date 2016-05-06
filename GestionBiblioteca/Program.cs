using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaEntidades;
using ListarElementos;
using OpcionesMenu;

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
            OperacionesSobreLibros listarLibros = new OperacionesSobreLibros();

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

                    case "1":
                        // Limpio la consola para no guarrearla mucho
                        Console.Clear();

                        OperacionesLibro.NuevoLibro(diccionarioLibros);

                        Console.Clear();

                        break;

                    case "2":
                        // Listar todos los libros

                        Console.Clear();

                        OperacionesLibro.ListarLibros(diccionarioLibros);

                        Console.Clear();
                        break;

                    case "3":
                        // Eliminar un libro(

                        Console.Clear();

                        OperacionesLibro.EliminarLibro(diccionarioLibros);

                        Console.Clear();
                        break;

                    case "4":

                        // Modificar Libro

                        Console.Clear();

                        OperacionesLibro.ModificarLibro(diccionarioLibros);

                        Console.Clear();
                                                                       
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
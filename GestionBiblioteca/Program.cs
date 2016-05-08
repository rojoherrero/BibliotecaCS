using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLibrary;
using ListarElementos;
using HelpingMethodsLibrary;

namespace LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Esta variable es la que controla si se quiere salir de la aplicación
            bool seguir = true;

            // Instancio un MenuLibros para poder acceder a el desde cualquier sitio
            MenuLibros menuLibros = new MenuLibros();

            // Diccionario en el que se guardan los libros 
            Dictionary<string, Book> diccionarioLibros = new Dictionary<string, Book>();

            // Sólo aparece al inicio de la aplicación
            HelpingMethodsApi.WelcomeMessage();
            
            while (seguir)
            {
                // Menú con las opciones disponibles
                HelpingMethodsApi.RenderAllAvailableOptions();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    // Añadir Libro

                    case "1":
                        // Limpio la consola para no guarrearla mucho
                        Console.Clear();

                        menuLibros.NuevoLibro(diccionarioLibros);

                        Console.Clear();

                        break;

                    case "2":
                        // Listar todos los libros

                        Console.Clear();

                        menuLibros.ListarLibros(diccionarioLibros);

                        Console.Clear();
                        break;

                    case "3":
                        // Eliminar un libro(

                        Console.Clear();

                        menuLibros.EliminarLibro(diccionarioLibros);

                        Console.Clear();
                        break;

                    case "4":

                        // Modificar Libro

                        Console.Clear();

                        menuLibros.ModificarLibro(diccionarioLibros);

                        Console.Clear();
                                                                       
                        break;

                    case "5":
                        // Salir
                        seguir = false;

                        HelpingMethodsApi.PartingMessge();

                        Console.ReadLine();
                        break;
                    default:

                        HelpingMethodsApi.NonValidOptionMessage();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaEntidades;
using ListarElementos;
using LibreriaMenuLibros;

namespace GestionBiblioteca
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
            Dictionary<string, Libro> diccionarioLibros = new Dictionary<string, Libro>();

            // Sólo aparece al inicio de la aplicación
            MetodosAuxiliares.MensajeBienvenida();
            
            while (seguir)
            {
                // Menú con las opciones disponibles
                MetodosAuxiliares.PintarTodasLasOpciones();
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

                        MetodosAuxiliares.MensajeDespedida();

                        Console.ReadLine();
                        break;
                    default:

                        MetodosAuxiliares.MensajeOpcionNoValida();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
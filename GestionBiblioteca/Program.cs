﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesApi;
using ListarElementos;
using BookMenuApi;

namespace LibraryManagement
{
    class Program
    {

        enum OptionMenu
        {
            addBook,
            listBooks,
            modifyBook,
            exit
        }


        static void Main(string[] args)
        {
            // Esta variable es la que controla si se quiere salir de la aplicación
            bool follow = true;

            // Instancio un MenuLibros para poder acceder a el desde cualquier sitio
            BookMenu bookmenu = new BookMenu();

            // Diccionario en el que se guardan los libros 
            Dictionary<string, Book> bookDictionary = new Dictionary<string, Book>();

            // Sólo aparece al inicio de la aplicación
            HelpingMethodsApi.WelcomeMessage();

            while (follow)
            {
                // Menú con las opciones disponibles
                HelpingMethodsApi.RenderAllAvailableOptions();
                string option = Console.ReadLine();

                switch (option)
                {
                    
                    case "1": // Añadir Libro

                        Console.Clear();
                        bookmenu.AddNewBook(bookDictionary);
                        Console.Clear();
                        break;

                    case "2": // Listar todos los libros

                        Console.Clear();
                        bookmenu.ShowAllBooks(bookDictionary);
                        Console.Clear();
                        break;

                    case "3": // Eliminar un libro

                        Console.Clear();
                        bookmenu.DeleteBook(bookDictionary);
                        Console.Clear();
                        break;
                         
                    case "4": // Modificar Libro

                        Console.Clear();
                        bookmenu.ModifyBook(bookDictionary);
                        Console.Clear();
                        break;

                    case "5": // Salir

                        follow = false;
                        HelpingMethodsApi.PartingMessge();
                        Console.ReadLine();
                        break;

                    default: // Mensaje cuando no se ha introducido una opción valida

                        HelpingMethodsApi.NonValidOptionMessage();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
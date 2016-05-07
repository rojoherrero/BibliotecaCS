﻿using LibreriaEntidades;
using ListarElementos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpcionesMenuLibros
{
    public class OperacionesLibro
    {

        public static void NuevoLibro(Dictionary<string, Libro> nombreDiccionario)
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

                //TODO rehacer el agregar la fecha de publicación para que no se pueda meter tonterias

                bool fechaInvalida = true;

                while (fechaInvalida)
                {
                    Console.WriteLine("Introduce el año de publicación del libro: ");
                    string anoPublicacionString = Console.ReadLine();
                    Console.WriteLine("Introduce el mes (número) de publicación del libro: ");
                    string mesPublicacionString = Console.ReadLine();
                    Console.WriteLine("Introduce el día de publicación del libro: ");
                    string diaPublicacionString = Console.ReadLine();

                    int anoPublicacion;
                    int mesPublicacion;
                    int diaPublicacion;

                    if (int.TryParse(anoPublicacionString, out anoPublicacion) &&
                        int.TryParse(mesPublicacionString, out mesPublicacion) &&
                        int.TryParse(diaPublicacionString, out diaPublicacion))
                    {
                        if (Enumerable.Range(1500, DateTime.Now.Year).Contains(anoPublicacion) &&
                        Enumerable.Range(1, 12).Contains(mesPublicacion) &&
                        Enumerable.Range(1, 31).Contains(mesPublicacion))
                        {
                            libro.FechaPublicacion = new DateTime(anoPublicacion, mesPublicacion, diaPublicacion);
                            fechaInvalida = false;
                        }
                        else
                        {
                            Console.WriteLine("Has introducido fechas fuera de rango");
                            Console.WriteLine("Pulsa cualquier tecla para volver a empezar");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No has introducido número");
                        Console.WriteLine("Pulsa cualquier tecla para volver a empezar");
                        Console.ReadLine();
                    }
                }
                
                libro.FechaAlta = DateTime.Today;
                libro.Ejemplares = 1;

                // añado el libro al diccionario
                nombreDiccionario.Add(isbn, libro);
            }
        }

        public static void ListarLibros(Dictionary<string, Libro> nombreDiccionario)
        {
            //ListarLibros listarLibros = new ListarLibros();
            // Listar todos los libros
            // TODO refactorizar listar todos los libros
            Console.Clear();
            Console.WriteLine("Has elegido listar todos los libros");

            OperacionesSobreLibros.ListarTodosLosLibros(nombreDiccionario);

            Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
            Console.ReadLine();

        }

        public static void EliminarLibro(Dictionary<string, Libro> nombreDiccionario)
        {

            Console.WriteLine("Has elegido eliminar un libro");

            OperacionesSobreLibros.ListarTodosLosLibros(nombreDiccionario);

            string isbnEliminar;

            // TODO refactorizar la selección del libro por ISBN
            do
            {
                Console.WriteLine("Introduce el ISBN del libro que quieras eliminar");
                isbnEliminar = Console.ReadLine();
            } while (!nombreDiccionario.ContainsKey(isbnEliminar));

            Console.WriteLine("Estás seguro? (S/N)");
            string continuar = Console.ReadLine();

            if (continuar.Equals("S") || continuar.Equals("s"))
            {
                nombreDiccionario.Remove(isbnEliminar);
                OperacionesSobreLibros.ListarTodosLosLibros(nombreDiccionario);
            }
            else
            {
                Console.WriteLine("Operación abortada");
            }
            
            Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
            Console.ReadLine();

        }

        public static void ModificarLibro(Dictionary<string, Libro> nombreDiccionario)
        {

            bool seguirModificando = true;

            if (nombreDiccionario.Count() != 0)
            {
                OperacionesSobreLibros listarLibros = new OperacionesSobreLibros();

                while (seguirModificando)
                {
                    // Modificar un libro
                    // TODO una vez funcione todo, refactorizar la funcionalidad de modificar

                    Console.WriteLine("Has elegido modificar un libro");

                    OperacionesSobreLibros.ListarTodosLosLibros(nombreDiccionario);

                    string isbnModificar;

                    // TODO refactorizar la selección del libro por ISBN
                    do
                    {
                        Console.WriteLine("Introduce el ISBN del libro que quieras modificar");
                        isbnModificar = Console.ReadLine();
                    } while (!nombreDiccionario.ContainsKey(isbnModificar));

                    OperacionesSobreLibros.InfoLibro(nombreDiccionario, isbnModificar);

                    Console.WriteLine("¿Qué quiere modificar? Introduce el número de la opción que quieres realizar");
                    string menuModificar = Console.ReadLine();

                    switch (menuModificar)
                    {
                        case "Fecha de publicacion":
                            Console.Write("Introduce una nueva fecha de publicación (DD/MM/AAAA)");
                            nombreDiccionario[isbnModificar].FechaPublicacion = DateTime.Parse(Console.ReadLine());
                            break;
                        case "Fecha de alta":
                            Console.Write("Introduce una nueva fecha de alta (DD/MM/AAAA): ");
                            nombreDiccionario[isbnModificar].FechaAlta = DateTime.Parse(Console.ReadLine());
                            break;
                        case "Ejemplares":
                            Console.Write("Introduce una la cantidad de ejemplares que quieras: ");
                            nombreDiccionario[isbnModificar].Ejemplares = int.Parse(Console.ReadLine());
                            break;
                        case "Autor":
                            Console.Write("Introduce el nuevo autor: ");
                            nombreDiccionario[isbnModificar].Autor = Console.ReadLine();
                            break;
                        case "Titulo":
                            Console.Write("Introduce el nuevo título: ");
                            nombreDiccionario[isbnModificar].Titulo = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Elige una opción válida: ");
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

            }
            else
            {
                Console.WriteLine("No hay ningún libro, así que no puede modificar nada");
                Console.WriteLine("Pulsa cualquier tecla para continuar");
                Console.ReadLine();
                seguirModificando = false;
            }
        }
    }
}

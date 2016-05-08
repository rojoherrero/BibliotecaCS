using LibreriaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibreriaMenuLibros
{
    public class MenuLibros
    {
        
        public void NuevoLibro(Dictionary<string, Libro> nombreDiccionario)
        {
            string isbn;

            // Inicio la recogida de los datos para crear el nuevo libro

            isbn = MetodosAuxiliares.RecogerIsbn();


            // Compruebo que no este el ISBN guardado

            if (nombreDiccionario.ContainsKey(isbn))
            {
                // Si el ISBN ya existe
                MetodosAuxiliares.AumentarNumEjemplares(nombreDiccionario, isbn);
            }
            else
            {
                //El ISBN no existe

                Libro libro = new Libro();

                // TODO intentar refactorizar menu principal

                // Recogo los datos del libro y lo guardo en un libro nuevo
                libro.ISBN = isbn;
                libro.Titulo = MetodosAuxiliares.RecogerTitulo();
                libro.Autor = MetodosAuxiliares.RecogerAutor();

                int anoPublicacion = MetodosAuxiliares.RecogerAnoPublicacion();
                int mesPublicacion = MetodosAuxiliares.RecogerMesPublicacion();
                int diaPublicacion = MetodosAuxiliares.RecogerDiaPublicacion();

                libro.FechaPublicacion = new DateTime(anoPublicacion, mesPublicacion, diaPublicacion);

                libro.FechaAlta = DateTime.Today;
                libro.Ejemplares = 1;

                // añado el libro al diccionario
                nombreDiccionario.Add(isbn, libro);
            }
        }

        public void ListarLibros(Dictionary<string, Libro> nombreDiccionario)
        {
            //ListarLibros listarLibros = new ListarLibros();
            // Listar todos los libros
            // TODO refactorizar listar todos los libros
            Console.Clear();
            Console.WriteLine("Has elegido listar todos los libros");

            ListarElementos.ListarLibros.ListarTodosLosLibros(nombreDiccionario);

            Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
            Console.ReadLine();

        }

        public void EliminarLibro(Dictionary<string, Libro> nombreDiccionario)
        {

            Console.WriteLine("Has elegido eliminar un libro");

            ListarElementos.ListarLibros.ListarTodosLosLibros(nombreDiccionario);

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
                ListarElementos.ListarLibros.ListarTodosLosLibros(nombreDiccionario);
            }
            else
            {
                Console.WriteLine("Operación abortada");
            }
            
            Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
            Console.ReadLine();

        }

        public void ModificarLibro(Dictionary<string, Libro> nombreDiccionario)
        {

            bool seguirModificando = true;

            if (nombreDiccionario.Count() != 0)
            {
                ListarElementos.ListarLibros listarLibros = new ListarElementos.ListarLibros();

                while (seguirModificando)
                {
                    // Modificar un libro
                    // TODO una vez funcione todo, refactorizar la funcionalidad de modificar

                    Console.WriteLine("Has elegido modificar un libro");

                    ListarElementos.ListarLibros.ListarTodosLosLibros(nombreDiccionario);

                    string isbnModificar;

                    do
                    {
                        Console.WriteLine("Introduce el ISBN del libro que quieras modificar");
                        isbnModificar = Console.ReadLine();
                    } while (!nombreDiccionario.ContainsKey(isbnModificar));

                    ListarElementos.ListarLibros.InfoLibro(nombreDiccionario, isbnModificar);

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
                            nombreDiccionario[isbnModificar].Autor = MetodosAuxiliares.RecogerAutor();
                            break;
                        case "Titulo":
                            nombreDiccionario[isbnModificar].Titulo = MetodosAuxiliares.RecogerTitulo();
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

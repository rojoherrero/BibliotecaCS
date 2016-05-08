using EntitiesApi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookMenuApi
{
    public class BookMenu
    {
        
        public void NewBook(Dictionary<string, Book> DictionaryName)
        {
            string isbn;

            // Inicio la recogida de los datos para crear el nuevo libro

            isbn = HelpingMethods.SetIsbn();


            // Compruebo que no este el ISBN guardado

            if (DictionaryName.ContainsKey(isbn))
            {
                // Si el ISBN ya existe
                HelpingMethods.OneMoreBookCopy(DictionaryName, isbn);
            }
            else
            {
                //El ISBN no existe

                Book book = new Book();

                // TODO intentar refactorizar menu principal

                // Recogo los datos del libro y lo guardo en un libro nuevo
                book.ISBN = isbn;
                book.Title = HelpingMethods.SetTitle();
                book.Author = HelpingMethods.SetAuthor();

                try
                {
                    book.PublishDate = new DateTime(HelpingMethods.SetPublishYear(),
                                HelpingMethods.SetPublishMOnth(),
                                HelpingMethods.SetPublishDay());
                }
                finally
                {
                    Console.WriteLine("Has introducido algún dato erroneo");
                    Console.WriteLine("Se ha asignado como fecha de publicación el día de hoy");
                    book.PublishDate = DateTime.Today;
                }

                book.EntryDate = DateTime.Today;
                book.Copies = 1;

                // añado el libro al diccionario
                DictionaryName.Add(isbn, book);
            }
        }

        public void ShowAllBooks(Dictionary<string, Book> DictionaryName)
        {
            //ListarLibros listarLibros = new ListarLibros();
            // Listar todos los libros
            // TODO refactorizar listar todos los libros
            Console.Clear();
            Console.WriteLine("Has elegido listar todos los libros");

            ListarElementos.ListarLibros.ListarTodosLosLibros(DictionaryName);

            Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
            Console.ReadLine();

        }

        public void DeleteBook(Dictionary<string, Book> DictionaryName)
        {

            Console.WriteLine("Has elegido eliminar un libro");

            ListarElementos.ListarLibros.ListarTodosLosLibros(DictionaryName);

            string isbnToDelete;

            // TODO refactorizar la selección del libro por ISBN
            do
            {
                Console.WriteLine("Introduce el ISBN del libro que quieras eliminar");
                isbnToDelete = Console.ReadLine();
            } while (!DictionaryName.ContainsKey(isbnToDelete));

            Console.WriteLine("Estás seguro? (S/N)");
            string continuar = Console.ReadLine();

            if (continuar.Equals("S") || continuar.Equals("s"))
            {
                DictionaryName.Remove(isbnToDelete);
                ListarElementos.ListarLibros.ListarTodosLosLibros(DictionaryName);
            }
            else
            {
                Console.WriteLine("Operación abortada");
            }
            
            Console.WriteLine("Pulsa cualquier tecla para volver al menu principal");
            Console.ReadLine();

        }

        public void ModifyBook(Dictionary<string, Book> dictionaryName)
        {

            bool keepModifying = true;

            if (dictionaryName.Count() != 0)
            {
                ListarElementos.ListarLibros listarLibros = new ListarElementos.ListarLibros();

                while (keepModifying)
                {
                    // Modificar un libro
                    // TODO una vez funcione todo, refactorizar la funcionalidad de modificar

                    Console.WriteLine("Has elegido modificar un libro");

                    ListarElementos.ListarLibros.ListarTodosLosLibros(dictionaryName);

                    string isbnToModify;

                    do
                    {
                        Console.WriteLine("Introduce el ISBN del libro que quieras modificar");
                        isbnToModify = Console.ReadLine();
                    } while (!dictionaryName.ContainsKey(isbnToModify));

                    ListarElementos.ListarLibros.InfoLibro(dictionaryName, isbnToModify);

                    Console.WriteLine("¿Qué quiere modificar? Introduce el número de la opción que quieres realizar");
                    string actionToDo = Console.ReadLine();

                    switch (actionToDo)
                    {
                        case "Fecha de publicacion":
                            Console.Write("Introduce una nueva fecha de publicación (DD/MM/AAAA)");
                            dictionaryName[isbnToModify].PublishDate = DateTime.Parse(Console.ReadLine());
                            break;
                        case "Fecha de alta":
                            Console.Write("Introduce una nueva fecha de alta (DD/MM/AAAA): ");
                            dictionaryName[isbnToModify].EntryDate = DateTime.Parse(Console.ReadLine());
                            break;
                        case "Ejemplares":
                            Console.Write("Introduce una la cantidad de ejemplares que quieras: ");
                            dictionaryName[isbnToModify].Copies = int.Parse(Console.ReadLine());
                            break;
                        case "Autor":
                            dictionaryName[isbnToModify].Author = HelpingMethods.SetAuthor();
                            break;
                        case "Titulo":
                            dictionaryName[isbnToModify].Title = HelpingMethods.SetTitle();
                            break;
                        default:
                            Console.WriteLine("Elige una opción válida: ");
                            actionToDo = Console.ReadLine();
                            break;
                    }

                    Console.WriteLine("Quieres seguir?(S/N)");
                    string answer = Console.ReadLine();
                    if (answer.Equals("N") || answer.Equals("n"))
                    {
                        keepModifying = false;
                    }
                }

            }
            else
            {
                Console.WriteLine("No hay ningún libro, así que no puede modificar nada");
                Console.WriteLine("Pulsa cualquier tecla para continuar");
                Console.ReadLine();
                keepModifying = false;
            }
        }
    }
}

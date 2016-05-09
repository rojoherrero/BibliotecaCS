using EntitiesApi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookMenuApi
{
    public class BookMenu
    {

        public void AddNewBook(Dictionary<string, Book> dictionaryName)
        {
            string isbn;

            // Inicio la recogida de los datos para crear el nuevo libro
            isbn = ModifyingBook.SetIsbn();

            // Compruebo que no este el ISBN guardado
            if (dictionaryName.ContainsKey(isbn))
            {
                // Si el ISBN ya existe
                ModifyingBook.OneMoreBookCopy(dictionaryName, isbn);
            }
            else
            {
                //El ISBN no existe
                Book book = new Book();

                // Recogo los datos del libro y lo guardo en un libro nuevo
                book.ISBN = isbn;
                book.Title = ModifyingBook.SetTitle();
                book.Author = ModifyingBook.SetAuthor();

                try
                {
                    book.PublishDate = new DateTime(ModifyingBook.SetPublishYear(),
                                ModifyingBook.SetPublishMonth(),
                                ModifyingBook.SetPublishDay());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Se ha asignado como fecha de publicación el día de hoy");
                    book.PublishDate = DateTime.Today;
                }


                book.EntryDate = DateTime.Today;
                book.Copies = 1;

                // añado el libro al diccionario
                dictionaryName.Add(isbn, book);
            }
        }

        public void ShowAllBooks(Dictionary<string, Book> dictionaryName)
        {

            // Listar todos los libros
            // TODO refactorizar listar todos los libros
            Console.Clear();
            Console.WriteLine("Has elegido listar todos los libros");

            ListElements.ListAllBooks(dictionaryName);
            /*
            List<Book> bookList = DictionaryName.Values.ToList();
            bookList.ForEach(p=> Console.WriteLine("ISBN: {0}, Author: {1} and Title: {2}", p.ISBN, p.Author, p.Title));
            */
            Console.WriteLine("=============\nPulsa cualquier tecla para volver al menu principal");
            Console.ReadLine();

        }

        public void DeleteBook(Dictionary<string, Book> dictionaryName)
        {

            Console.WriteLine("Has elegido eliminar un libro");

            ListElements.ListAllBooks(dictionaryName);

            string isbnToDelete;

            // TODO refactorizar la selección del libro por ISBN
            do
            {
                Console.WriteLine("Introduce el ISBN del libro que quieras eliminar");
                isbnToDelete = Console.ReadLine();
            } while (!dictionaryName.ContainsKey(isbnToDelete));

            Console.WriteLine("Estás seguro? (S/N)");
            string continuar = Console.ReadLine();

            if (continuar.Equals("S") || continuar.Equals("s"))
            {
                dictionaryName.Remove(isbnToDelete);
                ListarElementos.ListarLibros.ListarTodosLosLibros(dictionaryName);
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

                while (keepModifying)
                {
                    // Modificar un libro
                    // TODO una vez funcione todo, refactorizar la funcionalidad de modificar

                    Console.WriteLine("Has elegido modificar un libro");

                    ListElements.ListAllBooks(dictionaryName);

                    string isbnToModify;

                    do
                    {
                        Console.WriteLine("Introduce el ISBN del libro que quieras modificar");
                        isbnToModify = Console.ReadLine();
                    } while (!dictionaryName.ContainsKey(isbnToModify));

                    ListElements.ShowBookInfo(dictionaryName, isbnToModify);

                    Console.WriteLine("¿Qué quiere modificar? Introduce el número de la opción que quieres realizar");
                    string actionToDo = Console.ReadLine();

                    switch (actionToDo)
                    {
                        case "1": // ISBN
                            dictionaryName[isbnToModify].ISBN = ModifyingBook.SetIsbn();
                            break;
                        case "5": // Fecha de publicación

                            try
                            {
                                dictionaryName[isbnToModify].PublishDate = new DateTime(ModifyingBook.SetPublishYear(),
                                                                                            ModifyingBook.SetPublishMonth(),
                                                                                            ModifyingBook.SetPublishDay());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine("Se ha asignado como fecha de publicación el día de hoy");
                                dictionaryName[isbnToModify].PublishDate = DateTime.Today;
                            }
                            break;

                        case "4": // Fecha de alta
                            Console.Write("Introduce una nueva fecha de alta (DD/MM/AAAA): ");
                            dictionaryName[isbnToModify].EntryDate = DateTime.Parse(Console.ReadLine());
                            break;
                        case "6": // Ejemplares
                            Console.Write("Introduce una la cantidad de ejemplares que quieras: ");
                            dictionaryName[isbnToModify].Copies = int.Parse(Console.ReadLine());
                            break;
                        case "2": // Autor

                            dictionaryName[isbnToModify].Author = ModifyingBook.SetAuthor();
                            break;
                        case "3": //Titulo

                            dictionaryName[isbnToModify].Title = ModifyingBook.SetTitle();
                            break;
                        default: // Opción no valida
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

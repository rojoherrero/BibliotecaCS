using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesApi
{
    public class Book
    {
        // Atributos del libro
        public string Author { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime EntryDate { get; set; }
        public int Copies { get; set; }

        // Constructor con todos los elementos
        public Book(string author, string title, string isbn, DateTime publishDate, DateTime entryDate, int copies)
        {
            Author = author;
            Title = title;
            ISBN = isbn;
            PublishDate = publishDate;
            EntryDate = entryDate;
            Copies = copies;
        }

        //Constructor vacio
        public Book()
        {
        }

        public string ShowTabulatedInfo()
        {
            StringBuilder info = new StringBuilder();
            info.Append(Author);
            info.Append("\t\t");
            info.Append(Title);
            info.Append("\t\t");
            info.Append(ISBN);
            info.Append("\t\t");
            info.Append(Copies);
            info.Append("\t\t");
            info.Append(PublishDate.ToShortDateString());
            info.Append("\t\t");
            info.Append(EntryDate.ToShortDateString());

            return info.ToString();
        }
    }
}

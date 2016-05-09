using EntitiesApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMenuApi
{
    internal class ListElements
    {

        public static void ListAllBooks(Dictionary<string, Book> dictionaryName)
        {
            List<Book> bookList = dictionaryName.Values.ToList();
            bookList.ForEach(p => Console.WriteLine("=============\nISBN: {0}, Author: {1}, Title: {2}\nPurchase Date: {3}, Publish Date: {4}, Copies: {5}", 
                p.ISBN, p.Author, p.Title, p.EntryDate.ToShortDateString(), p.PublishDate.ToShortDateString(), p.Copies));
        }

        public static void ShowBookInfo(Dictionary<string, Book> dictionaryName, string isbnToModify)
        {
            Console.WriteLine("1)ISBN: {0}, 2)Author: {1}, 3)Title: {2}\n4)Purchase Date: {3}, 5)Publish Date: {4}, 6)Copies: {5}", 
                dictionaryName[isbnToModify].ISBN, 
                dictionaryName[isbnToModify].Author, 
                dictionaryName[isbnToModify].Title,
                dictionaryName[isbnToModify].EntryDate.ToShortDateString(),
                dictionaryName[isbnToModify].PublishDate.ToShortDateString(),
                dictionaryName[isbnToModify].Copies);
        }
    }
}

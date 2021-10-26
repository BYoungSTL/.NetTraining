using System;
using System.Collections.Generic;
using NET02.Entities;

namespace NET02
{
    public class Program
    {
        private static Catalog InitCatalog()
        {
            Author firstAuthor = new Author
            {
                FirstName = "Boris",
                LastName = "Strugatckiy"
            };
            Author secondAuthor = new Author
            {
                FirstName = "Arkadiy",
                LastName = "Strugatckiy"
            };
            Author thirdAuthor = new Author
            {
                FirstName = "Ivan",
                LastName = "Turgenev"
            };
            Book firstBook = new Book
            {
                ISBNCode = "888-8-88-888888-8",
                Name = "Doomed City",
                PublicationDate = new DateTime(1972, 04, 27),
                Authors = new List<Author> { firstAuthor, secondAuthor }
            };
            Book secondBook = new Book
            {
                ISBNCode = "777-7-77-777777-7",
                Name = "Roadside Picnic",
                PublicationDate = new DateTime(1972, 04, 26),
                Authors = new List<Author> { firstAuthor, secondAuthor }
            };
            Book thirdBook = new Book
            {
                ISBNCode = "666-6-66-666666-6",
                Name = "Fathers and children",
                PublicationDate = new DateTime(1862, 05, 13),
                Authors = new List<Author> { thirdAuthor }
            };
            Catalog newCatalog = new Catalog
            {
                Books = new List<Book> {firstBook, secondBook, thirdBook}
            };
            return newCatalog;
        }
        static void Main(string[] args)
        {
            Catalog catalog = InitCatalog();
            
            var books = CatalogOperations.GetBooks(catalog, "Boris", "Strugatckiy");
            Console.WriteLine("Get Books: ");
            foreach (var book in books)
            {
                Console.WriteLine(book.Name + " " + book.ISBNCode + " " + book.PublicationDate);
            }

            var booksByDate = CatalogOperations.GetBooksByDate(catalog);
            Console.WriteLine("Get Books by date: ");
            foreach (var book in booksByDate)
            {
                Console.WriteLine(book.Name + " " + book.ISBNCode + " " + book.PublicationDate);
            }

            var authorBooks = CatalogOperations.GetAuthorBooks(catalog);
            Console.WriteLine("Get Author and books count: ");
            foreach (var dictionary in authorBooks)
            {
                Console.WriteLine(dictionary.Key.FirstName + " " + dictionary.Key.LastName + " " + dictionary.Value);
            }
        }
    }
}
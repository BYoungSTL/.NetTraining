using System;
using System.Collections.Generic;
using NET02.Entities;
using System.Linq;

namespace NET02
{
    public static class CatalogOperations
    {
        public static IEnumerable<Book> GetBooks(Catalog catalog, string firstName, string lastName)
        {
            var selected = catalog.Books.SelectMany(b =>
                b.Authors!.Where(a => a.FirstName.Equals(firstName) && a.LastName.Equals(lastName)));
            return catalog.Books.Where(b =>
                b.Authors != null &&
                b.Authors.Contains(selected.FirstOrDefault(a =>
                    a.FirstName == firstName && a.LastName == lastName)));
        }

        public static IEnumerable<Book> GetBooksByDate(Catalog catalog)
        {
            return catalog.Books.OrderByDescending(b => b.PublicationDate);
        }

        /// <summary>
        /// Dictionary keeps Author(Key) and count books by this Author(value)
        /// Authors are Distinct
        /// </summary>
        /// <param name="catalog"></param>
        /// <returns></returns>
        public static Dictionary<Author, int> GetAuthorBooks(Catalog catalog)
        {
            Dictionary<Author, int> authorBooks = new Dictionary<Author, int>();
            var selected = catalog.Books.SelectMany(b => b.Authors);
            foreach (var author in selected)
            {
                string firstName = author.FirstName;
                string lastName = author.LastName;
                var listBooks = GetBooks(catalog, firstName, lastName);
                int count = listBooks.Count();
                if (authorBooks.Keys.Contains(author))
                {
                    continue;
                }
                authorBooks.Add(author, count);
            }

            return authorBooks;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NET02.Entities
{
    public class Catalog : IEnumerable
    {
        public List<Book> Books { get; set; }
        
        //Fix Enumerator yield!, indexer
        //IEnumerator returns sorted list of books
        public IEnumerator GetEnumerator()
        {
            var books = Books.OrderBy(b => b.Name);
            return books.GetEnumerator();
        }

        public Book this[string isbnCode]
        {
            get
            {
                if (!Books.Contains(new Book(isbnCode)))
                {
                    return null;
                }
                
                return Books.FirstOrDefault(b => b.ISBNCode.Equals(Book.ISBNCodeСoercion(isbnCode)));
            }
        }
        
        public IEnumerable<Book> GetBooks(Author author)
        {
            return Books.Where(b => b.Authors.Any(a=>a.Equals(author)));
        }

        public IEnumerable<Book> GetBooksByDate()
        {
            return Books.OrderByDescending(b => b.PublicationDate);
        }

        /// <summary>
        /// Dictionary keeps Author(Key) and count books by this Author(value)
        /// Authors are Distinct
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetAuthorBooks()
        {
            var s = Books.SelectMany(b => b.Authors);
            var selected = s.GroupBy(x=>x.FirstName).Select(x => new {Name = x.Key, Count = x.Count()});
            foreach (var v in selected)
            {
                Console.WriteLine($"{v.Name} : {v.Count}");
            }

            return selected;
        }
    }
}
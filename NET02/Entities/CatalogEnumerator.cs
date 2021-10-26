using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NET02.Entities
{
    public class CatalogEnumerator : IEnumerator
    {
        private List<Book> _books;
        private int _position = -1;

        public CatalogEnumerator(List<Book> books)
        {
            _books = books;
            Sort(_books);
        }

        public bool MoveNext()
        {
            if (_position < _books.Count - 1)
            {
                _position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = -1;
        }

        public object Current
        {
            get
            {
                if (_position == -1 || _position > _books.Count - 1)
                {
                    throw new InvalidOperationException("Invalid position");
                }

                return _books[_position];
            }
            
        }

        private static void Sort(List<Book> books)
        {
            books = new List<Book>(books.OrderBy(b => b.Name));
        }
    }
}
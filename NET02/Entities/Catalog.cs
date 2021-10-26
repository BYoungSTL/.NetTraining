using System.Collections;
using System.Collections.Generic;

namespace NET02.Entities
{
    public class Catalog : IEnumerable
    {
        public List<Book> Books { get; set; }
        
        //IEnumerator returns sorted list of books
        public IEnumerator GetEnumerator()
        {
            yield return new CatalogEnumerator(Books);
        }
    }
}
using System.Collections.Generic;

namespace NET02.Entities
{
    public class Catalog
    {
        private string _isbnCode;

        public List<Book> Books { get; set; }
    }
}
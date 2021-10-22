using System;
using System.Collections.Generic;

namespace NET02.Entities
{
    public class Book
    {
        private string _isbnCode;
        private string _name;
        public DateTime? PublicationDate { get; set; }
        public List<Author>? Authors { get; set; }

        public string ISBNCode
        {
            get => _isbnCode;
            set
            {
                while (value.IndexOf("-", StringComparison.Ordinal) != -1)
                {
                    if (value.IndexOf("-", StringComparison.Ordinal) >= 0)
                    {
                        int index = value.IndexOf("-", StringComparison.Ordinal);
                        value = value.Remove(index, 1);
                    }
                }

                _isbnCode = value;
            }
        }
    }
}
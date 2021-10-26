using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NET02.Entities
{
    public class Book
    {
        private const int NameLength = 1000;
        private string _isbnCode;
        private string _name;
        
        //Regex is necessary for check form of ISBN code
        private readonly Regex _firstRegex = new (@"[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}");
        private readonly Regex _secondRegex = new ("[0-9]{13}");
        public DateTime? PublicationDate { get; set; }
        public List<Author>? Authors { get; set; }

        public string ISBNCode
        {
            get => _isbnCode;
            set => _isbnCode = SettingISBNCode(value);
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > NameLength)
                {
                    throw new ArgumentException($"Invalid Name of Author(max length = {NameLength})");
                }

                _name = value;
            }
        }

        /*
         * Method checks ISBN code, and shaping to XXXXXXXXXXXXX form
         * (ISBN code can be only in 2 forms: XXX-X-XX-XXXXXX-X and XXXXXXXXXXXXX  
         */
        private string SettingISBNCode(string value)
        {
            Match match = _firstRegex.Match(value);
            if (match.Success)
            {
                _isbnCode = match.Value;
            }
            else
            {
                match = _secondRegex.Match(value);
                if (!match.Success)
                {
                    throw new ArgumentException("Invalid isbn code");
                }

                _isbnCode = match.Value;
            }
            
            while (_isbnCode.IndexOf("-", StringComparison.Ordinal) != -1)
            {
                if (_isbnCode.IndexOf("-", StringComparison.Ordinal) >= 0)
                {
                    int index = _isbnCode.IndexOf("-", StringComparison.Ordinal);
                    _isbnCode = _isbnCode.Remove(index, 1);
                }
            }

            return _isbnCode;
        }
    }
}
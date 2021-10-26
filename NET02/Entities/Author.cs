using System;

namespace NET02.Entities
{
    public class Author
    {
        private const int NameLength = 200;
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value.Length > NameLength && value != null)
                {
                    throw new ArgumentException("Invalid First name of Author");
                }

                _firstName = value;
            }
        }
        
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value.Length > NameLength)
                {
                    throw new ArgumentException("Invalid Last name of Author");
                }

                _lastName = value;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Author)
            {
                return false;
            }
            Author s = (Author) obj;
            return FirstName == s.FirstName && LastName == s.LastName;
        }
    }
}
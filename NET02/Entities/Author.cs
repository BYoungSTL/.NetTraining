using System;

namespace NET02.Entities
{
    public class Author
    {
        private string _name;
        private string _secondName;
        
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > 200)
                {
                    throw new ArgumentException("Invalid name of Author");
                }

                _name = value;
            }
        }
        
        public string SecondName
        {
            get => _secondName;
            set
            {
                if (value.Length > 200)
                {
                    throw new ArgumentException("Invalid second name of Author");
                }

                _secondName = value;
            }
        }
    }
}
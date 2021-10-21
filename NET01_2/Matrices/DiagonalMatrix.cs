using System;

namespace NET01_2.Matrices
{
    public class DiagonalMatrix<T> : ICloneable
    {
        private T[] _diagonal;
        private int _size;

        public DiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Invalid size of matrix");
            }

            _size = size;
            _diagonal = new T[size];
        }

        public T this[int i, int j]
        {
            get
            {
                if (i > _size - 1 || j > _size - 1 || i < 0 || j < 0)
                {
                    throw new ArgumentException("Invalid index");
                }

                if (i == j)
                {
                    return _diagonal[i];
                }

                return default;
            }
            set
            {
                if (i > _size - 1 || j > _size - 1 || i < 0 || j < 0)
                {
                    throw new ArgumentException("Invalid index");
                }

                if (i == j)
                {
                    _diagonal[i] = value;
                }
            }
        }
        

        public object Clone()
        {
            return new DiagonalMatrix<T>(_size)
            {
                _diagonal = this._diagonal,
                _size = this._size
            };
            
        }

        public void Output()
        {
            Console.WriteLine("Diagonal Matrix: ");
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(this[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
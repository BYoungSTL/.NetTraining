using System;

namespace NET01_2.Matrices
{
    public class SquareMatrix<T> : ICloneable
    {
        private int _size;
        private T[] _matrix;

        public SquareMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Invalid size of matrix");
            }

            _size = size;
            _matrix = new T[size * size];
        }
        
        public T this[int i, int j]
        {
            get
            {
                if (i > _size - 1 || j > _size - 1 || i < 0 || j < 0)
                {
                    throw new ArgumentException("Invalid index");
                }

                return _matrix[_size * j + i];
            }
            set
            {
                if (i > _size - 1 || j > _size - 1 || i < 0 || j < 0)
                {
                    throw new ArgumentException("Invalid index");
                }

                _matrix[_size * j + i] = value;
            }
        }
        
        public object Clone()
        {
            return new SquareMatrix<T>(_size)
            {
                _matrix = this._matrix,
                _size = this._size
            };
        }

        public void Output()
        {
            Console.WriteLine("Square Matrix: ");
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write(this[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
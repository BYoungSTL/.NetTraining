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
        /* Indexer of Square Matrix:
             - all matrix keeps as a single array
             _matrix[_size * j + i] == _matrix[i,j] */
        public T this[int i, int j]
        {
            get
            {
                if (i > _size || j > _size || i < 0 || j < 0)
                {
                    throw new ArgumentException("Invalid index");
                }

                return _matrix[_size * j + i];
            }
            set
            {
                if (i > _size || j > _size || i < 0 || j < 0)
                {
                    throw new ArgumentException("Invalid index");
                }

                _matrix[_size * j + i] = value;
            }
        }
        
        /* deep clone, "_matrix = this._matrix" it is not a deep copy */
        public object Clone()
        {
            T[] newMatrix = new T[_size * _size];
            for (int i = 0; i < _size * _size; i++)
            {
                newMatrix[i] = _matrix[i];
            }
            return new SquareMatrix<T>(_size)
            {
                _matrix = newMatrix,
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
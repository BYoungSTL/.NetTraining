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

        /* Indexer of Diagonal Matrix:
           - all elements that are not on the main diagonal (i==j) have a default value
           - keeps only main diagonal, all other elements doesn't keep */
        public T this[int i, int j]
        {
            get
            {
                if (i > _size || j > _size || i < 0 || j < 0)
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
                if (i > _size || j > _size || i < 0 || j < 0)
                {
                    throw new ArgumentException("Invalid index");
                }

                if (i == j)
                {
                    _diagonal[i] = value;
                }
            }
        }
        

        /* deep clone, "_diagonal = this._diagonal" it is not a deep copy */
        public object Clone()
        {
            T[] newDiagonal = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                newDiagonal[i] = _diagonal[i];
            }
            return new DiagonalMatrix<T>(_size)
            {
                _diagonal = newDiagonal,
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
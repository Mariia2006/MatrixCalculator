using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp85
{
    partial class MyMatrix
    {
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            double[,] result = new double[a.Row, a.Column];

            if (a.Row != b.Row || a.Column != b.Column)
            {
                throw new InvalidOperationException("Matrices must be the same size for addition.");
            }

            for (int i = 0; i < a.Row; i++)
            {
                for (int j = 0; j < a.Column; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return new MyMatrix(result);
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.Column != b.Row)
            {
                throw new InvalidOperationException("The number of columns of the first matrix must be equal to the number of rows of the second matrix for multiplication.");
            }

            double[,] result = new double[a.Row, b.Column];

            for (int i = 0; i < a.Row; i++)
            {
                for (int j = 0; j < b.Column; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < a.Column; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return new MyMatrix(result);
        }

        // приватний метод для отримання транспонованого double[,]
        private double[,] GetTransponedArray()
        {
            double[,] transposed = new double[Column, Row];

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }
            return transposed;
        }

        // отримання нової транспонованої копії mymatrix
        public MyMatrix GetTransponedCopy()
        {
            double[,] transposedArray = GetTransponedArray();
            return new MyMatrix(transposedArray);
        }

        // транспонування поточної матриці
        public void TransponeMe()
        {
            matrix = GetTransponedArray();
        }
    }
}

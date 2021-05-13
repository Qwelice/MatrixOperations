using System;

namespace MatrixOperations
{
    static class Operation
    {
        public static double[,] times(double[,] a, double[,] b)
        {
            try
            {
                if (a.GetLength(1) != b.GetLength(0))
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Неподходящие размерности матриц", ex);
            }
            var result = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }

        public static double[,] times(double[,] matrix, double csta)
        {
            var result = new double[matrix.GetLength(0),matrix.GetLength(1)];
            for(int i = 0; i < result.GetLength(0); i++)
            {
                for(int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = matrix[i, j] * csta;
                }
            }
            return result;
        }

        public static double[,] times(double csta, double[,] matrix)
        {
            var result = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = matrix[i, j] * csta;
                }
            }
            return result;
        }

        public static double[,] plus(double[,] a, double[,] b)
        {
            if(a.GetLength(0) == b.GetLength(0) && a.GetLength(1) == b.GetLength(1))
            {
                var result = new double[a.GetLength(0), a.GetLength(1)];
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        result[i, j] = a[i,j] + b[i,j];
                    }
                }
                return result;
            }
            throw new InvalidOperationException("Неподходящие размерности матриц");
        }
    }
}

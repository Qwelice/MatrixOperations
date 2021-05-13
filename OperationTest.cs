using System;
using System.Diagnostics;
using System.Threading;

namespace MatrixOperations
{
    /// <summary>
    /// Статический класс тестирующий быстродействие операций
    /// </summary>
    static class OperationTest
    {
        static Random rand = new Random(-245);
        /// <summary>
        /// Метод сравнивающий быстродействия последовательного и
        /// параллельного умножения матриц
        /// </summary>
        /// <param name="n1">количество строк первой матрицы</param>
        /// <param name="m1">количество столбцов первой матрицы</param>
        /// <param name="n2">количество строк второй матрицы</param>
        /// <param name="m2">количество столбцов второй матрицы</param>
        public static void MatrixMultiplication(int n1, int m1, int n2, int m2)
        {
            var a = createRandomMatrix(n1, m1);
            var b = createRandomMatrix(n2, m2);
            var c = (double[,])a.Clone();
            var d = (double[,])b.Clone();

            var t1 = new Thread(()=>{
                var st = new Stopwatch();
                st.Reset();
                st.Start();
                Operation.Times(a, b);
                st.Stop();
                Console.WriteLine($"\nSequentional Matrix Multiplication calculation\n" +
                    $"Timestamp: {st.ElapsedMilliseconds} ms.\n");
                st.Reset();
            });
            var t2 = new Thread(() => {
                var st = new Stopwatch();
                st.Reset();
                st.Start();
                ParallelOperation.Times(c, d);
                st.Stop();
                Console.WriteLine($"\nParallel Matrix Multiplication calculation\n" +
                    $"Timestamp: {st.ElapsedMilliseconds} ms.\n");
                st.Reset();
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }
        /// <summary>
        /// Метод сравнивающий быстродействия последовательного и
        /// параллельного сложения матриц
        /// </summary>
        /// <param name="n1">количество строк первой матрицы</param>
        /// <param name="m1">количество столбцов первой матрицы</param>
        /// <param name="n2">количество строк второй матрицы</param>
        /// <param name="m2">количество столбцов второй матрицы</param>
        public static void MatrixAdditionTest(int n1, int m1, int n2, int m2)
        {
            var a = createRandomMatrix(n1, m1);
            var b = createRandomMatrix(n2, m2);
            var c = (double[,])a.Clone();
            var d = (double[,])b.Clone();

            var t1 = new Thread(() => {
                var st = new Stopwatch();
                st.Reset();
                st.Start();
                Operation.Plus(a, b);
                st.Stop();
                Console.WriteLine($"\nSequentional Matrix Addition calculation\n" +
                    $"Timestamp: {st.ElapsedMilliseconds} ms.\n");
                st.Reset();
            });
            var t2 = new Thread(() => {
                var st = new Stopwatch();
                st.Reset();
                st.Start();
                ParallelOperation.Plus(c, d);
                st.Stop();
                Console.WriteLine($"\nParallel Matrix Addition calculation\n" +
                    $"Timestamp: {st.ElapsedMilliseconds} ms.\n");
                st.Reset();
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }
        /// <summary>
        /// Метод сравнивающий быстродействия последовательного и
        /// параллельного умножения матрицы на скаляр
        /// </summary>
        /// <param name="n">количество строк матрицы</param>
        /// <param name="m">количество столбцов матрицы</param>
        /// <param name="scalar">скаляр</param>
        public static void MatrixScalarMultiplicationTest(int n, int m, double scalar)
        {
            var matrix = createRandomMatrix(n, m);
            var t1 = new Thread(() => {
                var st = new Stopwatch();
                st.Reset();
                st.Start();
                Operation.Times(matrix, scalar);
                st.Stop();
                Console.WriteLine($"\nSequentional Matrix-Scalar Multiplication calculation\n" +
                    $"Timestamp: {st.ElapsedMilliseconds} ms.\n");
                st.Reset();
            });
            var t2 = new Thread(() => {
                var st = new Stopwatch();
                st.Reset();
                st.Start();
                ParallelOperation.Times(matrix, scalar);
                st.Stop();
                Console.WriteLine($"\nParallel Matrix-Scalar Multiplication calculation\n" +
                    $"Timestamp: {st.ElapsedMilliseconds} ms.\n");
                st.Reset();
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }

        static double[,] createRandomMatrix(int n, int m)
        {
            var result = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = Math.Round(rand.NextDouble() * rand.Next(10, 100) * 100) / 100.0;
                }
            }
            return result;
        }
    }
}

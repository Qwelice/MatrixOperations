using System;
using System.Diagnostics;
using System.Threading;

namespace MatrixOperations
{
    static class OperationTest
    {
        static Random rand = new Random(-245);
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
                Operation.times(a, b);
                st.Stop();
                Console.WriteLine($"\nSequentional Matrix Multiplication calculation\n" +
                    $"Timestamp: {st.ElapsedMilliseconds} ms.\n");
                st.Reset();
            });
            var t2 = new Thread(() => {
                var st = new Stopwatch();
                st.Reset();
                st.Start();
                ParallelOperation.times(c, d);
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
                Operation.plus(a, b);
                st.Stop();
                Console.WriteLine($"\nSequentional Matrix Addition calculation\n" +
                    $"Timestamp: {st.ElapsedMilliseconds} ms.\n");
                st.Reset();
            });
            var t2 = new Thread(() => {
                var st = new Stopwatch();
                st.Reset();
                st.Start();
                ParallelOperation.plus(c, d);
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

        public static void MatrixScalarMultiplicationTest(int n, int m, double scalar)
        {
            var matrix = createRandomMatrix(n, m);
            var t1 = new Thread(() => {
                var st = new Stopwatch();
                st.Reset();
                st.Start();
                Operation.times(matrix, scalar);
                st.Stop();
                Console.WriteLine($"\nSequentional Matrix-Scalar Multiplication calculation\n" +
                    $"Timestamp: {st.ElapsedMilliseconds} ms.\n");
                st.Reset();
            });
            var t2 = new Thread(() => {
                var st = new Stopwatch();
                st.Reset();
                st.Start();
                ParallelOperation.times(matrix, scalar);
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

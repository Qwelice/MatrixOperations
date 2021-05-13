using System;

namespace MatrixOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            OperationTest.MatrixMultiplication(500, 500, 500, 500);
            OperationTest.MatrixAdditionTest(5000, 5000, 5000, 5000);
            OperationTest.MatrixScalarMultiplicationTest(5000, 5000, 100000);
            Console.ReadKey();
        }

        static void Print(double[,] arr)
        {
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0, -20}", arr[i, j]);
                }
                Console.WriteLine('\n');
            }
        }
    }
}

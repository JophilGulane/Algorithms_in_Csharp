namespace MatrixAddition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] A = { { 1, 2, 3 },
                         { 4, 5, 6 },
                         { 6, 7, 8 } };

            int[,] B = { { 1, 2, 3 },
                         { 4, 5, 6 },
                         { 6, 7, 8 } };

            int[,] C;

            int rows = A.GetLength(0);
            int cols = B.GetLength(1);

            C = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }

            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(C[i, j]+ " ");
                }
                Console.WriteLine();

            }
        }
    }
}

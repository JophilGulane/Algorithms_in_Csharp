namespace MatrixMultiplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[,] A = { { 1, 2, 3 },
                         { 4, 5, 6 }, 
                         { 6, 7, 8 } };

            int[,] B = { { 1, 2, 3 },
                         { 4, 5, 6 },
                         { 6, 7, 8 } };

            int rows = A.GetLength(0);
            int cols = B.GetLength(1);

            if (rows != cols) return;



            int[,] C = new int[3,3];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    C[i, j] = 0;

                    for (int k = 0; k < A.GetLength(1); k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(C[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

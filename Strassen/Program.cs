namespace Strassen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static int[,] AddMatrix(int[,] A, int[,] B)
        {
            int r = A.GetLength(0);
            int c = B.GetLength(1);
            int[,] result = new int[r, c];

            if (A == B)
            {  
                for (int i = 0; i < r; i++) {
                    for (int j = 0; j < c; j++)
                    {
                        result[i, j] = A[i, j] + B[i, j];
                    }
                    
                }
            }

            return result;

        }

        static int[,] SubtractMatrix(int[,] A, int[,] B)
        {
            int r = A.GetLength(0);
            int c = B.GetLength(1);
            int[,] result = new int[r, c];

            if (A == B)
            {
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        result[i, j] = A[i, j] - B[i, j];
                    }

                }
            }

            return result;

        }

        static int[,] Strassen(int[,] A, int[,] B)
        {
            int n = A.Length;
            int r = A.GetLength(0);
            int c = B.GetLength(1);

            if (n == 1)
            {
                int[,] result = new int[1, 1];
                result[0, 0] = A[0, 0] * B[0, 0];
                return result;
            }

            int size = n / 2;
            int[,] a11 = new int[size, size];
            int[,] b11 = new int[size, size];
            int[,] a12 = new int[size, size];
            int[,] b12 = new int[size, size];
            int[,] a21 = new int[size, size];
            int[,] b21 = new int[size, size];
            int[,] a22 = new int[size, size];
            int[,] b22 = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    a11[i, j] = A[i, j];
                    a12[i, j] = A[i, j + size];
                    a21[i, j] = A[i + size, j];
                    a22[i, j] = A[i + size, j + size];

                    b11[i, j] = B[i, j];
                    b12[i, j] = B[i, j + size];
                    b21[i, j] = B[i + size, j];
                    b22[i, j] = B[i + size, j + size];
                }
            }
            int[,] p = Strassen(AddMatrix(a11, a22), AddMatrix(b11, b22));
            int[,] q = Strassen(AddMatrix(a21, a22), b11);
        }
    }
}

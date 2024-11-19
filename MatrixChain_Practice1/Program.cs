using System.Transactions;

namespace MatrixChain_Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of matrices: ");
            int n = int.Parse(Console.ReadLine());
            int[] dimension = new int[n + 1];

            Console.WriteLine("Enter the dimensions of the matrices");
            for (int i = 0; i <= n; i++)
            {
                Console.Write($"Enter the dimensions[{i}]: ");
                dimension[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(MatrixChainMultiplication(dimension, n + 1)); 
        }

        static int MatrixChainMultiplication(int[] p, int n)
        {
            int[,] m = new int[n,n];
            int[,] s = new int[n,n];

            for(int diff = 1; diff < n - 1; diff++)
            {
                for (int i = 1; i < n - diff; i++)
                {
                    int j = i + diff;
                    int min = int.MaxValue;

                    for (int k = i; k <= j - 1; k++)
                    {
                        int q = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];
                        if (q < min)
                        {
                            min = q;
                            s[i, j] = k;
                        }
                    }
                    m[i, j] = min;
                }

            }
            return m[1, n - 1];
        }
    }
}
 
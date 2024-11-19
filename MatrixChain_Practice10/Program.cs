namespace MatrixChain_Practice10
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
            Console.WriteLine(MatrixChain(dimension, n + 1 ));
        }

        static int MatrixChain(int[] P, int n)
        {
            int[,] m = new int[n, n];
            int[,] s = new int[n, n];

            for(int diff = 1; diff < n - 1; diff++)
            {
                for (int i = 1; i < n - diff; i++)
                {

                    int j = i + diff;
                    m[i, j] = int.MaxValue;

                    for (int k = 1; k <= j - 1; k++)
                    {
                        int q = m[i, k] + m[k + 1, j] + P[i - 1] * P[k] * P[j];
                        if (q < m[i, j])
                        {
                            m[i,j] = q;
                            s[i, j] = k;
                        }

                    }  
                }
            }

            return m[1, n - 1];
        }
    }
}

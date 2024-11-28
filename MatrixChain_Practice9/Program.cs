namespace MatrixChain_Practice9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter How many Matrices: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            int[] dim = new int[n + 1];
             
            for(int i = 0; i <= n; i++)
            {
                Console.Write($"Enter dimension {i}: ");
                dim[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();

            Console.WriteLine($"Minimum Cost: {MatrixChain(dim, n + 1)}");
        }

        static int MatrixChain(int[] dim, int n)
        {
            int[,] m = new int[n, n];
            int[,] s = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                m[i, i] = 0;
            }

            for (int dif = 1; dif < n; dif++)
            {
                for (int i = 1; i < n - dif; i++)
                {
                    int j = dif + i;
                    m[i, j] = int.MaxValue;

                    for(int k = 0; k <= j - 1; k++)
                    {
                        int p = m[i, k] + m[k+1, j] + dim[i-1] * dim[k] * dim[j];
                        m[i, j] = p;
                        s[i, j] = k;
                    }
                }
            }
            return m[1, n - 1];
        }
    }
}

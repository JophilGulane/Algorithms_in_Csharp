namespace MatrixChain_Practice15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number of Matrices: ");
            int n = int.Parse(Console.ReadLine());
            int[] dim = new int[n + 1];

            for(int i = 0; i <= n; i++)
            {
                Console.Write($"Enter Dimension {i}: ");
                dim[i] = int.Parse(Console.ReadLine());

            }

            Console.WriteLine($"Minimum Cost is {MCM(dim, n + 1)}");
        }

        static int MCM(int[] dim, int n)
        {
            int[,] m = new int[n, n];
            int[,] s = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                m[i, i] = 0;
            }

            for (int dif = 1; dif < n - 1; dif++)
            {
                for (int i = 1; i < n - dif; i++)
                {
                    int j = i + dif;
                    m[i, j] = int.MaxValue;

                    for (int k = i; k <= j - 1; k++)
                    {
                        int p = m[i, k] + m[k + 1, j] + dim[i - 1] * dim[k] * dim[j];

                        if (p < m[i, j])
                        {
                            m[i, j] = p;
                            s[i, j] = k;
                        }
                    }
                }
            }
            Console.WriteLine(OptimalParen(s, 1, n - 1)); 
            return m[1, n - 1];
        }

        public static string OptimalParen(int[,] s, int i, int j)
        {
            if (i == j) { return $"A{i}"; }

            int k = s[i, j];
            string left = OptimalParen(s, i, k);
            string right = OptimalParen(s, k + 1, j);
            return $"({left}*{right})";
        }
    }
}

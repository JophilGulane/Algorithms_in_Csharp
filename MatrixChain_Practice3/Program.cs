namespace MatrixChain_Practice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static int MatrixChain(int[] p, int n)
        {
            int[,] m = new int[n, n];
            int[,] s = new int[n, n];

            for(int d = 1; d < n - 1; d++)
            {
                for (int i = 1; i < n - d; i++)
                {
                    int min = int.MaxValue;
                    int j = i + d;

                    for(int k = i; k <= j - 1; k++)
                    {
                        int q = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];
                        
                        if(q < min)
                        {
                            min = q;
                            s[i, j] = q;
                        }
                    }
                    m[i,j] = min;
                }
            }
            return m[1, n - 1];
        }
    }
}

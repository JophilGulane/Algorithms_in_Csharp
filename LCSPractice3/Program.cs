
namespace LCSPractice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var (length, lcs) = LCS("logarithmic", "algorithm");
            Console.WriteLine(length + " " + lcs);
        }

        static (int, string) LCS(string X, string Y)
        {
            int r = X.Length;
            int c = Y.Length;

            int[,] dp = new int[r + 1, c + 1];

            for (int i = 1; i <= r; i++)
            {
                for (int j = 1; j <= c; j++)
                {
                    if (X[i - 1] == Y[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            int length_of_lcs = dp[r, c];

            string lcs = "";

            int x = r;
            int y = c;

            while (x > 0 && y > 0)
            {
                if (X[x - 1] == Y[y - 1])
                {
                    lcs = X[x - 1] + lcs;
                    x--;
                    y--;
                }
                else if (dp[x - 1, y] > dp[x, y - 1])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }
            return (length_of_lcs, lcs);
        }
    }
}

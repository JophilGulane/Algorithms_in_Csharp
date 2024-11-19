namespace LCSPractice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var (length, lcs) = LCS("logarithm", "algorithm");
        }

        static (int, string) LCS(string string_one, string string_two)
        {
            int r = string_one.Length;
            int c = string_two.Length;
            int[,] dp = new int[r + 1, c + 1];

            for (int i = 0; i <= r; i++)
            {
                for (int j = 0; j <= c; j++)
                {
                    if (string_one[i - 1] == string_two[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }

                    else
                    {
                        dp[i,j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            int length_of_lcs = dp[r, c];
            string lcs = "";
            int x = r;
            int y = c;

            while (x > 0 && y > 0)
            {
                if (string_one[x - 1] == string_two[y - 1])
                {
                    lcs = string_one[x - 1] + lcs;
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
        }   
    }
}

namespace LCS_Practice6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstString = "catcagat";
            string secondString = "cacataga";

            var (lcsLength, lcs) = LCS(firstString, secondString);

            Console.WriteLine($"LLCS: {lcsLength}, LCS: {lcs}");
        }

        static (int, string) LCS(string firstString, string secondString)
        {
            int rows = firstString.Length;
            int cols = secondString.Length;

            int[,] table = new int[rows + 1, cols + 1];

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    if (firstString[i - 1] == secondString[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1] + 1; 
                    }
                    else
                    {
                        table[i, j] = Math.Max(table[i-1, j], table[i, j-1]);
                    }
                }
            }

            int LLCS = table[rows, cols];
            string LCS = "";
            int x = rows;
            int y = cols;

            while (x > 0 && y > 0)
            {
                if (table[x - 1, y] == table[x, y - 1])
                {
                    LCS = firstString[x - 1] + LCS;
                    x--;
                    y--;
                }
                else if (table[x, y - 1] > table[x - 1, y])
                {
                    y--;
                }
                else
                {
                    x--;
                }
            }

            return (LLCS, LCS);


        }
    }
}

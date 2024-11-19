namespace MinimumNumber_Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] d = { 10, 5, 1 };
            int y = 37;
            int[] F = MinCoins(d, y);

            foreach (int i in F)
            {
                Console.Write(i + " ");
            }
        }

        static int[] MinCoins(int[] d, int y)
        {
            int[] F = new int[d.Length];

            for(int i = 0; i < d.Length; i++)
            {
                F[i] = y / d[i];
                y = y % d[i];

                if (y == 0) break;

            }

            return F;
        }
    }
}

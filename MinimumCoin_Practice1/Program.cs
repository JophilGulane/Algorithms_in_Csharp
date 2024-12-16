namespace MinimumCoin_Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[] coins = Array.ConvertAll(Console.ReadLine().Split(','), coin => int.Parse(coin));

            Console.WriteLine();
            int money = int.Parse(Console.ReadLine());

            int[] result = MinCoins(coins, money);

            for(int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(coins[i] +" :  " + result[i]);
            }
        }

        static int[] MinCoins(int[] coins, int money)
        {
            int[] result = new int[coins.Length];

            for (int i = 0; i < coins.Length; i++)
            {
                result[i] = money / coins[i];
                money = money % coins[i];

                if (money <= 0) break;
            }

            return result;
        }
    }
}

namespace MinimumCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Value of Coins: (ex. 20,10,5,1) comma seperated ','");
            double[] Coins = Array.ConvertAll(Console.ReadLine().Split(','), coin => double.Parse(coin.Trim()));

            Console.Write("Enter Money: ");
            double money = double.Parse(Console.ReadLine());

            double[] result = MinCoins(Coins, money);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write($"{Coins[i]} : {result[i]}  ");
            }




        }
        
        static double[] MinCoins(double[] Coins, double Money)
        {
            double[] result = new double[Coins.Length];

            for(int i = 0; i < Coins.Length; i++)
            {
                result[i] = Math.Floor(Money / Coins[i]);
                Money = Money % Coins[i];

                if (Money == 0) break;
            }
            return result;
        }
    }
}

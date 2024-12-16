namespace MinimumCoin_Practice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Coins:");
            int[] coin = Array.ConvertAll(Console.ReadLine().Split(','), coin => int.Parse(coin.Trim()));

            Console.WriteLine("Enter money");
            int money = int.Parse(Console.ReadLine());

            int[] result = MinCoin(coin, money);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write($"{coin[i]} : {result[i]} ");
            }
            Console.WriteLine();


        }

        static int[] MinCoin(int[] coin, int money)
        {
            int[] result = new int[coin.Length];

            for (int i = 0; i < coin.Length; i++)
            {
                result[i] = money / coin[i];
                money = money % coin[i];

                if (money <= 0) break;
            }
            return result;
        }
    }
}

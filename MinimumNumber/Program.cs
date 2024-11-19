using System;

namespace MinimumCoinsGreedy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the denominations of the coins (sorted largest to smallest)
            int[] denominations = { 10, 5, 1 };

            // Define the target amount
            Console.Write("Enter the target amount (in pence): ");
            int targetAmount = int.Parse(Console.ReadLine());

            // Get the minimum number of coins
            int[] result = GetMinimumCoins(denominations, targetAmount);

            // Display results
            Console.WriteLine("Distribution of coins (f): " + string.Join(", ", result));
            Console.WriteLine("Minimum number of coins: " + GetTotalCoins(result));
        }

        // Function to get the minimum number of coins
        static int[] GetMinimumCoins(int[] coins, int amount)
        {
            int[] coinDistribution = new int[coins.Length];  // Array F to store the count of each coin type
            int balance = amount;

            for (int i = 0; i < coins.Length; i++)
            {
                coinDistribution[i] = balance / coins[i];  // Calculate how many of this coin can be used
                balance = balance % coins[i];              // Update balance

                if (balance == 0) break;                   // Exit early if balance is zero
            }

            return coinDistribution;                      // Return the coin distribution array F
        }

        // Helper function to calculate the total number of coins used
        static int GetTotalCoins(int[] coinDistribution)
        {
            int total = 0;
            for (int i = 0; i < coinDistribution.Length; i++)
            {
                total += coinDistribution[i];
            }
            return total;
        }
    }
}

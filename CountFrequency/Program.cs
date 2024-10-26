namespace CountFrequency
{
    internal class Program
    {
        static Dictionary<char, int> frequency = new Dictionary<char, int>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string user_input = Console.ReadLine();

            foreach (char c in user_input)
            {
                if (frequency.ContainsKey(c))
                {
                    frequency[c]++;
                }
                else
                {
                    frequency[c] = 1;
                }
            }
            var sortedFrequencies = frequency.OrderBy(f => f.Key).ToList();
            foreach (var i in sortedFrequencies)
            {
                Console.WriteLine($"{i.Key} : {i.Value}");
            }

        }
    }
}

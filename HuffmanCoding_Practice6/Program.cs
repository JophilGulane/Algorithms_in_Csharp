namespace HuffmanCoding_Practice6
{
    internal class Program
    {
        public class Node
        {
            public Char Character;
            public int Frequency;
            public Node Left;
            public Node Right;
            public bool IsLeaf => Left == null && Right == null;
        }

        public static Node HuffmanTree(Dictionary<char, int> frequencies)
        {
            var nodes = new List<Node>();

            foreach (var kvp in frequencies)
            {
                nodes.Add(new Node { Character = kvp.Key, Frequency = kvp.Value });
            }

            while (nodes.Count > 1)
            {
                nodes = nodes.OrderBy(x => x.Frequency).ToList();

                var left = nodes[0];
                var right = nodes[1];
                var parent = new Node { Frequency = left.Frequency + right.Frequency, Left = left, Right = right };

                nodes.Remove(left);
                nodes.Remove(right);
                nodes.Add(parent);
            }

            return nodes[0];
        }

        public static void HuffmanCoding(Node root, string currentCode, Dictionary<char, string> huffmanCodes)
        {
            if (root == null) return;
            if (root.IsLeaf)
            {
                huffmanCodes[root.Character] = currentCode;
            }
            HuffmanCoding(root.Left, currentCode + "0", huffmanCodes);
            HuffmanCoding(root.Right, currentCode + "1", huffmanCodes);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Message: ");
            string message = Console.ReadLine();
            var frequency = message.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            var root = HuffmanTree(frequency);
            var huffmanCoding = new Dictionary<char, string>();
            HuffmanCoding(root, "", huffmanCoding);

            int variableWidthTable = frequency.Sum(kvp => huffmanCoding[kvp.Key].Length);
            int variableWidthCost = frequency.Sum(kvp => kvp.Value * huffmanCoding[kvp.Key].Length);

            Console.WriteLine("\nHuffman Codes:");
            foreach (var kvp in huffmanCoding)
                Console.WriteLine($"Character: {kvp.Key}, Code: {kvp.Value}");

            Console.WriteLine($"Table Cost: {variableWidthTable} Cost: {variableWidthCost}" );
        }
    }
}

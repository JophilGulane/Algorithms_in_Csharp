namespace HuffmanCoding_Practice1
{
    public class HuffmanCoding
    {
        public class Node
        {
            public Char Character;
            public int Frequency;
            public Node Left;
            public Node Right;
            public bool IsLeaf => Left == null && Right == null;
        }

        public static Node BuildHuffmanTree(Dictionary<char, int> frequencies)
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

                var Parent = new Node { Frequency = left.Frequency + right.Frequency, Left = left, Right = right };

                nodes.Remove(left);
                nodes.Remove(right);
                nodes.Add(Parent);
            }

            return nodes[0];
        }
        public static void GenerateHuffmanCodes(Node root, string currentCode, Dictionary<char, string> huffmanCodes)
        {
            if (root == null) return;
            if (root.IsLeaf)
            {
                huffmanCodes[root.Character] = currentCode;
            }
            GenerateHuffmanCodes(root.Left, currentCode + "0", huffmanCodes);
            GenerateHuffmanCodes(root.Right, currentCode + "1", huffmanCodes);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the message to compress: ");
            string message = Console.ReadLine();

            var frequencies = message.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            foreach (var kvp in frequencies)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value}");
            }

            int noCompression = message.Length * 8;

            int fixedCharCount = frequencies.Count;
            int fixedBitCount = (int)Math.Ceiling( Math.Log(fixedCharCount) / Math.Log(2));
            int fixedWidth = fixedCharCount * fixedBitCount;

            var root = BuildHuffmanTree(frequencies);
            var huffmanCodes = new Dictionary<char, string>();
            GenerateHuffmanCodes(root, "", huffmanCodes);

            Console.WriteLine("\nHuffman Coding:");
            foreach (var kvp in huffmanCodes)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value}");
            }
            int variableWidthCost = frequencies.Sum(kvp => kvp.Value * huffmanCodes[kvp.Key].Length);

            Console.WriteLine("Compression Cost: ");
            Console.WriteLine($"No Compression: {noCompression}");
            Console.WriteLine($"Fixed Width Compression: {fixedWidth}");
            Console.WriteLine($"Variable Width Compression: {variableWidthCost}");
        }
    }
}

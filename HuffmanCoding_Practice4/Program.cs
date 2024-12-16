namespace HuffmanCoding_Practice4
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
                var parent = new Node { Frequency = left.Frequency + right.Frequency, Left = left, Right = right };

                nodes.Remove(left);
                nodes.Remove(right);
                nodes.Add(parent);
            }

            return nodes[0];
        }

        public static void GenerateHuffmanCoding(Node root, string currentCode, Dictionary<char, string> huffmanCoding)
        {
            if (root == null) return;

            if (root.IsLeaf)
            {
                huffmanCoding[root.Character] = currentCode;
            }
            GenerateHuffmanCoding(root.Left, currentCode + "0", huffmanCoding);
            GenerateHuffmanCoding(root.Right, currentCode + "1", huffmanCoding);
        }

        public static void Main(string[] args)
        {
            string message = Console.ReadLine();
            var frequencies = message.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            var root = BuildHuffmanTree(frequencies);
            var huffmanCoding = new Dictionary<char, string>();
            GenerateHuffmanCoding(root, "", huffmanCoding);

            int variableWidthTable = frequencies.Sum(kvp => huffmanCoding[kvp.Key].Count());
            int variableWidthCost = frequencies.Sum(kvp => kvp.Value * huffmanCoding[kvp.Key].Count());

            int fixedCharCount = frequencies.Count();
            int fixedBitCount = (int)Math.Ceiling(Math.Log(fixedCharCount) / Math.Log(2));
            int fixedWidthTable = fixedCharCount * fixedBitCount;
            int fixedWidthCost = message.Length * fixedBitCount;

            Console.WriteLine(message.Length * 8);
            Console.WriteLine(fixedWidthCost + fixedWidthTable);
            Console.WriteLine(variableWidthCost + variableWidthTable);
            Console.WriteLine($"Variable Table Bits: {variableWidthTable}");
        }
    }
}

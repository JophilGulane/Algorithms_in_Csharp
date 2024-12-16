namespace HuffmanCoding_Practice2
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

        public static Node BuildHuffmanCoding(Dictionary<char, int> frequencies)
        {
            var nodes = new List<Node>();
            foreach (var kvp in frequencies)
            {
                nodes.Add(new Node { Character = kvp.Key, Frequency = kvp.Value });
            }

            while (nodes.Count > 1)
            {
                nodes = nodes.OrderBy(n => n.Frequency).ToList();

                var left = nodes[0];
                var right = nodes[1];

                var Parent = new Node
                {
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right,
                };

                nodes.Remove(left);
                nodes.Remove(right);
                nodes.Add(Parent);

            }
            return nodes[0];
        }

        public static void GenerateHuffmanCode(Node root, string currentNode, Dictionary<char, string> huffmanCodes)
        {
            if (root == null) return;

            if (root.IsLeaf)
            {
                huffmanCodes[root.Character] = currentNode;
            }
            GenerateHuffmanCode(root.Left, currentNode + "0", huffmanCodes);
            GenerateHuffmanCode(root.Right, currentNode + "1", huffmanCodes);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter String: ");
            string message = Console.ReadLine();

            var frequencies = message.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            var root = BuildHuffmanCoding(frequencies);
            var huffmanCodes = new Dictionary<char, string>();
            GenerateHuffmanCode(root, "", huffmanCodes);

            int variableWidthCost = frequencies.Sum(kvp => kvp.Value * huffmanCodes[kvp.Key].Length);
            Console.WriteLine(variableWidthCost);
        }
    }
}

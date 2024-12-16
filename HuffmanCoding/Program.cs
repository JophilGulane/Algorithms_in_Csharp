using System;
using System.Collections.Generic;
using System.Linq;

class HuffmanCoding
{
    // Node class for the Huffman Tree
    public class Node
    {
        public char Character { get; set; } 
        public int Frequency { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public bool IsLeaf => Left == null && Right == null;
    }

    // Builds the Huffman Tree
    public static Node BuildHuffmanTree(Dictionary<char, int> frequencies)
    {
        var nodes = new List<Node>();

        // Create a node for each character
        foreach (var kvp in frequencies)
            nodes.Add(new Node { Character = kvp.Key, Frequency = kvp.Value });

        // Build the tree
        while (nodes.Count > 1)
        {
            // Sort nodes by frequency
            nodes = nodes.OrderBy(n => n.Frequency).ToList();

            // Take the two smallest nodes
            var left = nodes[0];
            var right = nodes[1];

            // Create a parent node combining the two
            var parent = new Node
            {
                Frequency = left.Frequency + right.Frequency,
                Left = left,
                Right = right
            };

            // Remove the smallest nodes and add the parent
            nodes.Remove(left);
            nodes.Remove(right);
            nodes.Add(parent);
        }

        return nodes[0];
    }

    // Generate Huffman codes from the tree
    public static void GenerateHuffmanCodes(Node root, string currentCode, Dictionary<char, string> huffmanCodes)
    {
        if (root == null) return;

        if (root.IsLeaf)
            huffmanCodes[root.Character] = currentCode;

        GenerateHuffmanCodes(root.Left, currentCode + "0", huffmanCodes);
        GenerateHuffmanCodes(root.Right, currentCode + "1", huffmanCodes);
    }

    // Main program
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the message to compress:");
        string message = Console.ReadLine();

        // Count character frequencies
        var frequencies = message.GroupBy(c => c)
                                 .ToDictionary(g => g.Key, g => g.Count());

        Console.WriteLine("\nCharacter Frequencies:");
        foreach (var kvp in frequencies)
            Console.WriteLine($"Character: {kvp.Key}, Frequency: {kvp.Value}");

        // No Compression: 8 bits per character
        int noCompressionCost = message.Length * 8;

        // Fixed-width encoding: log2(number of unique characters), rounded up
        int uniqueCharCount = frequencies.Count;
        int fixedWidthBits = (int)Math.Ceiling(Math.Log2(uniqueCharCount));
        int fixedWidthCost = message.Length * fixedWidthBits;

        // Huffman Encoding
        var root = BuildHuffmanTree(frequencies);
        var huffmanCodes = new Dictionary<char, string>();
        GenerateHuffmanCodes(root, "", huffmanCodes);

        // Sort the Huffman codes, putting the space character last
        var sortedHuffmanCodes = huffmanCodes.OrderBy(kvp => kvp.Key == ' ' ? 1 : 0).ThenBy(kvp => kvp.Key).ToList();

        Console.WriteLine("\nHuffman Codes:");
        foreach (var kvp in sortedHuffmanCodes)
            Console.WriteLine($"Character: {kvp.Key}, Code: {kvp.Value}");

        // Calculate the Huffman cost
        int variableWidthCost = frequencies.Sum(kvp => kvp.Value * huffmanCodes[kvp.Key].Length);

        // Display Results
        Console.WriteLine("\nCompression Costs:");
        Console.WriteLine($"No Compression: {noCompressionCost} bits");
        Console.WriteLine($"Fixed-width Encoding: {fixedWidthCost} bits");
        Console.WriteLine($"Variable-width Encoding (Huffman Coding): {variableWidthCost} bits");
    }
}

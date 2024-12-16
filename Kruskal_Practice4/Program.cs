namespace Kruskal_Practice4
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Welcome to Kruskal's Algorithm Program!");

                // Input number of vertices
                Console.Write("Enter the number of vertices: ");
                int vertices = int.Parse(Console.ReadLine());
                Graph graph = new Graph(vertices);

                // Input number of edges
                Console.Write("Enter the number of edges: ");
                int edges = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter each edge in the format: source destination weight");
                for (int i = 0; i < edges; i++)
                {
                    Console.Write($"Edge {i + 1}: ");
                    string[] edgeInput = Console.ReadLine().Split(' ');
                    int source = int.Parse(edgeInput[0]);
                    int destination = int.Parse(edgeInput[1]);
                    int weight = int.Parse(edgeInput[2]);

                    graph.AddEdge(source, destination, weight);
                    
                }
                graph.Kruskal();
        }
    }

    public class Edge : IComparable<Edge>
    {
        public int Source;
        public int Destination;
        public int Weight;

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    public class Graph
    {
        private int Vertices;
        private List<Edge> Edges;

        public Graph(int vertices)
        {
            Vertices = vertices;
            Edges = new List<Edge>();


        }

        public void AddEdge(int source, int destination, int weight)
        {
            Edge edge = new Edge();
            edge.Source = source;
            edge.Destination = destination;
            edge.Weight = weight;
            Edges.Add(edge);   
        }

        public int FindParent(int[] parent, int vertex)
        {
            if (parent[vertex] != vertex)
            {
                parent[vertex] = FindParent(parent, parent[vertex]);
            }
            return parent[vertex];

        }

        public void Kruskal()
        {
            Edges.Sort();
            List<Edge> mst = new List<Edge>();
            int[] parent = new int[Vertices];

            for (int i = 0; i < Vertices; i++)
            {
                parent[i] = i;
            }

            foreach (var edge in Edges)
            {
                int sourceParent = FindParent(parent, edge.Source);
                int destinationParent = FindParent(parent, edge.Destination);

                if (sourceParent != destinationParent)
                {
                    mst.Add(edge);
                    parent[sourceParent] = destinationParent;
                }
            }

            int result = 0;
            foreach (var edge in mst)
            {
                Console.WriteLine($"{edge.Source} --> {edge.Destination} = {edge.Weight}");
                result += edge.Weight;
            }
            Console.WriteLine("Minimum Cost: " + result);
        }

    }
}

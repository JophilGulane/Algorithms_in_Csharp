namespace Kruskal_Practice7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Edge : IComparable<Edge> 
    {
        public int Source;
        public int Destination;
        public int Weight;

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }

    public class Graph
    {
        public int Vertices;
        public List<Edge> Edges;

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

            foreach (Edge edge in Edges)
            {
                int sourceParent = FindParent(parent, edge.Source);
                int destinationParent = FindParent(parent, edge.Destination);

                if (sourceParent != destinationParent)
                {
                    mst.Add(edge);
                    parent[sourceParent] = destinationParent;
                }

            }
        }
    }
}

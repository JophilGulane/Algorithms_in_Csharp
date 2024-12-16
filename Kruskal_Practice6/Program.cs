namespace Kruskal_Practice6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number of Vertices: ");
            int vertices = int.Parse(Console.ReadLine());

            Graph graph = new Graph(vertices);

            Console.WriteLine("Enter Number of Edges: ");
            int edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < edges; i++)
            {
                string[] inputEdges = Console.ReadLine().Split(' ');
                int source = int.Parse(inputEdges[0]);
                int destination = int.Parse(inputEdges[1]);
                int weight = int.Parse(inputEdges[2]);
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
        int Vertices;
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

            foreach(Edge edge in Edges)
            {
                int sourceParent = FindParent(parent, edge.Source);
                int destinationParent = FindParent(parent, edge.Destination);

                if(sourceParent != destinationParent)
                {
                    mst.Add(edge);
                    parent[sourceParent] = destinationParent;
                }
            }
            int result = 0;
            foreach (Edge edge in mst)
            {
                result += edge.Weight;  
            }
            Console.WriteLine(result);
        }
    }
}

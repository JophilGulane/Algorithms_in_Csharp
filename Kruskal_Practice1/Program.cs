namespace Kruskal_Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Hello, World!");
                Graph graph = new Graph(6);
                graph.AddEdge(0, 1, 2);
                graph.AddEdge(0, 4, 2);
                graph.AddEdge(1, 2, 3);
                graph.AddEdge(1, 4, 2);
                graph.AddEdge(2, 3, 1);
                graph.AddEdge(2, 5, 1);
                graph.AddEdge(3, 4, 3);
                graph.AddEdge(4, 5, 3);

                graph.KruskalAlgorithm();
        }

        public class Edge : IComparable<Edge>
        {
            public int Source;
            public int Destination;
            public int Weight;

            public int CompareTo(Edge other)
            {
                return this.Source.CompareTo(other.Source);
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

            private int FindParent(int[] parent, int vertex)
            {
                if (parent[vertex] != vertex)
                {
                    parent[vertex] = FindParent(parent, parent[vertex]);
                }
                return parent[vertex];
            }

            public void KruskalAlgorithm()
            {
                Edges.Sort();

                int[] parent = new int[Vertices];

                for(int i = 0; i < Vertices; i++)
                {
                    parent[i] = i;
                }

                List<Edge> mst = new List<Edge>();

                foreach(var edge in Edges)
                {
                    int sourceParent = FindParent(parent, edge.Source);
                    int destinationParent = FindParent(parent, edge.Destination);

                    if (sourceParent != destinationParent)
                    {
                        mst.Add(edge);
                        parent[sourceParent] = edge.Destination;
                    }
                }
                int result = 0;
                Console.WriteLine("MST: ");

                foreach(var edge in mst)
                {
                    result += edge.Weight;
                    Console.WriteLine($"{edge.Source} --> {edge.Destination} : {edge.Weight}");
                }
                Console.WriteLine(result);

            }
        }
    }
}

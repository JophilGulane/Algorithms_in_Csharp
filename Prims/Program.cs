namespace Prims
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prim's Algorithm:");
            Graph graph = new Graph(6);
            graph.AddEdge(0, 1, 2);
            graph.AddEdge(0, 4, 2);
            graph.AddEdge(1, 2, 3);
            graph.AddEdge(1, 4, 2);
            graph.AddEdge(2, 3, 1);
            graph.AddEdge(2, 5, 1);
            graph.AddEdge(3, 4, 3);
            graph.AddEdge(4, 5, 3);

            graph.PrimsAlgorithm();
        }
    }

    public class Graph
    {
        private int Vertices;
        private int[,] AdjacencyMatrix;

        public Graph(int vertices)
        {
            Vertices = vertices;
            AdjacencyMatrix = new int[vertices, vertices];
        }

        public void AddEdge(int source, int destination, int weight)
        {
            AdjacencyMatrix[source, destination] = weight;
            AdjacencyMatrix[destination, source] = weight;
        }

        public int MinKey(int[] key, bool[] visited)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < Vertices; v++)
            {
                if (!visited[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

        public void PrimsAlgorithm()
        {
            bool[] visited = new bool[Vertices];
            int[] minEdge = new int[Vertices];
            int[] parent = new int[Vertices];
            int totalWeight = 0;

            for (int i = 0; i < Vertices; i++)
            {
                minEdge[i] = int.MaxValue;
                parent[i] = -1;
            }

            minEdge[0] = 0;

            for (int i = 0; i < Vertices - 1; i++)
            {
                int u = MinKey(minEdge, visited);
                visited[u] = true;

                for (int v = 0; v < Vertices; v++)
                {
                    if (!visited[v] && AdjacencyMatrix[u, v] != 0 && AdjacencyMatrix[u, v] < minEdge[v])
                    {
                        minEdge[v] = AdjacencyMatrix[u, v];
                        parent[v] = u;
                    }
                }

            }

            Console.WriteLine("Edge   Weight");
            for (int i = 1; i < Vertices; i++)
            {
                Console.WriteLine($"{parent[i]} --> {i} : {AdjacencyMatrix[i, parent[i]]}");
                totalWeight += AdjacencyMatrix[i, parent[i]];
            }
            Console.WriteLine($"Total Weight of MST: {totalWeight}");
        }
    }
}

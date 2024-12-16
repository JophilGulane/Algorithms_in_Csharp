namespace BFS_Practice1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(6); // Create a graph with 6 vertices (1-6)

            // Add edges based on the graph in the image
            graph.AddEdge(0, 4);
            graph.AddEdge(0, 5);
            graph.AddEdge(1, 4);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 0);
            graph.AddEdge(3, 2);
            graph.AddEdge(4, 2);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(5, 4);
            graph.AddEdge(5, 0);
            graph.AddEdge(5, 1);  // Self loop on vertex 5

            Console.WriteLine("Starting Breadth-First Search from vertex 1:");
            graph.BFS(2); // Start BFS from vertex 1
        }
    }

    public class Graph
    {
        private int Vertices;
        private List<int>[] AdjacentList;

        public Graph(int vertices)
        {
            Vertices = vertices;
            AdjacentList = new List<int>[Vertices]; // +1 for 1-based indexing

            // Initialize the adjacency list for each vertex (1-based index)
            for (int i = 0; i < Vertices; i++)
            {
                AdjacentList[i] = new List<int>();
            }
        }

        // Add edge to the graph
        public void AddEdge(int v, int w)
        {
            AdjacentList[v].Add(w); // Add w to v's adjacency list
        }

        // Perform BFS traversal
        public void BFS(int startVertex)
        {
            bool[] visited = new bool[Vertices]; // +1 for 1-based indexing
            Queue<int> queue = new Queue<int>();

            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            Console.WriteLine("BFS TRAVERSAL: ");

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                Console.Write(vertex + " ");

                foreach (var adjV in AdjacentList[vertex])
                {
                    if (!visited[adjV])
                    {
                        visited[adjV] = true;
                        queue.Enqueue(adjV);
                    }
                }
            }
        }
    }
}

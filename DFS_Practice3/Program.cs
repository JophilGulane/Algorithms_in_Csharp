namespace DFS_Practice3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int n = int.Parse(Console.ReadLine());

            Graph graph = new Graph(n);

            while(true)
            {
                Console.WriteLine($"Enter Source and Destination (ex. 1, 3) type 'done' if done inputting all edges");
                string[] edge = Console.ReadLine().Split(',');

                if (edge[0].ToLower() == "done") { break; }

                int source = int.Parse(edge[0]);
                int destination= int.Parse(edge[1]);
                graph.AddEdge(source, destination);
            }

            graph.DFS(2);
        }
    }

    public class Graph
    {
        public int Vertices;
        public List<int>[] AdjacentList;

        public Graph(int vertices)
        {
            Vertices = vertices;
            AdjacentList = new List<int>[Vertices];

            for (int i = 0; i < Vertices; i++)
            {
                AdjacentList[i] = new List<int>();
            }
        }

        public void AddEdge(int source, int destination)
        {
            AdjacentList[source].Add(destination);
        }

        public void DFS(int startingVertex)
        {
            bool[] visited = new bool[Vertices];
            Stack<int> stack = new Stack<int>();

            visited[startingVertex] = true;
            stack.Push(startingVertex);

            while (stack.Count > 0)
            {
                int vertex = stack.Pop();

                if (visited[vertex] == false)
                {
                    Console.Write($"{vertex} ");
                    visited[vertex] = true;
                }

                foreach (var adjVertex in AdjacentList[vertex])
                {
                    if (visited[adjVertex] == false)
                    {
                        stack.Push(adjVertex);
                    }
                }
            }
        }
    }
}

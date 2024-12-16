namespace DFS_Practice1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Please Enter number of Vertices in the Graph: ");
            int vertices = int.Parse(Console.ReadLine());
            Graph graph = new Graph(vertices);

            while (true)
            {
                Console.WriteLine("Enter Source and Destination: ex(0,1)");

                string[] userInput = Console.ReadLine().Split(','); ;
                if (userInput[0].ToLower() == "done")
                {
                    break;
                }

                int source = int.Parse(userInput[0]);
                int destination = int.Parse(userInput[1]);
                graph.AddEdge(source, destination);
            }

            Console.WriteLine("Where do you want to start traversing: ");
            int traverse = int.Parse(Console.ReadLine());

            Console.WriteLine($"Starting Breadth-First Search from vertex {traverse}:");
            graph.DFS(traverse);
        }
    }

    class Graph
    {
        int Vertices;
        List<int>[] AdjacentList;

        public Graph(int vertices)
        {
            Vertices = vertices;
            AdjacentList = new List<int>[Vertices];

            for (int i = 0; i < Vertices; i++)
            {
                AdjacentList[i] = new List<int> ();
            }
        }

        public void AddEdge(int source, int destination)
        {
            AdjacentList[source].Add (destination);
        }

        public void DFS(int startVertex)
        {
            bool[] visited = new bool[Vertices];
            Stack<int> stack = new Stack<int>();


            visited[startVertex] = true;
            stack.Push(startVertex);

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
                    if(visited[adjVertex] == false)
                    {
                        stack.Push(adjVertex);
                    }
                }
            }
        }
    }
}

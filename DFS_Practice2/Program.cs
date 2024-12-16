namespace DFS_Practice2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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
                AdjacentList[i] = new List<int>();
            }

        }

        public void AddEdge(int source, int destination)
        {
            AdjacentList[source].Add(destination);
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
                    if (visited[adjVertex] == false)
                    {
                        stack.Push(adjVertex);
                    }

                }
            }
        }
    }
}

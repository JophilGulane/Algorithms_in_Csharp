using System;
using System.Collections.Generic;


namespace BFS
{
    class Graph
    {
        private int _vertices; // Number of vertices
        private List<int>[] _adjacencyList; // Adjacency list

        public Graph(int vertices)
        {
            _vertices = vertices;
            _adjacencyList = new List<int>[vertices];

            for (int i = 0; i < vertices; i++)
            {
                _adjacencyList[i] = new List<int>();
            }
        }

        // Add edge to the graph
        public void AddEdge(int v, int w)
        {
            _adjacencyList[v].Add(w); // Add w to v's list
        }

        // Perform BFS traversal
        public void BFS(int startVertex)
        {
            bool[] visited = new bool[_vertices]; // Track visited vertices
            Queue<int> queue = new Queue<int>();

            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            Console.WriteLine("BFS Traversal:");

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                Console.Write(vertex + " ");

                foreach (var adjacentVertex in _adjacencyList[vertex])
                {
                    if (!visited[adjacentVertex])
                    {
                        visited[adjacentVertex] = true;
                        queue.Enqueue(adjacentVertex);
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(6); // Create a graph with 6 vertices (0-5)

            // Add edges based on the graph in the image
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 4);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 2);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(4, 2);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 1);
            graph.AddEdge(5, 4);

            Console.WriteLine("Starting Breadth-First Search from vertex 2:");
            graph.BFS(3);
        }
    }

}

using System;
using System.Collections.Generic;


namespace DFS
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

        // Perform DFS traversal
        public void DFS(int startVertex)
        {
            bool[] visited = new bool[_vertices]; // Track visited vertices
            Stack<int> stack = new Stack<int>();

            stack.Push(startVertex);

            Console.WriteLine("DFS Traversal:");
            while (stack.Count > 0)
            {
                int vertex = stack.Pop();

                if (!visited[vertex])
                {
                    Console.Write(vertex + " ");
                    visited[vertex] = true;
                }

                foreach (var adjacentVertex in _adjacencyList[vertex])
                {
                    if (!visited[adjacentVertex])
                    {
                        stack.Push(adjacentVertex);
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(6); // Example graph with 6 vertices (0-5)

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 5);

            Console.WriteLine("Starting Depth-First Search from vertex 0:");
            graph.DFS(0);
        }
    }

}

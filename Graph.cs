using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Create a Graph class that takes edges and makes an adjacency list.
// Include BFS and DFS code.
// Make sure the vertices are zero based indexed.

namespace Algorithms
    {
    public class Graph
        {
        // Adjacency list
        public List< List<int> > adjList;
        // Number of vertices
        public int V = 0;
        private List<bool> DFSvisited;
        
        // Constructor
        public Graph(int numOfVertices)
            {
            // Set the vertex count
            V = numOfVertices;



            // Initialize adjList
            adjList = new List< List<int> >();
            for(int i = 0; i < numOfVertices; i++)
                {
                adjList.Add(new List<int>());
                }
            }

        // Add a directed to the adjacency list.
        public void AddDirectedEdge(int point1, int point2)
            {
            adjList[point1].Add(point2);
            }
        
        // Add an undirected edge to the adjacency list.
        public void AddUndirectedEdge(int point1, int point2)
            {
            adjList[point1].Add(point2);
            adjList[point2].Add(point1);
            }
        
        // Breadth First Search
        // Source is the node we start with.
        public void BFS(int source)
            {
            // Make an array for if we visited a node or not.
            List<bool> BFSvisited = new List<bool>();
            for(int i = 0; i < V; i++)
                {
                BFSvisited.Add(false);
                }

            // Create a queue for the nodes we have to visit.
            //Queue<int> queue = new Queue<int>();
            System.Collections.Generic.Queue<int> queue = new System.Collections.Generic.Queue<int>();
            
            // Mark the source as visited and add it to the queue.
            BFSvisited[source] = true;
            queue.Enqueue(source);

            // While the queue isn't empty, find all neighbors.
            while(queue.Count > 0)
            //while(queue.IsEmpty() == false)
                {
                // Get the current vertex and dequeue it.
                int currentVertex = queue.Dequeue();

                // Output current vertex to console.
                Console.Write($"{currentVertex} ");

                // Go through all the neighbors of the current vertex
                for(int i = 0; i < adjList[currentVertex].Count; i++) // Go through all the nodes in the adjacency list at that index.
                    {
                    // The neighbor.
                    int neighbor = adjList[currentVertex][i];

                    // If this neighbor wasn't visited, add it to the queue and mark it as visited
                    if(BFSvisited[neighbor] == false)
                        {
                        queue.Enqueue(neighbor);
                        BFSvisited[neighbor] = true;
                        }
                    } // End of for-loop checking neighbors
                }   // End of while-loop for queue.
            } // End of method BFS
        
        // Depth First Search Helper
        // 
        public void DFS_Helper(int vertex)
            {
            // Mark the current vertex as visited
            DFSvisited[vertex] = true;

            // Output it to console.
            Console.Write($"{vertex} ");

            // Recursively call DFS on all neighbors that haven't been visited yet.
            for(int i = 0; i < adjList[vertex].Count; i++) // Goes through all neighbors of this vertex in the adjacency list.
                {
                // The neighbor
                int neighbor = adjList[vertex][i];

                // If it wasn't visited
                if(DFSvisited[neighbor] == false)
                    {
                    // Recursively call it.
                    DFS_Helper(neighbor);
                    }
                }

            }

        // Depth First Search
        public void DFS(int source)
            {
            // Initialize the visited array
            DFSvisited = new List<bool>();
            for(int i = 0; i < V; i++)
                { DFSvisited.Add(false); }

            // Call the Helper function on our source.
            DFS_Helper(source);
            }
        }
    }

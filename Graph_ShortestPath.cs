using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This class is a graph class that finds the shortest path.
// It's implemented using an adjacency list. 
// There are two shortest path algorithms:
// Dijkstra (for no negative weights) 
// Bellman Ford (for negative weights, but no negative cycles)

namespace Algorithms
    {
    // A class to hold a node
    // Used when user it constructing the graph with it's edges.
    public class WeightedEdge
        {
        public int vertex1;
        public int vertex2;
        public int weight;

        public WeightedEdge(int vertex1, int vertex2, int weight)
            {
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
            this.weight = weight;
            }
        }

    // A node. Points to a vertex and has a weight for that edge.
    // Used internally in this file, only. User doesn't see this.
    // Specifically, it's used to represent nodes in our adjacency list.
    public class Node
        {
        public int vertex;
        public int weight;

        public Node(int vertex, int weight)
            {
            this.vertex = vertex;
            this.weight = weight;
            }
        }

    // Shortest path node. Has a parent that it came from and the distance from s.
    // This is the return type when the user calls Dijkstra. 
    // Used in maintaining the shortest path list. 
    public class SPNode
        { 
        public int parentVertex;
        public int distanceFromSource;

        public SPNode(int distanceFromSource, int parentVertex)
            {
            this.parentVertex = parentVertex;
            this.distanceFromSource = distanceFromSource;
            }
        }

    public class Graph_ShortestPath
        {
        // Create adjacency list and number of vertices
        protected List< List<Node> > adjList;
        protected int V;
        protected int maxedgeweight;

        // Constructor.
        public Graph_ShortestPath(int VertexCount)
            {
            // Initialize the adjacency list
            adjList = new List<List<Node>>();
            for(int i = 0; i < VertexCount; i++)
                {
                adjList.Add(new List<Node>());
                }

            // Initialize vertex count
            V = VertexCount;

            // Initialize max edge weight so we know what to set infinity too.
            maxedgeweight = -1;
            }
        
        public void AddWeightedDirectedEdge(WeightedEdge edge)
            {
            int vertex1 = edge.vertex1;
            int vertex2 = edge.vertex2;
            int weight = edge.weight;

            adjList[vertex1].Add(new Node(vertex2, weight));

            if(weight > maxedgeweight) { maxedgeweight = weight; }
            }

        public void AddWeightedUndirectedEdge(WeightedEdge edge)
            { 
            int vertex1 = edge.vertex1;
            int vertex2 = edge.vertex2;
            int weight = edge.weight;

            adjList[vertex1].Add(new Node(vertex2, weight));
            adjList[vertex2].Add(new Node(vertex1, weight));

            if(weight > maxedgeweight) { maxedgeweight = weight; }
            }

        // Input is the source vertex. 
        public List<SPNode> Dijkstra(int sourceVertex)
            {
            // This list holds the shortest path from sourceVertex to each other vertex.
            List<SPNode> shortestPathList = new List<SPNode>();
            // This is the set of vertices that we definitely know we can't get to any shorter
            bool[] shortestPathProcessed = new bool[V];

            // Initialize the vertex to 0, other vertices to infinity, and shortestpathset to false
            for(int i = 0; i < V; i++)
                {
                shortestPathList.Add(new SPNode(Int32.MaxValue, -1));
                shortestPathProcessed[i] = false;
                }

            // Set the source vertex's distance to 0.
            shortestPathList[sourceVertex].distanceFromSource = 0;

            // Go through each vertex left.
            for(int z = 0; z < V - 1; z++)
                {
                // NOTE: We could add a break condition if the target vertex is in the shortestPathSet
                
                /* CHOOSE VERTEX TO RELAX */
                int min = Int32.MaxValue; // The distance of that vertex
                int u = Int32.MaxValue; // The vertex index we're going to relax.
                
                // Look in the shortestPathSet and find the vertex with the shortest distance that hasn't yet been processed.
                for(int i = 0; i < V; i++)
                    {
                    if(shortestPathProcessed[i] == false) // Vertex wasn't processed yet.
                        { 
                        if(shortestPathList[i].distanceFromSource < min) // It's the min distance
                            {
                            // Update the best vertex to relax
                            u = i;
                            min = shortestPathList[i].distanceFromSource;
                            }
                        }
                    }

                /* RELAX THE CHOSEN VERTEX */
                // Mark our chosen vertex as visited.
                shortestPathProcessed[u] = true;
                //Console.WriteLine($"Processing node {u}. Distance from source is {shortestPathList[u].distanceFromSource}");

                // Update the distance values of the adjacent vertices.
                for(int i = 0; i < adjList[u].Count; i++)
                    {
                    // Store the Node into a variable we can play with for now.
                    Node node = adjList[u][i];

                    // Make sure this node isn't in the processed set.
                    if(shortestPathProcessed[node.vertex] == true) { continue; }

                    // If the path from u to node is smaller than the node's current distance value...
                    if(shortestPathList[u].distanceFromSource + node.weight <= shortestPathList[node.vertex].distanceFromSource)
                        {
                        //Console.Write($"Relaxing neighbor of {u}: vertex {node.vertex} that has distance {shortestPathList[node.vertex].distanceFromSource}. ");
                        //Console.WriteLine($"New distance is {shortestPathList[u].distanceFromSource + node.weight}");

                        // Update the distancefromsource to the better one.
                        shortestPathList[node.vertex].distanceFromSource = shortestPathList[u].distanceFromSource + node.weight;
                        // Update the parent pointer.
                        shortestPathList[node.vertex].parentVertex = u;
                        }

                    }

                }

            return shortestPathList;
            }

        }
    }

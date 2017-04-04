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
            } // End of Dijkstra

        // Bellman ford algorithm.
        public List<SPNode> BellmanFord(int sourceVertex)
            { 
            // This list holds the shortest path from sourceVertex to each other vertex.
            List<SPNode> shortestPathList = new List<SPNode>();

            // Initialize all distances to infinity.
            for(int i = 0; i < V; i++)
                {
                shortestPathList.Add(new SPNode(Int32.MaxValue, -1));
                }

            // Set the distance for the source to 0.
            shortestPathList[sourceVertex].distanceFromSource = 0;

            // Relax all edges v - 1 times. 
            for(int i = 0; i < V-1; i++) // V-1 times
                { 
                for(int j = 0; j < V; j++) // Each vertex
                    {
                    int u = j;

                    // If distance is infinity then don't relax. There can't be a shortest path.
                    if(shortestPathList[u].distanceFromSource == Int32.MaxValue)
                        { continue; }

                    for(int k = 0; k < adjList[j].Count; k++) // Each edge in the adjacency list for this vertex
                        {
                        int v = adjList[j][k].vertex;
                        int weight = adjList[j][k].weight;

                        if(shortestPathList[u].distanceFromSource + weight < shortestPathList[v].distanceFromSource)
                            { 
                            // Update distance
                            shortestPathList[v].distanceFromSource = shortestPathList[u].distanceFromSource + weight;
                            // Update parent
                            shortestPathList[v].parentVertex = u;
                            }

                        }
                    }
                }
            

            // Do the check for negative weight cycles.
            for(int j = 0; j < V; j++) // Each vertex
                {
                int u = j;

                // If distance is infinity then don't relax. There can't be a shortest path.
                if(shortestPathList[u].distanceFromSource == Int32.MaxValue)
                   { continue; }

                for(int k = 0; k < adjList[j].Count; k++) // Each edge in the adjacency list for this vertex
                    {
                    int v = adjList[j][k].vertex;
                    int weight = adjList[j][k].weight;
                    
                    if(shortestPathList[u].distanceFromSource + weight < shortestPathList[v].distanceFromSource)
                        { shortestPathList[v].distanceFromSource = Int32.MaxValue; }
                    }
                }        

            return shortestPathList;
            } // End of method BellmanFord


        // Floyd Warshall Algorithm
        // Returns a matrix of the shortest distance from vertex to vertex
        public int[,] FloydWarshall()
            {
            /* INITIALIZE */
            // Our shortest path matrix.
            int[,] spMatrix = new int[V,V];

            // Initialize every shortest path to infinity
            for(int i = 0; i < V; i++)
                { 
                for(int j = 0; j < V; j++)
                    {
                    spMatrix[i, j] = Int32.MaxValue;
                    }
                }

            // Set each source as 0 distance to itself
            for(int i = 0; i < V; i++)
                {
                spMatrix[i, i] = 0;
                }

            // Set the edges as they should be based on the adjacency list.
            for(int i = 0; i < V; i++)
                { 
                for(int j = 0; j < adjList[i].Count; j++)
                    {

                    spMatrix[i, adjList[i][j].vertex ] = adjList[i][j].weight;
                    }
                }

            // Debug - output matrix
            //Console.WriteLine("Debug Floyd Warshall");
            //for(int i = 0; i < V; i++) { for(int j = 0; j < V; j++) { Console.Write($"{spMatrix[i, j]} "); } Console.WriteLine(); }

            /* FIND SHORTEST PATHS */
            for(int k = 0; k < V; k++)
                { 
                for(int i = 0; i < V; i++)
                    { 
                    for(int j = 0; j < V; j++)
                        { 
                        // Don't do anything if either value is infinity. It'll go over int32.maxvalue so the if statement will throw bad results
                        if(spMatrix[i,k] == Int32.MaxValue || spMatrix[k,j] == Int32.MaxValue)
                            { continue; }

                        if(spMatrix[i,k] + spMatrix[k,j] < spMatrix[i,j])
                            {
                            spMatrix[i,j] = spMatrix[i,k] + spMatrix[k,j];
                            }
                        }
                    }
                }


            return spMatrix;
            }

        } // End of class Graph_ShortestPath
    } // End of namespace 

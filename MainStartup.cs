using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
This project will expand the namespace "Algorithms". 
We'll write code for all of our useful algorithms in this project.
Specifically, we'll write the algorithms used in Coursera's Algorithms course by Princeton.
*/

namespace Algorithms
    {
    // Class only holds Main, used to test algorithms we write.
    class MainStartup
        {
        static void Main()
            {
            // Testing Graph_ShortestPath
            // See http://www.geeksforgeeks.org/greedy-algorithms-set-6-dijkstras-shortest-path-algorithm/ for images used in this test

            // Instantiate
            int v = 9;
            Graph_ShortestPath gsp = new Graph_ShortestPath(v);

            // Add edges to the graph. 
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 0, 1, 4));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 0, 7, 8));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 1, 7, 11));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 1, 2, 8));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 7, 6, 1));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 7, 8, 7));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 2, 8, 2));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 8, 6, 6));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 6, 5, 2));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 2, 3, 7));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 2, 5, 4));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 3, 5, 14));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 3, 4, 9));
            gsp.AddWeightedUndirectedEdge(new WeightedEdge( 5, 4, 10));

            // Call Dijkstra and store it in a list.
            int source = 0;
            List<SPNode> spList = new List<SPNode>();
            spList.AddRange(gsp.Dijkstra(source));

            // Output the results from source to each of the edges.
            for(int i = 0; i < v; i++)
                {
                Console.WriteLine($"Distance from {source} to {i} is {spList[i].distanceFromSource}. Parent is {spList[i].parentVertex}.");
                }

            } // End of Main.
        } // End of class MainStartup
    } // End of namespace Algorithms
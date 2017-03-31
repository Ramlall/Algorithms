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
            // Test Graph class

            // Add edges.
            Graph graph = new Graph(4);
            graph.AddDirectedEdge(0, 1);
            graph.AddDirectedEdge(0, 2);
            graph.AddDirectedEdge(1, 2);
            graph.AddDirectedEdge(2, 0);
            graph.AddDirectedEdge(2, 3);
            graph.AddDirectedEdge(3, 3);

            // BFS
            int source = 2;
            Console.WriteLine($"The answer if we BFS starting at node {source} is: ");
            graph.BFS(source);

            // DFS

            } // End of Main.
        } // End of class MainStartup
    } // End of namespace Algorithms
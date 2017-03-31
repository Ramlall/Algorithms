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
        static void Help()
            {
            // Add edges.
            Graph graph = new Graph(10);
            graph.AddUndirectedEdge(1, 3);
            graph.AddUndirectedEdge(3, 9);
            graph.AddUndirectedEdge(2, 9);
            graph.AddUndirectedEdge(2, 5);
            graph.AddUndirectedEdge(9, 6);
            graph.AddUndirectedEdge(7, 8);
            graph.AddUndirectedEdge(8, 9);
            graph.AddUndirectedEdge(1, 7);
            

            Console.Write($"\nSource: ");
            int source = Int32.Parse(Console.ReadLine());

            
            // BFS
            Console.Write($"The answer if we BFS starting at node {source} is: ");
            graph.BFS(source);
            Console.WriteLine();

            // DFS
            Console.Write($"The answer if we DFS starting at node {source} is: ");
            graph.DFS(source);
            Console.WriteLine();
            }

        static void Main()
            {
            // Test Graph class
            for(;;)
                { Help(); }
            } // End of Main.
        } // End of class MainStartup
    } // End of namespace Algorithms
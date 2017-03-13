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
            // Initialize a stack and queue.
            Algorithms.Queue<int> queue = new Queue<int>();
            Algorithms.Stack<int> stack = new Stack<int>();

            // Add 0-20
            for(int i = 0; i <= 20; i++)
                {
                queue.Enqueue(i);
                stack.Push(i);
                }

            // Use a foreach loop to output it
            Console.Write($"Queue contains: ");
            foreach(int item in queue)
                { Console.Write($"{item} "); }
            
            Console.Write($"Stack contains: ");
            foreach(int item in stack)
                { Console.Write($"{item} "); }

            } // End of Main.
        } // End of class MainStartup
    } // End of namespace Algorithms
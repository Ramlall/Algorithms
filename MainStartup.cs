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
            // Test Stacks and Queues.
            Algorithms.Queue<int> queue = new Queue<int>();
            Algorithms.Stack<int> stack = new Stack<int>();

            Console.WriteLine($"The size of the queue is {queue.size}.");
            Console.WriteLine($"The size of the stack is {stack.size}.");

            // Put 1-5 into the structures.
            for(int i = 1; i <= 5; i++)
                {
                queue.Enqueue(i);
                Console.WriteLine($"Added {i} to queue.");
                stack.Push(i);
                Console.WriteLine($"Added {i} to stack.");
                }

            Console.WriteLine($"The size of the queue is {queue.size}.");
            Console.WriteLine($"The size of the stack is {stack.size}.");

            // Remove two.
            for(int i = 0; i < 2; i++)
                {
                int x, y;
                x = queue.Dequeue();
                y = stack.Pop();
                Console.WriteLine($"Dequeued {x}.");
                Console.WriteLine($"Popped {y}.");
                }

            // Put 6-9 into the structures.
            for(int i = 6; i <= 9; i++)
                {
                queue.Enqueue(i);
                Console.WriteLine($"Added {i} to queue.");
                stack.Push(i);
                Console.WriteLine($"Added {i} to stack.");
                }

            Console.WriteLine($"The size of the queue is {queue.size}.");
            Console.WriteLine($"The size of the stack is {stack.size}.");

            // Remove all.
            int length = queue.size;
            for(int i = 0; i < length; i++)
                {
                int x;
                x = queue.Dequeue();
                Console.WriteLine($"Dequeued {x}.");
                }

            length = stack.size;
            for(int i = 0; i < length; i++)
                {
                int y;
                y = stack.Pop();
                Console.WriteLine($"Popped {y}.");
                }

            } // End of Main.
        } // End of class MainStartup
    } // End of namespace Algorithms
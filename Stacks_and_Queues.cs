using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
This file contains our own implementations of the data structure Stack and Queue.

Stack has the operations:
Push
Pop 
Size
IsEmpty

Queue has the operations:
Enqueue
Dequeue
Size

These data structures will be implemented generically.

Additionally, they will be able to be enumerated using a foreach loop by the client.

There are two implementations of Stack and Queue: 
1. Using a linked list.
2. Using a resizeable array (double if we hit the max, half if we hit under a quarter).

The resizeable array will be one that gets accessed by default if we call of Algorithms.Stack or Algorithms.Queue class.

Source: https://d18ky98rnyall9.cloudfront.net/_3293220668bef735d367a188452c32dc_13StacksAndQueues.pdf?Expires=1489276800&Signature=UcIfs47SYYBFMwjiQjFVcXwWzuQaPAixF0uLMh9UwrMO1xy0zl96eQfJRkrqlMyLu4Q9AV0Rty7W4ODE5E2sA--ziWPf8dP2p7uaEt6UZA1RFQ5DZKAB9CGy4hjyACwQXOJgXG2CTBNMr2vKOTCPVegtW9VKem2Q0eSEqifK-1g_&Key-Pair-Id=APKAJLTNE6QMUY6HBC5A
*/

namespace Algorithms
    {
    //////////////////////////////////////////////////////////////
    // Stack Code
    //////////////////////////////////////////////////////////////

    public class LinkedListStack<T>
        {
        // A Node holds the data and the next item in the list.
        private class Node
            {
            public T item;
            public Node next;

            public Node(T item, Node next)
                {
                this.item = item;
                this.next = next;
                }
            }

        // Pointer to the first node. Starts out as null.
        private Node first = null;
        
        // The size of the stack is initiallize zero.
        public int size { get; private set; }

        public LinkedListStack()
            {
            size = 0;
            }

        // Is the Stack empty?
        public bool IsEmpty()
            {
            return first == null;
            }
        
        // Push an item onto the stack.
        public void Push(T item)
            {
            Node oldfirst = first;
            first = new Node(item, oldfirst);
            }

        // Pop an item from the top of the stack.
        public T Pop()
            {
            T item = first.item;
            first = first.next;
            return item;
            }
        }   // End of class LinkedListStack

    public class ResizeableArrayStack<T>
        {
        // An array holding all of our items on the stack.
        private T[] stackArray;
        // The number of items in our stack.
        public int size { get; private set; }
        
        // Constructor to initialize our array.
        public ResizeableArrayStack()
            {
            stackArray = new T[1];
            size = 0;
            }

        // Is the stack empty?
        public bool IsEmpty()
            {
            return size == 0;
            }

        // Helper function to resize our stackArray of items.
        private void Resize(int capacity)
            {
            // Create a new array that we'll copy the old values into.
            T[] copy = new T[capacity];
            // Copy the values
            for(int i = 0; i < size; i++)
                { copy[i] = stackArray[i]; }
            // Now make our stackArray point to this copy.
            stackArray = copy;
            }

        // Push an item onto the stack.
        public void Push(T item)
            {
            // Resize if we hit the limit
            if(size == stackArray.Length) 
                {
                Resize(2 * stackArray.Length);
                }
            // Increment size for our new item, and in that array index put the item.
            stackArray[size++] = item;
            }

        // Pop an item from the top of the stack and return it.
        public T Pop()
            {
            // Get the top item and then decrement size.
            T item = stackArray[--size];
            // Set the array spot at that index to null.
            stackArray[size] = default(T);
            // Resize the array if necessary.
            if(size > 0 && size == stackArray.Length/4)
                { Resize(stackArray.Length / 2); }
            // Return the item to the client.
            return item;
            }

        // An enumerator so we can use a foreach loop with this stack.
        public System.Collections.IEnumerator GetEnumerator()
            {
            for(int i = 0; i < size; i++)
                {
                yield return stackArray[i];
                }
            }
        }   // End of class ResizeableArrayStack


    // Our real stack class that client will call by default.
    public class Stack<T> : ResizeableArrayStack<T>
        {
        // Inherits from ResizeableArray so don't need to do anything here.
        }

    //////////////////////////////////////////////////////////////
    // End of Stack Part.
    //////////////////////////////////////////////////////////////


    //////////////////////////////////////////////////////////////
    // Queue
    //////////////////////////////////////////////////////////////
    public class LinkedListQueue<T>
        {
        // A Node holds the data and the next item in the list.
        private class Node
            {
            public T item;
            public Node next;

            public Node(T item, Node next)
                {
                this.item = item;
                this.next = next;
                }
            }

        // Pointer to the first node. Starts out as null.
        private Node first = null;
        
        // Pointer to the last node. Starts out null.
        private Node last = null;
        
        // The size of the queue is initiallize zero.
        public int size { get; private set; }

        public LinkedListQueue()
            {
            size = 0;
            }

        // Is the Queue empty?
        public bool IsEmpty()
            {
            return first == null;
            }
        
        // Put an item into the queue
        public void Enqueue(T item)
            {
            // See the source page 31 for a pic on how this actually works.
            Node oldlast = last;
            last = new Node(item, null);
            if(IsEmpty() == true) { first = last; } // Special case for empty queue.
            else { oldlast.next = last; }           // Set up the new pointer.
            size += 1;
            }

        // Remove the first item from the queue.
        public T Dequeue()
            {
            T item = first.item;
            first = first.next;
            if(IsEmpty() == true) { last = null; } // Special case for empty queue.
            size -= 1;
            return item;
            }
        }   // End of class LinkedListQueue


    public class ResizeableArrayQueue<T>
        {
        // An array holding all of our items on the queue.
        private T[] queueArray;
        // The number of items in our queue.
        public int size { get; private set; }
        // The locations of the first and last items in the queue. (Indices in queueArray)
        private int head = 0, tail = 0;
        
        // Constructor to initialize our array.
        public ResizeableArrayQueue()
            {
            queueArray = new T[1];
            size = 0;
            }

        // Is the stack empty?
        public bool IsEmpty()
            {
            return size == 0;
            }

        // Helper function to resize our queueArray of items.
        private void Resize()
            {
            // Get the capacity based on log2 of the size of the array.
            double log2num = Math.Log(size + 1, 2);
            double roundedup = Math.Ceiling(log2num);
            int capacity = Convert.ToInt32(Math.Pow(2, roundedup));

            if(size == 1)
                { capacity = 2; tail = 1; }

            //Console.Write("$queueArray: "); for(int i = 0; i < queueArray.Length; i++) { Console.Write($"{queueArray[i]} "); } Console.WriteLine();
            //Console.WriteLine($"QueueArray resized to {capacity}");

            // Create a new array that we'll copy the old values into.
            T[] copy = new T[capacity];
            
            // Copy the values.
            for(int i = 0; i < size; i++)
                { copy[i] = queueArray[head + i]; }

            // Now make our queueArray point to this copy.
            queueArray = copy;
            
            //Console.Write("$queueArray: "); for(int i = 0; i < queueArray.Length; i++) { Console.Write($"{queueArray[i]} "); } Console.WriteLine();
            
            // Update head and tail.
            head = 0;
            tail = size - 1;
            }

        // Put an item into the queue.
        public void Enqueue(T item)
            {
            // Resize if we hit the limit
            if(size > 0 && (tail + 1 >= queueArray.Length))
                {
                Resize();
                }

            // Add the item to the new spot.
            if(size == 0) { queueArray[0] = item; tail = 0; }   // First item we add at first index.
            else { tail += 1; queueArray[tail] = item; }        // After the first item, update the tail to it's new spot and then add the item there.

            // Update the size.
            size += 1;
            }

        // Pop an item from the top of the stack and return it.
        public T Dequeue()
            {
            // Get the item from the head.
            T item = queueArray[head];
            // Decrement the size.
            size -= 1;
            // Set the spot at that index to null.
            queueArray[head] = default(T);
            // Update head's index
            head += 1;

            // Resize the array if necessary.
            if(size > 0 && size == queueArray.Length/4)
                {
                Resize(); 
                }
            
            // Return the item to the client.
            return item;
            }
        
        // An enumerator so we can use a foreach loop with this queue.
        public System.Collections.IEnumerator GetEnumerator()
            {
            for(int i = 0; i < size; i++)
                {
                yield return queueArray[i];
                }
            }

        }   // End of class ResizableArrayQueue

    // Our real queue class that client will call by default.
    public class Queue<T> : ResizeableArrayQueue<T>
        { 
        // Inherits everything so don't need code.
        }

    //////////////////////////////////////////////////////////////
    // End of Queue Part.
    //////////////////////////////////////////////////////////////

    } // End of namespace Algorithms.
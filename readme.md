# Algorithms

This Visual Studio Project contains code pertaining to a namespace "Algorithms".
The code, written in C#, contains useful algorithms to be referenced later.

# Union Find
Check if two items are in the same connected component. item1 and item2 are integers representing the "id" (unique from 0 to N) for each component (item) in our problem.

##Initialize

UnionFind uf = new UnionFind(int numberOfComponents);

##Operations

bool Find(int item1, int item2) - True if item1 and item2 are in the same connected component.

void Union(int item2, int item2) - Connect item1 and item2.

# Stacks and Queues
Implemented our own stack and queue data structures. By default they use resizing arrays. (Code for linked list version is also there.) Written using generics so specify data type/object when initializing. Enumeration available so "foreach" loop available.

##Initialize
Algorithms.Queue<string> queue = new Queue<string>();

Algorithms.Stack<string> stack = new Stack<string>();

##Stack Operations 
void Push(T item) - Put an item onto the stack.

T Pop() - Remove an item from the stack and return it to the function caller.

size - The size of the stack.

bool IsEmpty() - Checks if there's any items on the stack.

##Queue Operations 
void Enqueue(T item) - Put an item into the queue.

T Dequeue() - Remove the item from the front of the queue and return it to the function caller.

size - The size of the queue.

bool IsEmpty() - Checks if there's any items on the queue.
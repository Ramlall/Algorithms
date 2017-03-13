# Algorithms

This Visual Studio Project contains code pertaining to a namespace "Algorithms".
The code, written in C#, contains useful algorithms to be referenced later.

# Union Find
Check if two items are in the same connected component.

##Initialize:

UnionFind uf = new UnionFind(int numberOfComponents);

##Operations:

bool Find(int item1, int item2) - True if item1 and item2 are in the same connected component.

void Union(int item2, int item2) - Connect item1 and item2.

# Stacks and Queues
Implemented our own stack and queue data structures. By default they use resizing arrays. (Code for linked list version is also there.) Written using generics so specify data type/object when initializing. Enumeration (foreach) currently not available. 

##Initialize:
Algorithms.Queue<int> queue = new Queue<int>();
Algorithms.Stack<int> stack = new Stack<int>();

##Operations: 
Standard "Pop" "Push" "size" "IsEmpty" for stacks and "Enqueue" "Dequeue" "size" "IsEmpty" for queues.
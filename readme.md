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
NOTE: Currently queue doesn't work.
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

# Graph
Creates a graph where you're allowed to add directed or undirected edges. Has functions for Breadth First Search and Depth First Search

## Initialize
Graph graph = new Graph(int NumberOfVertices);

graph.AddUndirectedEdge(int vertex1, int vertex2);

or 

graph.AddDirectedEdge(int vertex1, int vertex2);

graph.BFS(int sourceVertex);

graph.BFS(int sourceVertex);

# Graph_ShortestPath
Creates a graph where you can add weighted edges. Includes 3 methods for Dijkstra, Floyd Warshall, and Bellman Ford Algorithm. 

## Initialize
int v = 9;
Graph_ShortestPath gsp = new Graph_ShortestPath(v);
gsp.AddWeightedUndirectedEdge(new WeightedEdge( 0, 1, 4));

int source = 0;
List<SPNode> spList = gsp.Dijkstra(source);
Console.WriteLine($"Distance from {source} to {i} is {spList[i].distanceFromSource}. Parent is {spList[i].parentVertex}.");

List<SPNode> spList1 = gsp.BellmanFord(source);
Console.WriteLine($"Distance from {source} to {i} is {spList1[i].distanceFromSource}. Parent is {spList1[i].parentVertex}.");

int[,] spMatrix = gsp1.FloydWarshall();
int n = spMatrix[i, j];
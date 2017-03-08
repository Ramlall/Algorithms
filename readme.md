# Algorithms

This Visual Studio Project contains code pertaining to a namespace "Algorithms".
The code, written in C#, contains useful algorithms to be referenced later.

## Union Find
Check if two items are in the same connected component.

Initialize
UnionFind uf = new UnionFind(int numberOfComponents);

Operations:
bool Find(int item1, int item2) - True if item1 and item2 are in the same connected component.
void Union(int item2, int item2) - Connect item1 and item2.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
This file has the code for the algorithms for union find.
"Union Find" checks if two points are in the same connected component.

There are two operations in Union Find:
bool Connected(object1, object2) - Tests if two objects are connected
void Union(object1, object2) - Unionize two objects.

The running times are:
Algorithm           Union   Connected
QuickFind           N       1
QuickUnion          N       N
WeightedQuickUnion  lg N    lg N

Source of info: https://d18ky98rnyall9.cloudfront.net/_b65e7611894ba175de27bd14793f894a_15UnionFind.pdf?Expires=1489104000&Signature=Eu4ugSjgtQc5r1i6QAFLMLCGPabumlhd5H7OW0tfTgRFF3b188tWcQNZK9tygoic8J-EIK8Fk~Y~qtBhnLCB5LtBuAWPTeiTlh8PI80myR7r9sNUoTZ3AZ4hkSg3XR2rhQdSh0QtOTlIpiITwb-7VJ0C-8R1BF~Xtk7ZxHN8bVg_&Key-Pair-Id=APKAJLTNE6QMUY6HBC5A
*/

namespace Algorithms
    {
    class QuickFind
        {
        private int[] id;

        // Constructor to initialize the ID array.
        public QuickFind(int numberOfItems)
            {
            id = new int[numberOfItems];
            for(int i = 0; i < numberOfItems; i++)
                { id[i] = i; }
            }

        // Are item1 and item2 in the same connected component?
        public bool Connected(int item1, int item2)
            {
            return id[item1] == id[item2];
            }
        
        // Connect item1 and item2
        public void Union(int item1, int item2)
            {
            int item1id = id[item1];
            int item2id = id[item2];
            for(int i = 0; i < id.Length; i++)
                {
                if(id[i] == item1id)
                    { id[i] = item2id; }
                }
            }

        } // End of class QuickFind



    class QuickUnion
        {
        private int[] id;

        // Constructor to initialize the ID array.
        public QuickUnion(int numberOfItems)
            {
            id = new int[numberOfItems];
            for(int i = 0; i < numberOfItems; i++)
                { id[i] = i; }
            }

        // Helper method. Finds the root of an entry.
        private int root(int i)
            {
            while(i != id[i])
                { 
                i = id[i];
                }
            return i;
            }
        
        // Are item1 and item2 in the same connected component?
        public bool Connected(int item1, int item2)
            {
            return root(item1) == root(item2);
            }
        
        // Connect item1 and item2
        public void Union(int item1, int item2)
            {
            int i = root(item1);
            int j = root(item2);
            id[i] = j;
            }

        } // End of class QuickUnion



    class WeightedQuickUnion
        {
        private int[] id;

        // Constructor to initialize the ID array.
        public WeightedQuickUnion(int numberOfItems)
            {
            id = new int[numberOfItems];
            for(int i = 0; i < numberOfItems; i++)
                { id[i] = i; }
            }

        // Helper method. Finds the root of an entry.
        private int root(int i)
            {
            while(i != id[i])
                { 
                i = id[i];
                }
            return i;
            }
        
        // Are item1 and item2 in the same connected component?
        public bool Connected(int item1, int item2)
            {
            return root(item1) == root(item2);
            }
        
        // Connect item1 and item2
        public void Union(int item1, int item2)
            {
            int i = root(item1);
            int j = root(item2);
            id[i] = j;
            }

        } // End of class WeightedQuickUnion
    


    // Since WeightedQuickUnion is best, we'll inherit from it directly for all of our UnionFinds.
    class UnionFind: WeightedQuickUnion
        {
        // Call the constructor from the base class.
        public UnionFind(int numberOfItems) : base(numberOfItems)
            {
            }
        } // End of class UnionFind


    } // End of namespace Algorithms
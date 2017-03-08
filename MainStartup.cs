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
            // Test UnionFind
            int n = 10;

            // Initialize objects.
            QuickFind qf = new QuickFind(n);
            QuickUnion qu = new QuickUnion(n);
            WeightedQuickUnion wqu = new WeightedQuickUnion(n);
            UnionFind uf = new UnionFind(n);

            int a, b;
            a = 4; b = 3;
            qf.Union(a, b);
            qu.Union(a, b);
            wqu.Union(a, b);
            uf.Union(a, b);

            a = 3; b = 8;
            qf.Union(a, b);
            qu.Union(a, b);
            wqu.Union(a, b);
            uf.Union(a, b);

            a = 6; b = 5;
            qf.Union(a, b);
            qu.Union(a, b);
            wqu.Union(a, b);
            uf.Union(a, b);

            a = 9; b = 4;
            qf.Union(a, b);
            qu.Union(a, b);
            wqu.Union(a, b);
            uf.Union(a, b);

            a = 2; b = 1;
            qf.Union(a, b);
            qu.Union(a, b);
            wqu.Union(a, b);
            uf.Union(a, b);

            a = 8; b = 9;
            if (qf.Connected(a,b) == true) { Console.WriteLine($"{a} and {b} are connected.\n"); } else { Console.WriteLine($"{a} and {b} are not connected.\n"); }
            if (qu.Connected(a, b) == true) { Console.WriteLine($"{a} and {b} are connected.\n"); } else { Console.WriteLine($"{a} and {b} are not connected.\n"); }
            if (wqu.Connected(a, b) == true) { Console.WriteLine($"{a} and {b} are connected.\n"); } else { Console.WriteLine($"{a} and {b} are not connected.\n"); }
            if (uf.Connected(a, b) == true) { Console.WriteLine($"{a} and {b} are connected.\n"); } else { Console.WriteLine($"{a} and {b} are not connected.\n"); }


            a = 2; b = 1;
            qf.Union(a, b);
            qu.Union(a, b);
            wqu.Union(a, b);
            uf.Union(a, b);

            a = 5; b = 0;
            qf.Union(a, b);
            qu.Union(a, b);
            wqu.Union(a, b);
            uf.Union(a, b);

            a = 7; b = 2;
            qf.Union(a, b);
            qu.Union(a, b);
            wqu.Union(a, b);
            uf.Union(a, b);

            a = 6; b = 1;
            qf.Union(a, b);
            qu.Union(a, b);
            wqu.Union(a, b);
            uf.Union(a, b);

            a = 7; b = 3;
            qf.Union(a, b);
            qu.Union(a, b);
            wqu.Union(a, b);
            uf.Union(a, b);

            for (int i = 0; i < n-1; i++)
                {
                for(int j = i+1; j < n; j++)
                    { 
                    a = i; b = j;
                    if (qf.Connected(a, b) == true) { Console.WriteLine($"{a} and {b} are connected.\n"); } else { Console.WriteLine($"{a} and {b} are not connected.\n"); }
                    if (qu.Connected(a, b) == true) { Console.WriteLine($"{a} and {b} are connected.\n"); } else { Console.WriteLine($"{a} and {b} are not connected.\n"); }
                    if (wqu.Connected(a, b) == true) { Console.WriteLine($"{a} and {b} are connected.\n"); } else { Console.WriteLine($"{a} and {b} are not connected.\n"); }
                    if (uf.Connected(a, b) == true) { Console.WriteLine($"{a} and {b} are connected.\n"); } else { Console.WriteLine($"{a} and {b} are not connected.\n"); }
                    }
                }

            } // End of Main.
        } // End of class MainStartup
    } // End of namespace Algorithms
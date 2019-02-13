// detail: https://atcoder.jp/contests/code-thanks-festival-2017-open/submissions/4250223
//#define topt
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static System.Math;


class P
{
    static void Main()
    {
        int[] nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        PartialPersistentUnionFind uf = new PartialPersistentUnionFind(nm[0]);
        for (int i = 0; i < nm[1]; i++)
        {
            int[] ab = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            uf.Unite(ab[0], ab[1]);
        }
        int q = int.Parse(Console.ReadLine());
        for (int i = 0; i < q; i++)
        {
            int[] xy = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            if (uf.Find(xy[0]) != uf.Find(xy[1]))
            {
                Console.WriteLine(-1);
                continue;
            }
            int valid = nm[1];
            int invalid = -1;
            while (valid - invalid > 1)
            {
                var mid = (valid + invalid) / 2;
                int xp = uf.Find(xy[0], mid);
                int yp = uf.Find(xy[1], mid);
                if (xp == yp) valid = mid;
                else invalid = mid;
            }
            Console.WriteLine(valid);
        }
    }
}

class PartialPersistentUnionFind
{
    public int Now { get; private set; }
    int[] parents;
    int[] time;
    int[] rank;
    
    public PartialPersistentUnionFind(int size)
    {
        parents = Enumerable.Range(0, size).ToArray();
        time = Enumerable.Repeat(int.MaxValue, size).ToArray();
        rank = Enumerable.Range(0, size).ToArray();
    }

    public int Find(int i, int t = int.MaxValue - 1) => time[i] <= t ? Find(parents[i], t) : i;
    public void Unite(int x, int y)
    {
        Now++;
        x = Find(x);
        y = Find(y);
        if (x == y) return;
        if (rank[x] < rank[y])
        {
            var tmp = x;
            x = y;
            y = tmp;
        }
        parents[y] = x;
        time[y] = Now;
        rank[x] = rank[x] == rank[y] ? rank[y] + 1 : rank[x];
    }
}

// detail: https://atcoder.jp/contests/code-thanks-festival-2017-open/submissions/4466760
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
            uf.TryUnite(ab[0], ab[1]);
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
    public int Size { get; private set; }
    int[] Parents;
    int[] Time;
    int[] Sizes;
    List<Tuple<int, int>>[] SizeHistories;

    public PartialPersistentUnionFind(int size)
    {
        Size = size;
        Parents = Enumerable.Range(0, Size).ToArray();
        Time = Enumerable.Repeat(int.MaxValue, Size).ToArray();
        Sizes = Enumerable.Repeat(1, Size).ToArray();
        SizeHistories = Enumerable.Repeat(0, Size).Select(_ => new List<Tuple<int, int>>() { new Tuple<int, int>(0, 1) }).ToArray();
    }

    public bool TryUnite(int x, int y)
    {
        Now++;
        x = Find(x);
        y = Find(y);
        if (x == y) return false;
        if (Sizes[x] < Sizes[y])
        {
            var tmp = x;
            x = y;
            y = tmp;
        }
        Parents[y] = x;
        Time[y] = Now;
        Sizes[x] += Sizes[y];
        SizeHistories[x].Add(new Tuple<int, int>(Now, Sizes[x]));
        return true;
    }
    public int Find(int i, int t = int.MaxValue - 1) => Time[i] <= t ? Find(Parents[i], t) : i;
    public int GetSize(int i, int t = int.MaxValue - 1)
    {
        var root = Find(i, t);
        return SizeHistories[root][~SizeHistories[root].BinarySearch(new Tuple<int, int>(t, int.MaxValue)) - 1].Item2;
    }
}

// detail: https://atcoder.jp/contests/abc120/submissions/4447757
using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using static System.Math;
using Debug = System.Diagnostics.Debug;

class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToList();
        var abs = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToList()).ToList();
        List<long> res = new List<long>();
        UnionFind uf = new UnionFind(nm[0]);
        long now = (long)nm[0] * (nm[0] - 1) / 2;
        foreach (var ab in abs.Reverse<List<int>>())
        {
            res.Add(now);
            long acount = uf.GetSize(ab[0] - 1);
            long bcount = uf.GetSize(ab[1] - 1);
            if (uf.Unite(ab[0] - 1, ab[1] - 1))
            {
                now -= acount * bcount;
            }
        }
        res.Reverse();
        Console.WriteLine(string.Join("
", res));
    }
}


class UnionFind
{
    public int Size { get; private set; }
    List<int> parent;
    List<int> sizes;
    public UnionFind(int count)
    {
        Size = 0;
        parent = new List<int>(count);
        sizes = new List<int>(count);
        ExtendSize(count);
    }
    public bool Unite(int x, int y)
    {
        int xp = Find(x);
        int yp = Find(y);
        if (yp == xp) return false;
        if (sizes[xp] < sizes[yp])
        {
            var tmp = xp;
            xp = yp;
            yp = tmp;
        }
        parent[yp] = xp;
        sizes[xp] += sizes[yp];
        return true;
    }
    public IEnumerable<int> AllParents => parent.Where(x => x == parent[x]);
    public int GetSize(int x) => sizes[Find(x)];
    public int Find(int x) => parent[x] == parent[parent[x]] ? parent[x] : parent[x] = Find(parent[x]);
    public void ExtendSize(int treeSize)
    {
        if (treeSize <= Size) return;
        parent.Capacity = treeSize;
        sizes.Capacity = treeSize;
        while (Size < treeSize)
        {
            parent.Add(Size);
            sizes.Add(1);
            Size++;
        }
    }
}

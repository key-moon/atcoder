// detail: https://atcoder.jp/contests/atc001/submissions/4490862
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
 
class P
{
    static void Main()
    {
        int[] nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        UnionFind uf = new UnionFind(nq[0]);
        for (int i = 0; i < nq[1]; i++)
        {
            int[] pab = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (pab[0] == 0) uf.TryUnite(pab[1], pab[2]);
            else Console.WriteLine(uf.Find(pab[1]) == uf.Find(pab[2]) ? "Yes" : "No");
        }
    }
}


class UnionFind
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    List<int> Sizes;
    List<int> Parent;
    public UnionFind(int count)
    {
        Size = 0;
        GroupCount = 0;
        Parent = new List<int>(count);
        Sizes = new List<int>(count);
        ExtendSize(count);
    }
    public bool TryUnite(int x, int y)
    {
        int xp = Find(x);
        int yp = Find(y);
        if (yp == xp) return false;
        if (Sizes[xp] < Sizes[yp])
        {
            var tmp = xp;
            xp = yp;
            yp = tmp;
        }
        GroupCount--;
        Parent[yp] = xp;
        Sizes[xp] += Sizes[yp];
        return true;
    }
    public IEnumerable<int> AllRepresents => Parent.Where(x => x == Parent[x]);
    public int GetSize(int x) => Sizes[Find(x)];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        int originX = x;
        while (x != Parent[x])
        {
            var p = Parent[x];
            Parent[x] = originX;
            x = p;
        }
        Parent[originX] = x;
        return x;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ExtendSize(int treeSize)
    {
        if (treeSize <= Size) return;
        Parent.Capacity = treeSize;
        Sizes.Capacity = treeSize;
        while (Size < treeSize)
        {
            Parent.Add(Size);
            Sizes.Add(1);
            Size++;
            GroupCount++;
        }
    }
}

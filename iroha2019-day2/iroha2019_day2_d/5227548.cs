// detail: https://atcoder.jp/contests/iroha2019-day2/submissions/5227548
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        List<Tuple<int, int>>[] neighbours = Enumerable.Repeat(nm[0], 0).Select(_ => new List<Tuple<int, int>>()).ToArray();
        var abc = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).Select((x,y) => new Tuple<int, int, int, int>(x[0] - 1, x[1] - 1, x[2], y)).OrderByDescending(x => x.Item3).ToArray();
        UnionFind uf = new UnionFind(nm[0]);
        List<int> a = new List<int>();
        foreach (var edge in abc) if (uf.TryUnite(edge.Item1, edge.Item2)) a.Add(edge.Item4 + 1);
        Console.WriteLine(string.Join("
", a.OrderBy(x => x)));
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
        while (x != Parent[x])
        {
            Parent[x] = Parent[Parent[x]];
            x = Parent[x];
        }
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

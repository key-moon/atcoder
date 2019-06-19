// detail: https://atcoder.jp/contests/agc016/submissions/6022162
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToList();
        a.Add(a.Aggregate(0, (x, y) => x ^ y));
        var b = Console.ReadLine().Split().Select(int.Parse).ToList();
        b.Add(b.Aggregate(0, (x, y) => x ^ y));
        if (a.OrderBy(x => x).Zip(b.OrderBy(x => x), (x, y) => x != y).Any(x => x))
        {
            Console.WriteLine(-1);
            return;
        }

        var compressed = a.Distinct().OrderBy(x => x).Select((elem, count) => new { elem, count }).ToDictionary(x => x.elem, x => x.count);
        int sameCount = 0;
        UnionFind uf = new UnionFind(compressed.Count);
        for (int i = 0; i < n; i++)
        {
            if (a[i] == b[i]) sameCount++;
            uf.TryUnite(compressed[a[i]], compressed[b[i]]);
        }
        //全ての違う変数を動かす+閉路の数だけ動かす必要がある 始点を閉路に組み込めているならば-1
        Console.WriteLine((n - sameCount) + uf.AllRepresents.Count(x => 2 <= uf.GetSize(x)) - (n != sameCount && b.IndexOf(a.Last()) != n ? 1 : 0));
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
    public IEnumerable<int> AllRepresents => Enumerable.Range(0, Size).Where(x => x == Parent[x]);
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

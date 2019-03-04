// detail: https://atcoder.jp/contests/abc120/submissions/4467879
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
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;


class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToList();
        var abs = Enumerable.Repeat(0, nm[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToList()).ToList();
        List<long> res = new List<long>();
        //CompressionUnionFind uf = new CompressionUnionFind(nm[0]);
        HalvingUnionFind uf = new HalvingUnionFind(nm[0]);
        long now = (long)nm[0] * (nm[0] - 1) / 2;
        foreach (var ab in abs.Reverse<List<int>>())
        {
            res.Add(now);
            long acount = uf.GetSize(ab[0] - 1);
            long bcount = uf.GetSize(ab[1] - 1);
            if (uf.TryUnite(ab[0] - 1, ab[1] - 1))
            {
                now -= acount * bcount;
            }
        }
        res.Reverse();
        Console.WriteLine(string.Join("
", res));
    }
}


class HalvingUnionFind
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    List<int> parent;
    List<int> sizes;
    public HalvingUnionFind(int count)
    {
        Size = 0;
        GroupCount = 0;
        parent = new List<int>(count);
        sizes = new List<int>(count);
        ExtendSize(count);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryUnite(int x, int y)
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
        GroupCount--;
        parent[yp] = xp;
        sizes[xp] += sizes[yp];
        return true;
    }
    public IEnumerable<int> AllRepresents => parent.Where(x => x == parent[x]);
    public int GetSize(int x) => sizes[Find(x)];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        while (x != parent[x])
        {
            parent[x] = parent[parent[x]];
            x = parent[x];
        }
        return x;
    }
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
            GroupCount++;
        }
    }
}

class CompressionUnionFind
{
    public int Size { get; private set; }
    public int GroupCount { get; private set; }
    List<int> parent;
    List<int> sizes;
    public CompressionUnionFind(int count)
    {
        Size = 0;
        GroupCount = 0;
        parent = new List<int>(count);
        sizes = new List<int>(count);
        ExtendSize(count);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryUnite(int x, int y)
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
        GroupCount--;
        parent[yp] = xp;
        sizes[xp] += sizes[yp];
        return true;
    }
    public IEnumerable<int> AllRepresents => parent.Where(x => x == parent[x]);
    public int GetSize(int x) => sizes[Find(x)];
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Find(int x)
    {
        List<int> pathNodes = new List<int>();
        while (parent[x] != parent[parent[x]])
        {
            pathNodes.Add(x);
            x = parent[x];
        }
        for (int i = 0; i < pathNodes.Count; i++) parent[pathNodes[i]] = parent[x];
        return parent[x];
    }
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
            GroupCount++;
        }
    }
}

class SegmentTree<T>
{
    public int Size { get; private set; }
    T IdentityElement;
    T[] Data;
    Func<T, T, T> Merge;
    int LeafCount;

    public SegmentTree(int size, T identityElement, Func<T, T, T> merge) : this(Enumerable.Repeat(identityElement,size).ToArray(), identityElement, merge) { }

    public SegmentTree(T[] elems, T identityElement, Func<T, T, T> merge)
    {
        Size = elems.Length;
        Merge = merge;
        IdentityElement = identityElement;
        LeafCount = 1;
        while (LeafCount < elems.Length) LeafCount <<= 1;

        Data = new T[LeafCount * 2];
        elems.CopyTo(Data, LeafCount);
        for (int i = LeafCount - 1; i >= 0; i--) Data[i] = Merge(Data[i * 2], Data[i * 2 + 1]);
    }

    public void Update(int i, T x)
    {
        int ind = LeafCount + i;
        Data[ind] = x;
        while (0 < (ind >>= 1)) Data[ind] = Merge(Data[ind * 2], Data[ind * 2 + 1]);
    }
    public T Query(int l, int r) => Query(l, r, 1, 0, LeafCount - 1);
    private T Query(int l, int r, int i, int x, int y)
    {
        if (y < l || r < x) return IdentityElement;
        if (l <= x && y <= r) return Data[i];
        return Merge(Query(l, r, i * 2, x, (x + y) / 2), Query(l, r, i * 2 + 1, (x + y) / 2 + 1, y));
    }
}

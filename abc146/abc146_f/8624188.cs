// detail: https://atcoder.jp/contests/abc146/submissions/8624188
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nm[0];
        var m = nm[1];
        var s = Console.ReadLine();
        SegmentTree<int> segtree = new SegmentTree<int>(n + 1, int.MaxValue / 2, Min);
        segtree.Operate(n, 0);
        for (int i = n; i >= 0; i--)
        {
            if (s[i] == '1') continue;
            var val = segtree[i];
            segtree.Operate(Max(0, i - m), i, val + 1);
        }
        if (segtree[0] == int.MaxValue / 2) { Console.WriteLine(-1); return; }
        var last = segtree[0];
        var lastPos = 0;
        List<int> res = new List<int>();
        for (int i = 0; i <= n; i++)
        {
            if (s[i] == '1' || last - 1 != segtree[i]) continue;
            res.Add(i - lastPos);
            last = segtree[i];
            lastPos = i;
        }
        Console.WriteLine(string.Join(" ", res));
    }
}


class SegmentTree<T>
{
    public readonly int Size;
    T[] Operators;
    Func<T, T, T> Merge;
    int LeafCount;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Merge = merge;
        LeafCount = 1;
        while (LeafCount < size) LeafCount <<= 1;
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++)
            Operators[i] = identity;
    }
    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Query(index); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x) { i += LeafCount; Operators[i] = Merge(Operators[i], x); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        for (l += LeafCount, r += LeafCount; l <= r; l = (l + 1) >> 1, r = (r - 1) >> 1)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l], x);
            if ((r & 1) == 0) Operators[r] = Merge(Operators[r], x);
        }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int i)
    {
        i += LeafCount;
        T res = Operators[i];
        while (0 < (i >>= 1)) res = Merge(res, Operators[i]);
        return res;
    }
}

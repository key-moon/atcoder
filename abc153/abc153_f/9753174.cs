// detail: https://atcoder.jp/contests/abc153/submissions/9753174
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using static System.Math;
using System.Threading.Tasks;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var nda = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var monsters = Enumerable.Repeat(0, (int)nda[0]).Select(_ => Console.ReadLine().Split().Select(long.Parse).ToArray()).OrderBy(x => x[0]).ToArray();
        SegmentTree<long> segtree = new SegmentTree<long>((int)nda[0], 0, (x, y) => x + y);
        for (int i = 0; i < nda[0]; i++)
            segtree.Operate(i, monsters[i][1]);
        var dist = 0L;
        int topInd = 0;
        long total = 0;
        for (int i = 0; i < nda[0]; i++)
        {
            while (topInd + 1 < monsters.Length)
            {
                var nextDist = dist + monsters[topInd + 1][0] - monsters[topInd][0];
                if (nda[1] * 2 < nextDist) break;
                dist = nextDist;
                topInd++;
            }
            if (0 <= segtree[i]) 
            {
                long count = (segtree[i] + nda[2] - 1) / nda[2];
                total += count; 
                segtree.Operate(i, topInd, -nda[2] * count);
            }
            if (i != nda[0] - 1) dist -= monsters[i + 1][0] - monsters[i][0];
        }
        Console.WriteLine(total);
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

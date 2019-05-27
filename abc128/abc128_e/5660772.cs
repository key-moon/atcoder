// detail: https://atcoder.jp/contests/abc128/submissions/5660772
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
        var nq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var stxs = Enumerable.Repeat(0, nq[0]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).ToArray();
        var queries = Enumerable.Repeat(0, nq[1]).Select(_ => int.Parse(Console.ReadLine())).ToList();

        var dict = new Dictionary<int, int>();
        for (int i = 0; i < queries.Count; i++) dict.Add(queries[i], i);
        

        SegmentTree<int> segTree = new SegmentTree<int>(queries.Count, int.MaxValue, Min);
        foreach (var stx in stxs.OrderByDescending(x => x[2]))
        {
            var start = queries.BinarySearch(stx[0] - stx[2]);
            var end = queries.BinarySearch(stx[1] - stx[2]);
            if (start < 0) start = ~start;
            if (end < 0) end = ~end;
            segTree.Operate(start, end, stx[2]);
        }

        StringBuilder builder = new StringBuilder();
        foreach (var q in queries)
        {
            var query = segTree.Query(dict[q]);
            builder.AppendLine((query == int.MaxValue ? -1 : query).ToString());
        }
        Console.WriteLine(builder.ToString());
    }
}


class SegmentTree<T>
{
    public int Size { get; private set; }
    T IdentityElement;
    T[] Operators;
    Func<T, T, T> Merge;
    int LeafCount;

    public SegmentTree(int size, T identityElement, Func<T, T, T> merge)
    {
        Size = size;
        Merge = merge;
        IdentityElement = identityElement;
        LeafCount = 1;
        while (LeafCount < size) LeafCount <<= 1;

        Operators = Enumerable.Repeat(identityElement, LeafCount * 2).ToArray();
    }

    public T this[int index]
    {
        get { return Query(index); }
        set { Operate(index, index + 1, value); }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        l += LeafCount;
        r += LeafCount - 1;
        while (l <= r)
        {
            if (l % 2 == 1) Operators[l] = Merge(x, Operators[l]);
            if (r % 2 == 0) Operators[r] = Merge(x, Operators[r]);
            l = (l + 1) / 2;
            r = (r - 1) / 2;
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

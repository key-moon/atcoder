// detail: https://atcoder.jp/contests/abc106/submissions/5446963
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
        var nmq = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //始点降順ソート
        var lrs = Enumerable.Repeat(0, nmq[1]).Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray()).OrderBy(x => x[0]).ToArray();
        int ptr = lrs.Length - 1;
        var queries = Enumerable.Range(0, nmq[2]).Select(x => new Tuple<int, int[]>(x, Console.ReadLine().Split().Select(int.Parse).ToArray())).OrderByDescending(x => x.Item2[0]).ToArray();
        int[] res = new int[nmq[2]];
        SegmentTree<int> sum = new SegmentTree<int>(nmq[0] + 1, 0, (x, y) => x + y);
        foreach (var query in queries)
        {
            while (0 <= ptr && query.Item2[0] <= lrs[ptr][0])
            {
                sum.Operate(lrs[ptr][1], nmq[0], 1);
                ptr--;
            }
            res[query.Item1] = sum.Query(query.Item2[1]);
        }
        Console.WriteLine(string.Join("
", res));
    }
}


class SegmentTree<T>
{
    public int Size { get; private set; }
    T IdentityElement;
    T[] Operators;
    Func<T, T, T> Merge;
    int LeafCount;

    public SegmentTree(int size, T identityElement, Func<T, T, T> merge) : this(Enumerable.Repeat(identityElement, size).ToArray(), identityElement, merge) { }

    public SegmentTree(T[] elems, T identityElement, Func<T, T, T> merge)
    {
        Size = elems.Length;
        Merge = merge;
        IdentityElement = identityElement;
        LeafCount = 1;
        while (LeafCount < elems.Length) LeafCount <<= 1;

        Operators = new T[LeafCount * 2];
        elems.CopyTo(Operators, LeafCount);
        for (int i = LeafCount - 1; i >= 1; i--) Operators[i] = Merge(Operators[i * 2], Operators[i * 2 + 1]);
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
        r += LeafCount;
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

// detail: https://atcoder.jp/contests/abc128/submissions/6545632
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
        List<Tuple<int, int>> tuples = new List<Tuple<int, int>>();
        List<int> places = new List<int>();
        var queries = Enumerable.Repeat(0, nq[1]).Select(_ => int.Parse(Console.ReadLine())).ToArray();

        var ordered = queries.OrderBy(x => x).ToList();
        int last = ordered.First();
        var dict = new Dictionary<int, int>() { { last, 0 } };
        foreach (var item in ordered.Skip(1))
        {
            dict.Add(item, dict.Count);
            last = item;
        }

        //区間代入
        SegmentTree<int> segTree = new SegmentTree<int>(queries.Length, -1, (x, y) => y == -1 ? x : y, x => x, x => x);
        foreach (var stx in stxs.OrderByDescending(x => x[2]))
        {
            var start = ordered.BinarySearch(stx[0] - stx[2]);
            var end = ordered.BinarySearch(stx[1] - stx[2]);
            if (start < 0) start = ~start;
            if (end < 0) end = ~end;
            segTree.Operate(start, end, stx[2]);
        }

        List<int> res = new List<int>();
        foreach (var q in queries)
        {
            res.Add(segTree.Query(dict[q]));
        }
        Console.WriteLine(string.Join("
", res));
    }
}


class SegmentTree<T>
{
    public int Size { get; private set; }
    T Identity;
    Func<T, T, T> MergeOperator;
    Func<T, T> GetLeftHalf;
    Func<T, T> GetRightHalf;
    int LeafCount;
    int TreeHeight;
    T[] Operators;

    public SegmentTree(int size, T identity, Func<T, T, T> mergeOperator, Func<T, T> getLeftHalf, Func<T, T> getRightHalf)
    {
        Size = size;
        Identity = identity;
        MergeOperator = mergeOperator;
        GetLeftHalf = getLeftHalf;
        GetRightHalf = getRightHalf;
        LeafCount = 1;
        while (LeafCount < size) { LeafCount <<= 1; TreeHeight++; }
        Operators = Enumerable.Repeat(identity, LeafCount * 2).ToArray();
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
        Propagate(l);
        Propagate(r);
        while (l <= r)
        {
            if (l % 2 == 1) Operators[l] = MergeOperator(Operators[l], x);
            if (r % 2 == 0) Operators[r] = MergeOperator(Operators[r], x);
            l = (l + 1) / 2;
            r = (r - 1) / 2;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int index)
    {
        index += LeafCount;
        Propagate(index);
        return Operators[index];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int sectionIndex)
    {
        for (int i = TreeHeight - 1; i >= 1; i--) Eval(sectionIndex >> i);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Eval(int sectionIndex)
    {
        Operators[sectionIndex * 2] = MergeOperator(Operators[sectionIndex * 2], GetLeftHalf(Operators[sectionIndex]));
        Operators[sectionIndex * 2 + 1] = MergeOperator(Operators[sectionIndex * 2 + 1], GetRightHalf(Operators[sectionIndex]));
        Operators[sectionIndex] = Identity;
    }
}

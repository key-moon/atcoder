// detail: https://atcoder.jp/contests/abc128/submissions/7142997
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
        var n = NextInt;
        var q = NextInt;
        var scedules = new Scedule[n];
        for (int i = 0; i < scedules.Length; i++)
            scedules[i] = new Scedule() { s = NextInt, t = NextInt, x = NextInt };

        var queries = new int[q];
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < queries.Length; i++)
            dict.Add(queries[i] = NextInt, i);

        SegmentTree<int> segTree = new SegmentTree<int>(queries.Length, int.MaxValue, Min);
        foreach (var scedule in scedules.OrderByDescending(x => x.x))
        {
            var start = Array.BinarySearch(queries, scedule.s - scedule.x);
            var end = Array.BinarySearch(queries, scedule.t - scedule.x);
            if (start < 0) start = ~start;
            if (end < 0) end = ~end;
            segTree.Operate(start, end - 1, scedule.x);
        }

        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < queries.Length; i++)
        {
            var query = segTree.Query(dict[queries[i]]);
            builder.AppendLine((query == int.MaxValue ? -1 : query).ToString());
        }
        Console.Write(builder.ToString());
    }

    static readonly TextReader In = Console.In;
    static int NextInt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            int res = 0;
            int next = In.Read();
            while (45 > next || next > 57) next = In.Read();
            while (48 <= next && next <= 57)
            {
                res = res * 10 + next - 48;
                next = In.Read();
            }
            return res;
        }
    }
}

struct Scedule
{
    public int s;
    public int t;
    public int x;
}


class SegmentTree<T>
{
    public readonly int Size;
    T Identity;
    Func<T, T, T> Merge;
    int LeafCount;
    int Height;
    T[] Operators;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        Height = 1;
        LeafCount = 1;
        while (LeafCount < size) { Height++; LeafCount <<= 1; }
        Operators = new T[LeafCount << 1];
        for (int i = 0; i < Operators.Length; i++) Operators[i] = identity;
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Query(index); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Propagate(index += LeafCount); Operators[index] = value; }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        l += LeafCount;
        r += LeafCount;
        Propagate(l);
        Propagate(r);
        while (l <= r)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l++], x);
            if ((r & 1) == 0) Operators[r] = Merge(Operators[r--], x);
            l >>= 1;
            r >>= 1;
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
    private void Eval(int ind)
    {
        Operators[(ind << 1)] = Merge(Operators[(ind << 1)], Operators[ind]);
        Operators[(ind << 1) | 1] = Merge(Operators[(ind << 1) | 1], Operators[ind]);
        Operators[ind] = Identity;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int sectionIndex)
    {
        for (int i = Height - 1; i >= 1; i--)
        {
            Operators[sectionIndex >> (i - 1)] = Merge(Operators[sectionIndex >> (i - 1)], Operators[sectionIndex >> i]);
            Operators[sectionIndex >> (i - 1) ^ 1] = Merge(Operators[sectionIndex >> (i - 1) ^ 1], Operators[sectionIndex >> i]);
            Operators[sectionIndex >> i] = Identity;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int l, int r)
    {
        if (l == r) { Propagate(l); return; }
        int xor = l ^ r, i = Height - 1;
        for (; (xor >> i) == 0; i--) { Eval(l >> i); }
        for (; i >= 1; i--) { Eval(l >> i); Eval(r >> i); }
    }
}

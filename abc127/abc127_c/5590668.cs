// detail: https://atcoder.jp/contests/abc127/submissions/5590668
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using LayoutKind = System.Runtime.InteropServices.LayoutKind;
using StructLayoutAttribute = System.Runtime.InteropServices.StructLayoutAttribute;
using FieldOffsetAttribute = System.Runtime.InteropServices.FieldOffsetAttribute;

static class P
{
    static void Main()
    {
        var nm = Console.ReadLine().Split().Select(int.Parse).ToArray();
        SegmentTree<int> segmentTree = new SegmentTree<int>(nm[0], 0, (x, y) => x + y);
        for (int i = 0; i < nm[1]; i++)
        {
            var lr = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
            segmentTree.Operate(lr[0], lr[1], 1);
        }
        int res = 0;
        for (int i = 0; i < segmentTree.Size; i++)
        {
            if (segmentTree[i] == nm[1]) res++;
        }
        Console.WriteLine(res);
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

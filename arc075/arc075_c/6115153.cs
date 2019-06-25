// detail: https://atcoder.jp/contests/arc075/submissions/6115153
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        long[] accums = new long[n + 1];
        for (int i = 1; i < accums.Length; i++)
            accums[i] = accums[i - 1] + int.Parse(Console.ReadLine()) - k;
        var list = accums.Distinct().ToList();
        list.Sort();
        SegmentTree<int> segTree = new SegmentTree<int>(list.Count, 0, (x, y) => x + y);
        long res = 0;
        for (int i = 0; i < accums.Length; i++)
        {
            var ind = list.BinarySearch(accums[i]);
            res += segTree.Query(0, ind);
            segTree.Operate(ind, 1);
        }
        Console.WriteLine(res);
    }
}


class SegmentTree<T>
{
    public int Size { get; private set; }
    T IdentityElement;
    T[] Data;
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

        Data = new T[LeafCount * 2];
        elems.CopyTo(Data, LeafCount);
        for (int i = LeafCount - 1; i >= 1; i--) Data[i] = Merge(Data[i * 2], Data[i * 2 + 1]);
    }

    public T this[int index]
    {
        get { return Data[LeafCount + index]; }
        set { Update(index, value); }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Update(int i, T x)
    {
        i += LeafCount;
        Data[i] = x;
        while (0 < (i >>= 1)) Data[i] = Merge(Data[i * 2], Data[i * 2 + 1]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x)
    {
        i += LeafCount;
        Data[i] = Merge(Data[i], x);
        while (0 < (i >>= 1)) Data[i] = Merge(Data[i * 2], Data[i * 2 + 1]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int l, int r)
    {
        l += LeafCount;
        T lRes = IdentityElement;
        r += LeafCount;
        T rRes = IdentityElement;
        while (l <= r)
        {
            if (l % 2 == 1) lRes = Merge(lRes, Data[l]);
            if (r % 2 == 0) rRes = Merge(Data[r], rRes);
            l = (l + 1) / 2;
            r = (r - 1) / 2;
        }
        return Merge(lRes, rRes);
    }
}

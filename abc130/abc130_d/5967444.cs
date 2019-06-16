// detail: https://atcoder.jp/contests/abc130/submissions/5967444
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = Read();
        var k = Read();
        var ruiseki = new long[n + 1];
        for (int i = 0; i < ruiseki.Length - 1; i++)
        {
            ruiseki[i + 1] = ruiseki[i] + Read();
        }
        HashSet<long> hash = new HashSet<long>();
        for (int i = 0; i < ruiseki.Length; i++)
        {
            hash.Add(ruiseki[i]);
            if (k <= ruiseki[i]) hash.Add(ruiseki[i] - k);
        }
        var list = hash.ToList();
        list.Sort();
        SegmentTree<long> segtree = new SegmentTree<long>(list.Count, 0, (x, y) => x + y);

        long res = 0;
        for (int i = 0; i < ruiseki.Length; i++)
        {
            if (k <= ruiseki[i])
            {
                res += segtree.Query(0, list.BinarySearch(ruiseki[i] - k));
            }
            segtree.Operate(list.BinarySearch(ruiseki[i]), 1);
        }
        Console.WriteLine(res);
    }

    static readonly TextReader In = Console.In;
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static long Read()
    {
        long res = 0;
        int next = In.Read();
        while (48 > next || next > 57) next = In.Read();
        while (48 <= next && next <= 57)
        {
            res = res * 10 + next - 48;
            next = In.Read();
        }
        return res;
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

// detail: https://atcoder.jp/contests/agc038/submissions/7641872
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    static int h;
    static int w;
    static int a;
    static int b;
    public static void Main()
    {
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nk[0];
        var k = nk[1];
        var p = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long res = 1;
        SegmentTree<Incr> isIncr = new SegmentTree<Incr>(p.Select(x => new Incr() { L = x, R = x, Valid = true }).ToArray(), new Incr() { Valid = true, L = int.MaxValue, R = int.MinValue }, Incr.Merge);
        SegmentTree<int> rmin = new SegmentTree<int>(p, int.MaxValue, Min);
        SegmentTree<int> rmax = new SegmentTree<int>(p, int.MinValue, Max);
        long incrCount = isIncr.Query(0, k - 1).Valid ? 1 : 0;
        for (int i = 1; i <= n - k; i++)
        {
            if (rmax.Query(i, i + k - 1) != p[i + k - 1] || rmin.Query(i - 1, i + k - 2) != p[i - 1])
            {
                if (isIncr.Query(i, i + k - 1).Valid) incrCount++;
                res++;
            }
        }

        Console.WriteLine(res - (incrCount <= 1 ? 0 : incrCount - 1));
    }
}

struct Incr
{
    public bool Valid;
    public int L;
    public int R;
    public static Incr Merge(Incr a, Incr b) => a.Valid && b.Valid && a.R < b.L ? new Incr() { L = a.L, R = b.R, Valid = true } : new Incr { Valid = false };
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

        Data = new T[LeafCount << 1];
        elems.CopyTo(Data, LeafCount);
        for (int i = Data.Length + LeafCount; i < Data.Length; i++) Data[i] = IdentityElement;
        for (int i = LeafCount - 1; i >= 1; i--) Data[i] = Merge(Data[i << 1], Data[(i << 1) + 1]);
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
        while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) + 1]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x)
    {
        i += LeafCount;
        Data[i] = Merge(Data[i], x);
        while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) + 1]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int l, int r)
    {
        l += LeafCount; r += LeafCount;
        T lRes = IdentityElement, rRes = IdentityElement;
        while (l <= r)
        {
            if ((l & 1) == 1) lRes = Merge(lRes, Data[l]);
            if ((r & 1) == 0) rRes = Merge(Data[r], rRes);
            l = (l + 1) >> 1;
            r = (r - 1) >> 1;
        }
        return Merge(lRes, rRes);
    }
}

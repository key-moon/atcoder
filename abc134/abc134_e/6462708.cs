// detail: https://atcoder.jp/contests/abc134/submissions/6462708
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Math;
using Debug = System.Diagnostics.Debug;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

static class P
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        //小さい方から見ていく
        //前に行くならできる限り前の奴が行ったほうがいいので、pqに突っ込む? いや、そこまでで一番こっちのものなのでセグ木
        var a = Enumerable.Repeat(0, n).Select(_ => int.Parse(Console.ReadLine())).ToArray();
        var orderedGroup = a.Select((Elem, Ind) => new { Elem, Ind }).GroupBy(x => x.Elem).OrderBy(x => x.Key).ToArray();
        SegmentTree<IntTuple> segTree = new SegmentTree<IntTuple>(Enumerable.Range(0, n).Select(x => new IntTuple(x, 0)).ToArray(), new IntTuple(-1, 0), (x, y) => y.Count == 0 ? x : y);
        var res = 0;
        foreach (var group in orderedGroup)
        {
            //それぞれがどれから遷移するかを纏める
            foreach (var item in group)
            {
                var least = segTree.Query(0, item.Ind);
                if (least.Count != 0)
                    segTree[least.Ind] = new IntTuple(least.Ind, least.Count - 1);
                else
                    res++;
            }
            foreach (var item in group)
            {
                var cur = segTree[item.Ind];
                segTree[item.Ind] = new IntTuple(cur.Ind, cur.Count + 1);
            }
        }
        Console.WriteLine(res);
    }
}

struct IntTuple
{
    public int Ind;
    public int Count;
    public IntTuple(int item1, int item2)
    {
        Ind = item1;
        Count = item2;
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
        r += LeafCount - 1;
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

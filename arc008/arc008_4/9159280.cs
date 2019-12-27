// detail: https://atcoder.jp/contests/arc008/submissions/9159280
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;

public static class P
{
    public static void Main()
    {
        var nm = Console.ReadLine().Split().Select(long.Parse).ToArray();
        var m = nm[1];
        var queries = Enumerable.Repeat(0, (int)m).Select(_ => Query.Parse(Console.ReadLine())).ToArray();
        var compressDict = queries.Select(x => x.N).Distinct().OrderBy(x => x).Select((Elem, Index) => new { Elem, Index }).ToDictionary(x => x.Elem, x => x.Index);
        SegmentTree<Linear> segTree = new SegmentTree<Linear>(compressDict.Count, new Linear() { A = 1, B = 0 }, Linear.Merge);

        double min = 1;
        double max = 1;
        foreach (var query in queries)
        {
            segTree[compressDict[query.N]] = new Linear() { A = query.A, B = query.B };
            var res = segTree.Query(0, compressDict.Count - 1);
            max = Max(max, res.A + res.B);
            min = Min(min, res.A + res.B);
        }
        Console.WriteLine(min);
        Console.WriteLine(max);
    }
}

struct Query
{
    public long N;
    public double A;
    public double B;
    public static Query Parse(string s)
    {
        var splitted = s.Split();
        return new Query() { N = long.Parse(splitted[0]), A = double.Parse(splitted[1]), B = double.Parse(splitted[2]) }; 
    }
}

struct Linear
{
    public double A;
    public double B;
    static public Linear Merge(Linear a, Linear b) => new Linear() { A = a.A * b.A, B = a.B * b.A + b.B };
}

class SegmentTree<T>
{
    public int Size { get; private set; }
    T Identity;
    T[] Data;
    Func<T, T, T> Merge;
    int LeafCount;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(int size, T identity, Func<T, T, T> merge)
    {
        Init(size, identity, merge);
        for (int i = 1; i < Data.Length; i++) Data[i] = identity;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public SegmentTree(T[] elems, T identity, Func<T, T, T> merge)
    {
        Init(elems.Length, identity, merge);
        elems.CopyTo(Data, LeafCount);
        for (int i = elems.Length + LeafCount; i < Data.Length; i++) Data[i] = identity;
        for (int i = LeafCount - 1; i >= 1; i--) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Init(int size, T identity, Func<T, T, T> merge)
    {
        Size = size;
        Identity = identity;
        Merge = merge;
        LeafCount = 1;
        while (LeafCount < size) LeafCount <<= 1;
        Data = new T[LeafCount << 1];
    }

    public T this[int index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return Data[LeafCount + index]; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set { Update(index, value); }
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Update(int i, T x) { Data[i += LeafCount] = x; while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int i, T x) { Data[i += LeafCount] = Merge(Data[i], x); while (0 < (i >>= 1)) Data[i] = Merge(Data[i << 1], Data[(i << 1) | 1]); }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Query(int l, int r)
    {
        T lRes = Identity, rRes = Identity;
        for (l += LeafCount, r += LeafCount; l <= r; l = (l + 1) >> 1, r = (r - 1) >> 1)
        {
            if ((l & 1) == 1) lRes = Merge(lRes, Data[l]); if ((r & 1) == 0) rRes = Merge(Data[r], rRes);
        }
        return Merge(lRes, rRes);
    }
}

// detail: https://atcoder.jp/contests/abc140/submissions/7399991
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        //今生成できるものの中から貪欲に選んで良い
        var dict = a.Distinct().OrderBy(x => x).Select((Elem, Ind) => new { Elem, Ind }).ToDictionary(x => x.Elem, x => x.Ind);
        var compressed = a.Select(x => dict[x]).ToArray();
        SegmentTree<Tuple<int, int>> segTree = new SegmentTree<Tuple<int, int>>(compressed.GroupBy(x => x).Select(x => new Tuple<int, int>(x.Count(), x.Key)).OrderBy(x => x.Item2).ToArray(), new Tuple<int, int>(0, -1), (x, y) => y.Item1 == 0 ? x : y);
        List<int> slimes = new List<int>() { segTree.Query(0, segTree.Size - 1).Item2 };
        {
            var elem = segTree[segTree.Size - 1];
            segTree[elem.Item2] = new Tuple<int, int>(elem.Item1 - 1, elem.Item2);
        }
        for (int i = 0; i < n; i++)
        {
            var newSlimes = new List<int>();
            foreach (var item in slimes)
            {
                var elem = segTree.Query(0, item - 1);
                if (elem.Item1 == 0)
                {
                    Console.WriteLine("No");
                    return;
                }
                segTree[elem.Item2] = new Tuple<int, int>(elem.Item1 - 1, elem.Item2);
                newSlimes.Add(item);
                newSlimes.Add(elem.Item2);
            }
            newSlimes.Sort();
            slimes = newSlimes;
        }
        Console.WriteLine("Yes");
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

        Data = new T[LeafCount << 1];
        elems.CopyTo(Data, LeafCount);
        for (int i = elems.Length + LeafCount; i < Data.Length; i++) Data[i] = IdentityElement;
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

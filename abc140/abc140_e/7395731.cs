// detail: https://atcoder.jp/contests/abc140/submissions/7395731
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
        var p = Console.ReadLine().Split().Select(x => int.Parse(x) - 1).ToArray();
        var ind = new int[n];
        for (int i = 0; i < n; i++)
            ind[p[i]] = i;
        SegmentTree<int> rFirstElemInd = new SegmentTree<int>(n, n, (x, y) => y == n ? x : y);
        SegmentTree<int> lFirstElemInd = new SegmentTree<int>(n, -1, (x, y) => y == -1 ? x : y);
        long res = 0;
        for (long i = n - 1; i >= 0; i--)
        {
            var curIndex = ind[i];
            var rIndex = rFirstElemInd[ind[i]];
            var lIndex = lFirstElemInd[ind[i]];
            if (rIndex < n)
            {
                var rNextIndex = rFirstElemInd[rIndex];
                res += (i + 1) * (curIndex - lIndex) * (rNextIndex - rIndex);
            }
            if (0 <= lIndex)
            {
                var lNextIndex = lFirstElemInd[lIndex];
                res += (i + 1) * (rIndex - curIndex) * (lIndex - lNextIndex);
            }
            rFirstElemInd.Operate(lIndex, curIndex - 1, curIndex);
            lFirstElemInd.Operate(curIndex + 1, rIndex, curIndex);
        }
        Console.WriteLine(res);
    }
}


class SegmentTree<T> : IEnumerable<T>
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

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Size; i++)
        {
            yield return this[i];
        }
    }

    public override string ToString() => string.Join(" ", this);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Operate(int l, int r, T x)
    {
        l = Max(l, 0) + LeafCount;
        r = Min(r, Size - 1) + LeafCount;
        if (l > r) return;
        Propagate(l);
        Propagate(r);
        while (l <= r)
        {
            if ((l & 1) == 1) Operators[l] = Merge(Operators[l], x);
            if ((r & 1) == 0) Operators[r] = Merge(Operators[r], x);
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

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Propagate(int sectionIndex)
    {
        for (int i = Height - 1; i >= 1; i--)
        {
            var section = sectionIndex >> i;
            var leftChild = sectionIndex >> (i - 1);
            var rightChild = leftChild ^ 1;
            Operators[leftChild] = Merge(Operators[leftChild], Operators[section]);
            Operators[rightChild] = Merge(Operators[rightChild], Operators[section]);
            Operators[section] = Identity;
        }
    }
}

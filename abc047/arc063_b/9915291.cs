// detail: https://atcoder.jp/contests/abc047/submissions/9915291
using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

public static class P
{
    public static void Main()
    {
        var nt = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nt[0];
        var t = nt[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        
        var max = 0;

        DisjointSparseTable<int> rangeMin = new DisjointSparseTable<int>(a, Min);
        DisjointSparseTable<int> rangeMax = new DisjointSparseTable<int>(a, Max);

        for (int i = 0; i < n; i++)
            max = Max(max, a[i] - rangeMin.Query(0, i));

        var res = int.MaxValue;
        {
            var count = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] + max == rangeMax.Query(i, rangeMax.Size - 1)) count++;
            }
            res = Min(res, count);
        }
        {
            var count = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] - max == rangeMin.Query(0, i)) count++;
            }
            res = Min(res, count);
        }
        Console.WriteLine(res);
    }
}


class DisjointSparseTable<T>
{
    public readonly int Size;
    readonly int Height;
    readonly T[] Table;
    readonly Func<T, T, T> Merge;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DisjointSparseTable(T[] data, Func<T, T, T> merge)
    {
        Size = data.Length;
        Height = MSBPos(Size) + 1;
        Table = new T[Size * Height];
        Merge = merge;
        data.CopyTo(Table, 0);
        for (int layer = 1; layer < Height; layer++)
        {
            int layerOffset = layer * Size;
            int block = 0;
            int i;
            for (; block + 2 <= Size >> layer; block += 2)
            {
                i = layerOffset + ((block | 1) << layer) - 1; Table[i] = Table[i - layerOffset]; i--;
                for (; i >= layerOffset + (block << layer); i--) Table[i] = Merge(Table[i - layerOffset], Table[i + 1]);
                i = layerOffset + ((block | 1) << layer); Table[i] = Table[i - layerOffset]; i++;
                for (; i < layerOffset + ((block + 2) << layer); i++) Table[i] = Merge(Table[i - 1], Table[i - layerOffset]);
            }
            if (((block | 1) << layer) < Size)
            {
                i = layerOffset + ((block | 1) << layer) - 1; Table[i] = Table[i - layerOffset]; i--;
                for (; i >= layerOffset + (block << layer); i--) Table[i] = Merge(Table[i - layerOffset], Table[i + 1]);
                i = layerOffset + ((block | 1) << layer); Table[i] = Table[i - layerOffset]; i++;
                for (; i < layerOffset + Size; i++) Table[i] = Merge(Table[i - 1], Table[i - layerOffset]);
            }
        }
    }

    public T Query(int l, int r)
    {
        if (l == r) return Table[l];
        var layer = MSBPos(l ^ r);
        return Merge(Table[l + layer * Size], Table[r + layer * Size]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int MSBPos(int n)
    {
        int res = 0;
        if (0 != (n >> (res | 16))) res |= 16;
        if (0 != (n >> (res | 8))) res |= 8;
        if (0 != (n >> (res | 4))) res |= 4;
        if (0 != (n >> (res | 2))) res |= 2;
        if (0 != (n >> (res | 1))) res |= 1;
        return res;
    }
}

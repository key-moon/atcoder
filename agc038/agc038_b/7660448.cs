// detail: https://atcoder.jp/contests/agc038/submissions/7660448
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
        DisjointSparseTable<Incr> isIncr = new DisjointSparseTable<Incr>(p.Select(x => new Incr() { L = x, R = x, Valid = true }).ToArray(), Incr.Merge);
        DisjointSparseTable<int> rmin = new DisjointSparseTable<int>(p, Min);
        DisjointSparseTable<int> rmax = new DisjointSparseTable<int>(p, Max);
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
        Height = GetMSB(Size) + 1;
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
            if (Size <= ((block | 1) << layer)) continue;
            {
                i = layerOffset + Min((block | 1) << layer, Size) - 1; Table[i] = Table[i - layerOffset]; i--;
                for (; i >= layerOffset + (block << layer); i--) Table[i] = Merge(Table[i - layerOffset], Table[i + 1]);

                i = layerOffset + ((block | 1) << layer); Table[i] = Table[i - layerOffset]; i++;
                var max = layerOffset + Size;
                for (; i < max; i++) Table[i] = Merge(Table[i - 1], Table[i - layerOffset]);
            }
        }
    }

    public T Query(int l, int r)
    {
        if (l == r) return Table[l];
        var layer = GetMSB(l ^ r);
        return Merge(Table[l + layer * Size], Table[r + layer * Size]);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static int GetMSB(int n)
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
